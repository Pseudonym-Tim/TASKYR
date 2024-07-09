using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace TASKYR
{
    public partial class MainForm : Form
    {
        private const string SettingsFilePath = "settings.json";
        private BlockManager blockingManager;
        private Timer frameTimer;
        private Timer statusClearTimer; // Timer to clear status message
        public bool isClosing = false;
        public bool isBlockingEnabled = false;
        public string SelectedProcess { get; private set; }
        private DateTime workStartTime;
        public bool useSchedule = false;
        public bool addToStartup = false; 
        private bool minimizeToTray = false;
        private Timer idleTimer;
        private DateTime lastActivityTime;
        private const int idleThresholdSeconds = 8;
        private TimeSpan totalIdleTime = TimeSpan.Zero;
        private DateTime lastIdleStartTime;
        private const int WM_CLOSE = 0x0010;

        public MainForm()
        {
            blockingManager = new BlockManager(this);
            InitializeComponent();
            LoadSettings();
            InitializeBrowserComboBox();
            InitializeStatusClearTimer();
            InitializeIdleTimer();

            ProcessProtector.UnprotectProcess();

            InputActivityMonitor.UserActivityDetected += OnUserActivityDetected;
            InputActivityMonitor.Start();
        }

        private void InitializeIdleTimer()
        {
            idleTimer = new Timer();
            idleTimer.Interval = 16;
            idleTimer.Tick += IdleTimer_Tick;
            idleTimer.Start();

            lastActivityTime = DateTime.Now;
        }

        private void OnUserActivityDetected(object sender, EventArgs e)
        {
            lastActivityTime = DateTime.Now;
        }

        private void IdleTimer_Tick(object sender, EventArgs e)
        {
            if((DateTime.Now - lastActivityTime).TotalSeconds >= idleThresholdSeconds && isBlockingEnabled)
            {
                if(lastIdleStartTime == DateTime.MinValue) // Mark the start of the idle period
                {
                    lastIdleStartTime = DateTime.Now;
                }

                TimeSpan idleDuration = DateTime.Now - lastActivityTime;
                statusText.Text = $"You have been idle for {Math.Floor(idleDuration.TotalSeconds)} seconds";
            }
            else if((DateTime.Now - lastActivityTime).TotalSeconds < idleThresholdSeconds && isBlockingEnabled)
            {
                if(lastIdleStartTime != DateTime.MinValue) // If was idle, now active
                {
                    totalIdleTime += DateTime.Now - lastIdleStartTime; // Accumulate idle time
                    lastIdleStartTime = DateTime.MinValue; // Reset idle start time
                }
            }
        }

        private void LoadSettings()
        {
            if(File.Exists(SettingsFilePath))
            {
                var json = File.ReadAllText(SettingsFilePath);
                var settings = JsonConvert.DeserializeObject<Settings>(json);
                blockingManager.Schedule = settings.Schedule;
                blockingManager.DefaultBrowser = settings.DefaultBrowser;
                useSchedule = settings.UseSchedule;
                addToStartup = settings.AddToStartup;
                minimizeToTray = settings.MinimizeToTray; // Load the setting
                blockingManager.BlockedPrograms = settings.BlockedPrograms;
                blockingManager.BlockedWebsites = settings.BlockedWebsites;
                blockingManager.LastWorkSessionDuration = settings.LastWorkSessionDuration;

                // Update UI elements based on loaded settings
                useScheduleCheckBox.Checked = useSchedule;
                addToStartupCheckBox.Checked = addToStartup;
                minimizeToTrayCheckBox.Checked = minimizeToTray; // Update the checkbox
                browserComboBox.SelectedItem = blockingManager.DefaultBrowser;
                UpdateBlockedProgramsList();
                UpdateBlockedWebsitesList();

                if(addToStartup)
                {
                    AddToStartup();
                }
                else
                {
                    RemoveFromStartup();
                }
            }
        }

        private void SaveSettings()
        {
            var settings = new Settings
            {
                Schedule = blockingManager.Schedule,
                DefaultBrowser = blockingManager.DefaultBrowser,
                UseSchedule = useSchedule,
                AddToStartup = addToStartup,
                MinimizeToTray = minimizeToTray,
                BlockedPrograms = blockingManager.BlockedPrograms,
                BlockedWebsites = blockingManager.BlockedWebsites,
                LastWorkSessionDuration = blockingManager.LastWorkSessionDuration
            };

            var json = JsonConvert.SerializeObject(settings, Formatting.Indented);
            File.WriteAllText(SettingsFilePath, json);
        }

        private void SetupTimer()
        {
            if(frameTimer != null)
            {
                frameTimer.Stop();
                frameTimer.Tick -= FrameTimer_Tick;
            }

            frameTimer = new Timer();
            frameTimer.Interval = 16;
            frameTimer.Tick += FrameTimer_Tick;
            frameTimer.Start();
        }

        private void FrameTimer_Tick(object sender, EventArgs e)
        {
            if((DateTime.Now - lastActivityTime).TotalSeconds < idleThresholdSeconds)
            {
                if(useSchedule && blockingManager.IsBlockingTime())
                {
                    StartBlock();
                }
                else if(useSchedule && !blockingManager.IsBlockingTime())
                {
                    StopBlock(true);
                }

                if(isBlockingEnabled)
                {
                    if(!useSchedule || blockingManager.IsBlockingTime())
                    {
                        blockingManager.BlockPrograms();
                        blockingManager.BlockWebsites();
                    }
                    else
                    {
                        blockingManager.UnblockPrograms();
                        blockingManager.UnblockWebsites();
                    }

                    // Calculate total work time minus idle time
                    TimeSpan elapsedTime = DateTime.Now - workStartTime - totalIdleTime;
                    statusText.Text = $"You've been working for {elapsedTime.Hours} hours, {elapsedTime.Minutes} minutes, and {elapsedTime.Seconds} seconds";
                }
                else
                {
                    if(!statusClearTimer.Enabled)
                    {
                        // Show last session duration if the user is not currently working
                        TimeSpan lastSessionDuration = blockingManager.LastWorkSessionDuration;
                        if(lastSessionDuration.TotalSeconds > 0)
                        {
                            statusText.Text = $"You worked for {lastSessionDuration.Hours} hours, {lastSessionDuration.Minutes} minutes, and {lastSessionDuration.Seconds} seconds last session!";
                        }
                        else
                        {
                            statusText.Text = "You are not currently working!";
                        }
                    }
                }

                UpdateUIState();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            SetupTimer();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Unsure if desirable behaviour, commented out for now...
            /*if(!isClosing && this.WindowState != FormWindowState.Minimized)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                base.OnFormClosing(e);
            }*/

            if(isBlockingEnabled)
            {
                using(var form = new CloseConfirmationForm())
                {
                    form.ShowDialog();
                    if(!form.IsConfirmed)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }

#if !DEBUG
            ProcessProtector.UnprotectProcess();
#endif

            // Call SaveSettings before the form actually closes...
            SaveSettings();

            InputActivityMonitor.Stop();
            base.OnFormClosing(e);
            isClosing = true;
            blockingManager.UnblockWebsites();
            blockingManager.BlockedWebsites.Clear();
        }

        private void AddToStartup()
        {
            string runKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
            RegistryKey startupKey = Registry.CurrentUser.OpenSubKey(runKey, true);
            if(startupKey.GetValue("TASKYR") == null)
            {
                startupKey.SetValue("TASKYR", Assembly.GetExecutingAssembly().Location);
            }
        }

        private void RemoveFromStartup()
        {
            string runKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
            RegistryKey startupKey = Registry.CurrentUser.OpenSubKey(runKey, true);
            if(startupKey.GetValue("TASKYR") != null)
            {
                startupKey.DeleteValue("TASKYR");
            }
        }

        private void InitializeBrowserComboBox()
        {
            browserComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            browserComboBox.Items.AddRange(new string[] { "Chrome", "Firefox", "Edge", "Vivaldi", "Opera" });
            browserComboBox.SelectedIndex = browserComboBox.Items.IndexOf(blockingManager.DefaultBrowser);
        }

        private void InitializeStatusClearTimer()
        {
            statusClearTimer = new Timer();
            statusClearTimer.Interval = 1000; // 1 second
            statusClearTimer.Tick += StatusClearTimer_Tick;
        }

        private void StatusClearTimer_Tick(object sender, EventArgs e)
        {
            statusText.Text = string.Empty;
            statusClearTimer.Stop();
        }

        private void UpdateUIState()
        {
            bool enabled = !isBlockingEnabled;

            addProgramButton.Enabled = enabled;
            removeProgramButton.Enabled = enabled;
            addWebsiteButton.Enabled = enabled;
            removeWebsiteButton.Enabled = enabled;

            blockedProgramsListBox.Enabled = enabled;
            blockedWebsitesListBox.Enabled = enabled;

            addWebsiteTextBox.Enabled = enabled;
            browserComboBox.Enabled = enabled;
            useScheduleCheckBox.Enabled = enabled;
            configureScheduleButton.Enabled = enabled;
        }

        private void blockButton_Click(object sender, EventArgs e)
        {
            if(isBlockingEnabled)
            {
                StopBlock();
            }
            else
            {
                StartBlock();
            }

            UpdateUIState();
        }

        private void StartBlock()
        {
            if(!isBlockingEnabled)
            {
                isBlockingEnabled = true;
                blockButton.Text = "Stop Working!";

#if !DEBUG
            ProcessProtector.ProtectProcess();
#endif

                foreach(var item in blockedWebsitesListBox.Items)
                {
                    string website = item.ToString();
                    blockingManager.AddWebsiteToBlock(website);
                }

                foreach(var item in blockedProgramsListBox.Items)
                {
                    string program = item.ToString();
                    blockingManager.AddProgramToBlock(program);
                }

                blockingManager.StartBlocking();
                workStartTime = DateTime.Now;
                SetupTimer();
            }
        }

        private void StopBlock(bool overridePrompt = false)
        {
            if(isBlockingEnabled)
            {
                if(!overridePrompt)
                {
                    using(var form = new CloseConfirmationForm())
                    {
                        form.ShowDialog();
                        if(!form.IsConfirmed)
                        {
                            return;
                        }
                    }
                }

                isBlockingEnabled = false;
                blockButton.Text = "Start Working!";

#if !DEBUG
                ProcessProtector.UnprotectProcess();
#endif

                // Save the last work session duration
                TimeSpan lastSessionDuration = DateTime.Now - workStartTime;
                blockingManager.LastWorkSessionDuration = lastSessionDuration;

                Debug.WriteLine("Stopping work. Saving settings...");
                SaveSettings(); // Ensure settings are saved when stopping work
                blockingManager.UnblockPrograms();
                blockingManager.UnblockWebsites();
            }
        }

        private void browserComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedBrowser = browserComboBox.SelectedItem.ToString();
            blockingManager.SetDefaultBrowser(selectedBrowser);
        }

        protected override void WndProc(ref Message m)
        {
            if(m.Msg == WM_CLOSE)
            {
                var result = MessageBox.Show("Are you sure you want to close the application?", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.No)
                {
                    // If the user clicks 'No', cancel the close operation
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private void addProgramButton_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Executable Files|*.exe|All Files|*.*";
                openFileDialog.Title = "Select an Executable";

                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    string selectedFileName = Path.GetFileNameWithoutExtension(selectedFilePath); // Extract the name without the extension

                    SelectedProcess = selectedFileName; // Use the file name without the extension

                    if(SelectedProcess.Equals("TASKYR", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Hey! You can't block TASKYR!", "You dirty cheater!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        DialogResult = DialogResult.OK;
                        blockingManager.AddProgramToBlock(selectedFileName); // Pass the file name without the extension to the blocking manager
                        UpdateBlockedProgramsList();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a process.");
                }
            }
        }

        private void UpdateBlockedProgramsList()
        {
            blockedProgramsListBox.Items.Clear();

            foreach(var program in blockingManager.BlockedPrograms)
            {
                blockedProgramsListBox.Items.Add(program);
            }
        }

        private void addWebsiteButton_Click(object sender, EventArgs e)
        {
            string website = addWebsiteTextBox.Text.Trim();

            if(!string.IsNullOrEmpty(website))
            {
                blockingManager.AddWebsiteToBlock(website);
                UpdateBlockedWebsitesList();
                addWebsiteTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a website URL!");
            }
        }

        private void UpdateBlockedWebsitesList()
        {
            blockedWebsitesListBox.Items.Clear();

            foreach(var website in blockingManager.BlockedWebsites)
            {
                blockedWebsitesListBox.Items.Add(website);
            }
        }

        private void removeProgramButton_Click(object sender, EventArgs e)
        {
            if(blockedProgramsListBox.SelectedItem != null)
            {
                string selectedProgram = blockedProgramsListBox.SelectedItem.ToString();
                blockingManager.RemoveBlockedProgram(selectedProgram);
                UpdateBlockedProgramsList();
            }
            else
            {
                MessageBox.Show("Please select a program to remove!");
            }
        }

        private void removeWebsiteButton_Click(object sender, EventArgs e)
        {
            if(blockedWebsitesListBox.SelectedItem != null)
            {
                string selectedWebsite = blockedWebsitesListBox.SelectedItem.ToString();
                blockingManager.RemoveBlockedWebsite(selectedWebsite);
                UpdateBlockedWebsitesList();
            }
            else
            {
                MessageBox.Show("Please select a website to remove!");
            }
        }

        private void configureScheduleButton_Click(object sender, EventArgs e)
        {
            using(var form = new ScheduleForm(blockingManager))
            {
                form.ShowDialog();
            }
        }

        private void useScheduleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            useSchedule = useScheduleCheckBox.Checked;
        }

        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
            statusText.Text = "Settings saved successfully!";
            statusClearTimer.Start(); // Start the timer to clear the status message
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if(minimizeToTray && this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(1000, "TASKYR", "Minimized to tray.", ToolTipIcon.Info);
            }
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isClosing = true;
            this.Close();
        }

        private void addToStartupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            addToStartup = addToStartupCheckBox.Checked;
            if(addToStartup)
            {
                AddToStartup();
            }
            else
            {
                RemoveFromStartup();
            }
        }

        private void minimizeToTrayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            minimizeToTray = minimizeToTrayCheckBox.Checked;
            SaveSettings();
        }
    }
}