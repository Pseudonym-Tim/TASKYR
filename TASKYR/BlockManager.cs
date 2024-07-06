using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace TASKYR
{
    public class BlockManager
    {
        private MainForm mainForm;
        public List<string> BlockedPrograms { get; set; } = new List<string>();
        public List<string> BlockedWebsites { get; set; } = new List<string>();
        public Dictionary<DayOfWeek, (TimeSpan, TimeSpan)?> Schedule { get; set; }
        public string DefaultBrowser { get; set; } = "Chrome";

        public BlockManager(MainForm form)
        {
            Schedule = new Dictionary<DayOfWeek, (TimeSpan, TimeSpan)?>();
            mainForm = form;
        }

        public void StartBlocking()
        {
            InitializeBlockSettings();
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

                if(now.TimeOfDay >= start && now.TimeOfDay <= end)
                {
                    return true;
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
            ModifyHostsFile(addEntries: true);
        }

        public void UnblockWebsites()
        {
            ModifyHostsFile(addEntries: false);
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
