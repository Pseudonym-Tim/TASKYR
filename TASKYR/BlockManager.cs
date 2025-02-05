using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TASKYR
{
    public class BlockManager
    {
        private MainForm mainForm;
        public List<string> BlockedPrograms { get; set; } = new List<string>();
        public List<string> BlockedWebsites { get; set; } = new List<string>();
        public TimeSpan LastWorkSessionDuration { get; set; }
        public Dictionary<DayOfWeek, (TimeSpan, TimeSpan)?> Schedule { get; set; }
        public string DefaultBrowser { get; set; } = "Chrome";

        public DateTime LastCoffeeBreakTime { get; set; } = DateTime.MinValue;
        public TimeSpan CoffeeBreakDuration { get; set; } = TimeSpan.FromMinutes(15);  // 15 minutes break duration
        public TimeSpan CoffeeBreakCooldown { get; set; } = TimeSpan.FromHours(2);  // 2 hours cooldown period

        private HashSet<string> runningBlockedProgramsAtStart = new HashSet<string>();

        public BlockManager(MainForm form)
        {
            Schedule = new Dictionary<DayOfWeek, (TimeSpan, TimeSpan)?>();
            mainForm = form;
        }

        public void StartBlocking()
        {
            InitializeBlockSettings();

            runningBlockedProgramsAtStart.Clear();

            foreach(Process process in Process.GetProcesses())
            {
                if(BlockedPrograms.Contains(process.ProcessName.ToLower()))
                {
                    runningBlockedProgramsAtStart.Add(process.ProcessName.ToLower());
                }
            }
        }

        public bool StartCoffeeBreak()
        {
            if((DateTime.Now - LastCoffeeBreakTime >= CoffeeBreakCooldown) && mainForm.isBlockingEnabled)
            {
                // Unlock programs/websites temporarily...
                UnblockPrograms();
                UnblockWebsites();

                // Start the coffee break timer...
                LastCoffeeBreakTime = DateTime.Now;
                mainForm.StartCoffeeBreakTimer();
                return true;
            }
            else
            {
                if(!mainForm.IsInCoffeeBreak)
                {
                    MessageBox.Show("You must wait until the 2 hour cooldown period is over!");
                }
            }

            return false;
        }

        public void NotifyNewlyBlockedPrograms()
        {
            HashSet<string> currentRunningProcesses = new HashSet<string>(Process.GetProcesses().Select(p => p.ProcessName.ToLower()));

            foreach(string program in BlockedPrograms)
            {
                if(currentRunningProcesses.Contains(program.ToLower()) && !runningBlockedProgramsAtStart.Contains(program.ToLower()))
                {
                    // Show notification...
                    NotifyUser(program);

                    // Prevent repeated notifications...
                    runningBlockedProgramsAtStart.Add(program.ToLower());
                }
            }
        }

        private void NotifyUser(string programName)
        {
            mainForm.Invoke((MethodInvoker)(() =>
            {
                MessageBox.Show($"{programName} is blocked during work mode, sorry!", "Blocked Program Detected!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }));
        }

        private void InitializeBlockSettings()
        {
            // For example: (Monday, the schedule is set to open at 12:00 PM (noon) and close at 8:00 PM)
            /*Schedule[DayOfWeek.Monday] = (new TimeSpan(12, 0, 0), new TimeSpan(20, 0, 0));
            Schedule[DayOfWeek.Wednesday] = (new TimeSpan(12, 0, 0), new TimeSpan(20, 0, 0));

            // For debugging purposes!
            var now = DateTime.Now;
            var start = now.TimeOfDay;
            var end = start.Add(TimeSpan.FromMinutes(1));
            Schedule[now.DayOfWeek] = (start, end);*/

            // Check and close the default browser if it's currently running...
            if(!string.IsNullOrEmpty(DefaultBrowser) && !mainForm.isClosing)
            {
                CloseBrowser(DefaultBrowser);
            }
        }

        public (TimeSpan, TimeSpan)? GetScheduleForDay(DayOfWeek day)
        {
            if(Schedule.ContainsKey(day))
            {
                return Schedule[day];
            }

            return null;
        }

        public void SetScheduleForDay(DayOfWeek day, TimeSpan? startTime, TimeSpan? endTime)
        {
            if(startTime.HasValue && endTime.HasValue)
            {
                Schedule[day] = (startTime.Value, endTime.Value);
            }
            else
            {
                Schedule.Remove(day);
            }
        }

        public void SetDefaultBrowser(string browserName)
        {
            DefaultBrowser = browserName;
            LogAction($"Default browser set to: {DefaultBrowser}");
        }

        public bool IsBlockingTime()
        {
            var now = DateTime.Now;

            if(Schedule.ContainsKey(now.DayOfWeek) && Schedule[now.DayOfWeek].HasValue)
            {
                var (start, end) = Schedule[now.DayOfWeek].Value;

                // If the end time is earlier than the start time, we assume it's a 24-hour schedule...
                if(end < start)
                {
                    return now.TimeOfDay >= start || now.TimeOfDay <= end; // Covers the time wrapping around midnight...
                }
                else
                {
                    return now.TimeOfDay >= start && now.TimeOfDay <= end; // Normal schedule check...
                }
            }

            return false;
        }

        public List<string> GetRunningProcesses()
        {
            var processes = Process.GetProcesses();
            return processes.Select(p => p.ProcessName).Distinct().OrderBy(p => p).ToList();
        }

        public void AddWebsiteToBlock(string website)
        {
            if(!BlockedWebsites.Contains(website.ToLower()))
            {
                BlockedWebsites.Add(website.ToLower());
                LogAction($"Added to blocked websites: {website}");
            }
        }

        public void RemoveBlockedWebsite(string website)
        {
            if(BlockedWebsites.Contains(website.ToLower()))
            {
                BlockedWebsites.Remove(website.ToLower());
                LogAction($"Removed from blocked websites: {website}");
            }
        }

        public void AddProgramToBlock(string programName)
        {
            if(!BlockedPrograms.Contains(programName.ToLower()))
            {
                BlockedPrograms.Add(programName.ToLower());
                LogAction($"Added to blocked programs: {programName}");
            }
        }

        public void RemoveBlockedProgram(string programName)
        {
            if(BlockedPrograms.Contains(programName.ToLower()))
            {
                BlockedPrograms.Remove(programName.ToLower());
                LogAction($"Removed from blocked programs: {programName}");
            }
        }

        public void BlockPrograms()
        {
            var processes = Process.GetProcesses();

            foreach(var process in processes)
            {
                if(BlockedPrograms.Contains(process.ProcessName.ToLower()))
                {
                    try
                    {
                        process.Kill();
                        LogAction($"Blocked program: {process.ProcessName}");
                    }
                    catch(Exception ex)
                    {
                        LogAction($"Failed to kill process {process.ProcessName}: {ex.Message}");
                    }
                }
            }
        }

        public void UnblockPrograms()
        {
            // Create a temporary list to store programs to unblock
            var programsToUnblock = new List<string>(BlockedPrograms);

            foreach(var program in programsToUnblock)
            {
                try
                {
                    RemoveBlockedProgram(program);
                    LogAction($"Unblocked program: {program}");
                }
                catch(Exception ex)
                {
                    LogAction($"Failed to unblock {program}: {ex.Message}");
                }
            }
        }

        public void BlockWebsites()
        {
            ModifyHostsFile(true);
        }

        public void UnblockWebsites()
        {
            ModifyHostsFile(false);
        }

        private void ModifyHostsFile(bool addEntries)
        {
            var hostsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers/etc/hosts");
            var lines = File.ReadAllLines(hostsPath).ToList();
            bool changesMade = false;

            foreach(var site in BlockedWebsites)
            {
                var entry = $"127.0.0.1 {site}";
                if(addEntries && !lines.Contains(entry))
                {
                    lines.Add(entry);
                    changesMade = true;
                    LogAction($"Blocked website: {site}");
                }
                else if(!addEntries && lines.Contains(entry))
                {
                    lines.Remove(entry);
                    changesMade = true;
                    LogAction($"Unblocked website: {site}");
                }
            }

            if(changesMade)
            {
                File.WriteAllLines(hostsPath, lines);
                FlushDNSCache();
            }
        }

        private void FlushDNSCache()
        {
            var psi = new ProcessStartInfo("ipconfig", "/flushdns")
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using(var process = Process.Start(psi))
            {
                process.WaitForExit();
                var output = process.StandardOutput.ReadToEnd();
                LogAction("DNS cache flushed");
                LogAction(output);
            }
        }

        private void CloseBrowser(string browserName)
        {
            var processes = Process.GetProcessesByName(browserName);
            foreach(var process in processes)
            {
                try
                {
                    process.Kill();
                    LogAction($"Closed default browser: {process.ProcessName}");
                }
                catch(Exception ex)
                {
                    LogAction($"Failed to close default browser {process.ProcessName}: {ex.Message}");
                }
            }
        }

        private void LogAction(string message)
        {
            var logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "debungle.log");

            using(var writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }
    }
}
