using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
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

        public MainForm()
        {
            blockingManager = new BlockManager(this);
            InitializeComponent();
            LoadSettings();
            InitializeBrowserComboBox();
            InitializeStatusClearTimer(); // Initialize the status clear timer
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
                blockingManager.BlockedPrograms = settings.BlockedPrograms;
                blockingManager.BlockedWebsites = settings.BlockedWebsites;

                // Update UI elements based on loaded settings
                useScheduleCheckBox.Checked = useSchedule;
                browserComboBox.SelectedItem = blockingManager.DefaultBrowser;
                UpdateBlockedProgramsList();
                UpdateBlockedWebsitesList();
            }
        }

        private void SaveSettings()
        {
            var settings = new Settings
            {
                Schedule = blockingManager.Schedule,
                DefaultBrowser = blockingManager.DefaultBrowser,
                UseSchedule = useSchedule,
                BlockedPrograms = blockingManager.BlockedPrograms,
                BlockedWebsites = blockingManager.BlockedWebsites
            };

            Debug.WriteLine("Saving settings...");
            Debug.WriteLine($"Blocked Programs Count: {settings.BlockedPrograms.Count}");
            Debug.WriteLine($"Blocked Programs: {string.Join(", ", settings.BlockedPrograms)}");

            var json = JsonConvert.SerializeObject(settings, Newtonsoft.Json.Formatting.Indented);
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

                // Update status text with elapsed time...
                TimeSpan elapsedTime = DateTime.Now - workStartTime;
                statusText.Text = $"You've been working for {elapsedTime.Hours} hours, {elapsedTime.Minutes} minutes, and {elapsedTime.Seconds} seconds";
            }
            else
            {
                if(!statusClearTimer.Enabled)
                {
                    statusText.Text = "You are not currently working!";
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetupTimer();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
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

            base.OnFormClosing(e);
            isClosing = true;
            blockingManager.UnblockWebsites();
            blockingManager.BlockedWebsites.Clear();
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

                Debug.WriteLine("Stopping work. Saving settings...");
                SaveSettings(); // Ensure settings are saved when stopping work
                blockingManager.UnblockPrograms();
                blockingManager.UnblockWebsites();
            }
        }

        private void StartBlock()
        {
            if(!isBlockingEnabled)
            {
                isBlockingEnabled = true;
                blockButton.Text = "Stop Working!";

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

        private void browserComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedBrowser = browserComboBox.SelectedItem.ToString();
            blockingManager.SetDefaultBrowser(selectedBrowser);
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
                        MessageBox.Show("Hey! You can't block TASKYR!", "Dumbass!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            statusText.Text = "Save settings successfully!";
            statusClearTimer.Start(); // Start the timer to clear the status message
        }
    }
}
