using System;
using System.Windows.Forms;

namespace TASKYR
{
    public partial class ScheduleForm : Form
    {
        private BlockManager blockManager;

        public ScheduleForm(BlockManager manager)
        {
            InitializeComponent();
            blockManager = manager;
            AddControlsForDays();
            PopulateSchedule();
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

        private void saveButton_Click(object sender, EventArgs e)
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
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void AddControlsForDays()
        {
            int yOffset = 20;
            foreach(DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                var dayCheckbox = new CheckBox
                {
                    Name = day + "Checkbox",
                    Text = day.ToString(),
                    Location = new System.Drawing.Point(20, yOffset),
                    AutoSize = true,
                    Font = new System.Drawing.Font("Microsoft Sans Serif", 12F)
                };
                dayCheckbox.CheckedChanged += DayCheckbox_CheckedChanged;

                var startTimePicker = new DateTimePicker
                {
                    Name = day + "StartTimePicker",
                    Format = DateTimePickerFormat.Time,
                    ShowUpDown = true,
                    Location = new System.Drawing.Point(200, yOffset),
                    Width = 150,
                    Font = new System.Drawing.Font("Microsoft Sans Serif", 12F)
                };
                var endTimePicker = new DateTimePicker
                {
                    Name = day + "EndTimePicker",
                    Format = DateTimePickerFormat.Time,
                    ShowUpDown = true,
                    Location = new System.Drawing.Point(370, yOffset),
                    Width = 150,
                    Font = new System.Drawing.Font("Microsoft Sans Serif", 12F)
                };

                this.Controls.Add(dayCheckbox);
                this.Controls.Add(startTimePicker);
                this.Controls.Add(endTimePicker);

                yOffset += 50;
            }
        }

        private void DayCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            var checkbox = sender as CheckBox;
            var day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), checkbox.Text);
            var startTimePicker = Controls.Find(day + "StartTimePicker", true)[0] as DateTimePicker;
            var endTimePicker = Controls.Find(day + "EndTimePicker", true)[0] as DateTimePicker;

            startTimePicker.Enabled = checkbox.Checked;
            endTimePicker.Enabled = checkbox.Checked;
        }
    }
}
