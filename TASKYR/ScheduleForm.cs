using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace TASKYR
{
    public partial class ScheduleForm : Form
    {
        private BlockManager blockManager;
        private Timer updateTimer;
        private Panel dayPanel;

        public ScheduleForm(BlockManager manager)
        {
            InitializeComponent();
            blockManager = manager;
            AddControlsForDays();
            PopulateSchedule();

            // Initialize the timer
            updateTimer = new Timer();
            updateTimer.Interval = 16;  // 16 ms (about 60 FPS)
            updateTimer.Tick += UpdateTimer_Tick;  // Event handler for each tick
            updateTimer.Start();  // Start the timer
                                  
            this.FormClosed += ScheduleForm_FormClosed;
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            UpdateScheduleDisplay();  // Update the display every 16ms
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Stop the timer before closing...
            updateTimer.Stop();

            // Proceed with closing the form...
            base.OnFormClosing(e);
        }

        private void ScheduleForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach(DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                var dayCheckbox = Controls.Find(day + "Checkbox", true)[0] as CheckBox;
                var startTimePicker = Controls.Find(day + "StartTimePicker", true)[0] as DateTimePicker;
                var endTimePicker = Controls.Find(day + "EndTimePicker", true)[0] as DateTimePicker;

                if(dayCheckbox.Checked)
                {
                    var startTime = startTimePicker.Value.TimeOfDay;
                    var endTime = endTimePicker.Value.TimeOfDay;
                    blockManager.SetScheduleForDay(day, startTime, endTime);
                }
                else
                {
                    blockManager.SetScheduleForDay(day, null, null);
                }
            }

            // Save the schedule when the form is closed...
            saveButton_Click(sender, e);
        }

        private void PopulateSchedule()
        {
            foreach(DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                var dayCheckbox = Controls.Find(day + "Checkbox", true)[0] as CheckBox;
                var startTimePicker = Controls.Find(day + "StartTimePicker", true)[0] as DateTimePicker;
                var endTimePicker = Controls.Find(day + "EndTimePicker", true)[0] as DateTimePicker;
                var schedule = blockManager.GetScheduleForDay(day);

                if(schedule.HasValue)
                {
                    startTimePicker.Value = DateTime.Today.Add(schedule.Value.Item1);
                    endTimePicker.Value = DateTime.Today.Add(schedule.Value.Item2);
                    dayCheckbox.Checked = true;
                }
                else
                {
                    dayCheckbox.Checked = false;
                    startTimePicker.Enabled = false;
                    endTimePicker.Enabled = false;
                }
            }
        }

        private void UpdateScheduleDisplay()
        {
            foreach(DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                var dayCheckbox = Controls.Find(day + "Checkbox", true)[0] as CheckBox;
                var startTimePicker = Controls.Find(day + "StartTimePicker", true)[0] as DateTimePicker;
                var endTimePicker = Controls.Find(day + "EndTimePicker", true)[0] as DateTimePicker;
                var dayGroupBox = Controls.Find(day + "GroupBox", true)[0] as GroupBox;

                // Remove any existing label (if any)...
                var existingLabel = dayGroupBox.Controls.OfType<Label>().FirstOrDefault();

                if(existingLabel != null)
                {
                    dayGroupBox.Controls.Remove(existingLabel);
                }

                if(dayCheckbox.Checked)
                {
                    // Check if the start and end time are the same...
                    var timeDifference = endTimePicker.Value.TimeOfDay - startTimePicker.Value.TimeOfDay;

                    if(Math.Abs(timeDifference.TotalSeconds) <= 1) // tolerance of 1 second...
                    {
                        var wholeDayLabel = new Label
                        {
                            Text = "Active for the whole day!",
                            Location = new System.Drawing.Point(160 + 60, 55),
                            ForeColor = System.Drawing.Color.White,
                            Width = 220,
                            Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold),
                        };

                        dayGroupBox.Controls.Add(wholeDayLabel);
                    }
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddControlsForDays()
        {
            // Create a Panel for day group boxes...
            dayPanel = new Panel
            {
                Name = "DayPanel",
                Location = new System.Drawing.Point(40, 20),
                Size = new System.Drawing.Size(525, 350),
                AutoScroll = true,
                BorderStyle = BorderStyle.None
            };

            int yOffset = 10;  // Start at the top of the panel
            int controlHeight = 80;  // Reduced height for each day group box
            int groupBoxWidth = 460;  // Width of the group box (reduced for better fitting)

            foreach(DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                // Create and configure each day group box
                var dayGroupBox = new GroupBox
                {
                    Name = day + "GroupBox",
                    Text = day.ToString(),
                    Location = new System.Drawing.Point(10, yOffset),
                    Size = new System.Drawing.Size(groupBoxWidth, controlHeight),  // Set size for better fitting
                    Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline),
                    ForeColor = System.Drawing.Color.White,
                };

                // Create and configure the day checkbox
                var dayCheckbox = new CheckBox
                {
                    Name = day + "Checkbox",
                    Text = "Enable Schedule!",
                    Location = new System.Drawing.Point(10, 30 - 5),
                    AutoSize = true,
                    Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold),
                    ForeColor = System.Drawing.Color.White,
                    Tag = day, // Store the DayOfWeek in the Tag property...
                };

                // Event handler for checkbox change
                dayCheckbox.CheckedChanged += DayCheckbox_CheckedChanged;

                // Create and configure start time picker
                var startTimePicker = new DateTimePicker
                {
                    Name = day + "StartTimePicker",
                    Format = DateTimePickerFormat.Time,
                    ShowUpDown = true,
                    Location = new System.Drawing.Point(160 + 20, 30 - 5),  // Adjusted the position slightly
                    Width = 120,  // Reduced width for better alignment
                    Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold),
                };

                // Create and configure end time picker
                var endTimePicker = new DateTimePicker
                {
                    Name = day + "EndTimePicker",
                    Format = DateTimePickerFormat.Time,
                    ShowUpDown = true,
                    Location = new System.Drawing.Point(280 + 40, 30 - 5),  // Adjusted the position slightly
                    Width = 120,  // Reduced width for better alignment
                    Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold),
                };

                // Add controls to the group box
                dayGroupBox.Controls.Add(dayCheckbox);
                dayGroupBox.Controls.Add(startTimePicker);
                dayGroupBox.Controls.Add(endTimePicker);

                // Add the group box to the panel
                dayPanel.Controls.Add(dayGroupBox);

                // Update the vertical offset for the next day control
                yOffset += controlHeight + 10;  // Increased space between group boxes slightly
            }

            // Add the panel to the form
            this.Controls.Add(dayPanel);

            // Optionally adjust form height if needed (since it's scrollable, this should work as is)
            this.Height = 500;  // Adjust form height if needed, but the panel should handle scrolling
        }

        private void DayCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            var checkbox = sender as CheckBox;
            var day = (DayOfWeek)checkbox.Tag; // Retrieve the DayOfWeek from the Tag property...
            var startTimePicker = Controls.Find(day + "StartTimePicker", true)[0] as DateTimePicker;
            var endTimePicker = Controls.Find(day + "EndTimePicker", true)[0] as DateTimePicker;

            startTimePicker.Enabled = checkbox.Checked;
            endTimePicker.Enabled = checkbox.Checked;
        }
    }
}
