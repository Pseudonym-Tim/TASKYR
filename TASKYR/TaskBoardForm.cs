using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TASKYR
{
    public partial class TaskBoardForm : Form
    {
        private Timer countdownTimer;
        private Dictionary<Panel, DateTime?> taskDeadlines = new Dictionary<Panel, DateTime?>();

        public TaskBoardForm()
        {
            InitializeComponent();
            InitializeCountdownTimer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeCategoryPanel(panelPlanned, "Planned");
            InitializeCategoryPanel(panelInProgress, "In-Progress");
            InitializeCategoryPanel(panelComplete, "Complete");
            LoadTasks(); // Load saved tasks on startup...
        }

        private void InitializeCountdownTimer()
        {
            countdownTimer = new Timer();
            countdownTimer.Interval = 16;
            countdownTimer.Tick += CountdownTimer_Tick;
            countdownTimer.Start();
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            foreach(var entry in taskDeadlines.ToList())
            {
                Panel taskPanel = entry.Key;
                DateTime? deadline = entry.Value;

                // Skip updating tasks that are in the "Complete" category
                if(panelComplete.Controls.Contains(taskPanel))
                {
                    continue;
                }

                if(deadline.HasValue)
                {
                    TimeSpan timeLeft = deadline.Value - DateTime.Now;
                    Label timerLabel = taskPanel.Controls.OfType<Label>().FirstOrDefault(l => l.Tag?.ToString() == "timer");

                    if(timeLeft.TotalSeconds > 0)
                    {
                        timerLabel.Text = $"Time Left: {timeLeft.Hours:D2}:{timeLeft.Minutes:D2}:{timeLeft.Seconds:D2}";
                    }
                    else
                    {
                        timerLabel.Text = "Expired!";
                        HandleExpiredTask(taskPanel);
                    }
                }
            }
        }

        private void HandleExpiredTask(Panel taskPanel)
        {
            // Ensure the task is not already in the Complete category...
            if(panelComplete.Controls.Contains(taskPanel))
            {
                return; // Do nothing if it's already completed...
            }

            if(autoDeleteTasksCheckbox.Checked)
            {
                panelPlanned.Controls.Remove(taskPanel);
                panelInProgress.Controls.Remove(taskPanel);
                panelComplete.Controls.Remove(taskPanel);
                taskDeadlines.Remove(taskPanel);
            }
            else
            {
                // Move back to Planned only if it was In-Progress...
                if(panelInProgress.Controls.Contains(taskPanel))
                {
                    panelInProgress.Controls.Remove(taskPanel);
                    panelPlanned.Controls.Add(taskPanel);
                }
            }
        }

        private void InitializeCategoryPanel(FlowLayoutPanel panel, string categoryName)
        {
            panel.AllowDrop = true;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.DragEnter += CategoryPanel_DragEnter;
            panel.DragDrop += CategoryPanel_DragDrop;

            // Enable scrolling for the panel...
            panel.AutoScroll = true;

            // Set FlowLayoutPanel properties...
            panel.FlowDirection = FlowDirection.TopDown;
            panel.WrapContents = false; // (Prevents wrapping of tasks...)
        }

        private void btnCreateTask_Click(object sender, EventArgs e)
        {
            string taskName = txtTaskName.Text;
            string taskDescription = rtbTaskDescription.Text;
            DateTime? deadline = deadlineDateTimePicker.Value;
            if(!useDeadlineCheckbox.Checked) { deadline = null; }
            string category = "Planned"; // Default category...

            if(!string.IsNullOrEmpty(taskName))
            {
                Panel newTask = CreateTaskPanel(taskName, taskDescription, deadline);
                AddTaskToPanel(panelPlanned, newTask);
                SaveTasks();
            }
        }

        private Panel CreateTaskPanel(string taskName, string taskDescription, DateTime? deadline)
        {
            Panel taskPanel = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                MaximumSize = new Size(215, 9999),
                Padding = new Padding(10, 5, 10, 5),
                Margin = new Padding(5),
                BackColor = System.Drawing.Color.LightGray,
                AutoSize = true
            };

            bool taskDescriptionIsEmpty = string.IsNullOrEmpty(taskDescription);

            Label taskNameLabel = new Label
            {
                Text = taskName,
                AutoSize = true,
                Font = new Font("Arial", 12, taskDescriptionIsEmpty ? FontStyle.Bold : (FontStyle.Underline | FontStyle.Bold)),
                ForeColor = System.Drawing.Color.Black,
                Padding = new Padding(0, 5, 0, 5)
            };

            Label taskDescriptionLabel = null;
            if(!taskDescriptionIsEmpty)
            {
                taskDescriptionLabel = new Label
                {
                    Text = taskDescription,
                    AutoSize = true,
                    MaximumSize = new Size(200, 9999),
                    Font = new Font("Arial", 9, FontStyle.Bold),
                    ForeColor = System.Drawing.Color.Black
                };
            }

            Label timerLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Arial", 9, FontStyle.Italic | FontStyle.Underline),
                ForeColor = Color.Red,
                Tag = "timer",
                TextAlign = ContentAlignment.BottomLeft,
                Text = deadline.HasValue ? "Time Left: --" : "No Deadline!"
            };

            // Small delete button
            Button deleteButton = new Button
            {
                Text = "Delete",
                Size = new Size(50, 20),
                BackColor = Color.Red,
                ForeColor = Color.White,
                Font = new Font("Arial", 8, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
            deleteButton.FlatAppearance.BorderSize = 0;
            deleteButton.Click += (s, e) => DeleteTask(taskPanel);

            // MouseDown events for dragging
            taskNameLabel.MouseDown += (s, e) => TaskPanel_MouseDown(taskPanel, e);
            if(taskDescriptionLabel != null)
                taskDescriptionLabel.MouseDown += (s, e) => TaskPanel_MouseDown(taskPanel, e);

            taskPanel.Controls.Add(taskNameLabel);
            if(taskDescriptionLabel != null)
                taskPanel.Controls.Add(taskDescriptionLabel);

            int currentTop = taskNameLabel.Bottom + 5;

            if(taskDescriptionLabel != null)
            {
                taskDescriptionLabel.Top = currentTop;
                currentTop = taskDescriptionLabel.Bottom + 5;
            }

            // Positioning the delete button
            deleteButton.Top = currentTop;
            deleteButton.Left = 5;

            // Positioning the timer label to the right
            timerLabel.Top = currentTop;
            timerLabel.Left = taskPanel.Width - timerLabel.Width - 10;

            taskPanel.Controls.Add(deleteButton);
            taskPanel.Controls.Add(timerLabel);

            taskPanel.Height = timerLabel.Bottom + taskPanel.Padding.Bottom;

            taskPanel.MouseDown += TaskPanel_MouseDown;
            taskPanel.DragOver += TaskPanel_DragOver;

            if(deadline.HasValue)
            {
                taskDeadlines[taskPanel] = deadline;
            }

            return taskPanel;
        }

        private void DeleteTask(Panel taskPanel)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this task?", "Delete Task...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(result == DialogResult.Yes)
            {
                // Remove from its parent container
                taskPanel.Parent?.Controls.Remove(taskPanel);

                // Remove from the taskDeadlines dictionary if it exists
                if(taskDeadlines.ContainsKey(taskPanel))
                {
                    taskDeadlines.Remove(taskPanel);
                }

                SaveTasks(); // Update the saved tasks
            }
        }

        private void TaskPanel_MouseDown(object sender, MouseEventArgs e)
        {
            // Begin the drag operation for a task when clicking anywhere in the task panel...
            Panel task = (Panel)sender;

            // Ensure that the drag operation is initiated correctly...
            if(e.Button == MouseButtons.Left)
            {
                task.DoDragDrop(task, DragDropEffects.Move);
            }
        }

        private void TaskPanel_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move; // Allow the drag to proceed...
        }

        private void CategoryPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move; // Indicate that the drop is allowed...
        }

        private void CategoryPanel_DragDrop(object sender, DragEventArgs e)
        {
            Panel task = (Panel)e.Data.GetData(typeof(Panel));
            FlowLayoutPanel targetPanel = sender as FlowLayoutPanel;

            if(targetPanel != null)
            {
                Panel currentPanel = task.Parent as Panel;

                if(currentPanel != null)
                {
                    currentPanel.Controls.Remove(task);
                }

                AddTaskToPanel(targetPanel, task);
                SaveTasks(); // Save after moving a task...
            }
        }

        private void AddTaskToPanel(FlowLayoutPanel panel, Panel taskPanel)
        {
            if(panel == panelPlanned)
            {
                taskPanel.BackColor = Color.LightGray;
            }
            else if(panel == panelInProgress)
            {
                taskPanel.BackColor = Color.LightBlue;
            }
            else if(panel == panelComplete)
            {
                taskPanel.BackColor = Color.LightGreen;

                // Update the deadline label to say "Completed!"
                Label timerLabel = taskPanel.Controls.OfType<Label>().FirstOrDefault(l => l.Tag?.ToString() == "timer");

                if(timerLabel != null)
                {
                    timerLabel.Text = "Completed!";
                    timerLabel.ForeColor = Color.Green;
                }

                // Remove task from tracking deadlines
                taskDeadlines.Remove(taskPanel);
            }

            panel.Controls.Add(taskPanel);
            taskPanel.BringToFront();
        }

        private void ClearAllTasks()
        {
            foreach(FlowLayoutPanel panel in new FlowLayoutPanel[] { panelPlanned, panelInProgress, panelComplete })
            {
                panel.Controls.Clear();
                InitializeCategoryPanel(panel, panel == panelPlanned ? "Planned" : panel == panelInProgress ? "In-Progress" : "Complete");
            }

            File.Delete("tasks.json"); // Clear saved data...
        }

        private void SaveTasks()
        {
            var tasks = panelPlanned.Controls.OfType<Panel>().Select(taskPanel => new TaskData
            {
                Name = taskPanel.Controls.OfType<Label>().First().Text,
                Deadline = taskDeadlines.ContainsKey(taskPanel) ? taskDeadlines[taskPanel] : null,
                Category = "Planned"
            }).ToList();

            tasks.AddRange(panelInProgress.Controls.OfType<Panel>().Select(taskPanel => new TaskData
            {
                Name = taskPanel.Controls.OfType<Label>().First().Text,
                Deadline = taskDeadlines.ContainsKey(taskPanel) ? taskDeadlines[taskPanel] : null,
                Category = "InProgress"
            }));

            tasks.AddRange(panelComplete.Controls.OfType<Panel>().Select(taskPanel => new TaskData
            {
                Name = taskPanel.Controls.OfType<Label>().First().Text,
                Deadline = taskDeadlines.ContainsKey(taskPanel) ? taskDeadlines[taskPanel] : null,
                Category = "Complete"
            }));

            File.WriteAllText("tasks.json", JsonConvert.SerializeObject(tasks));
        }

        private void LoadTasks()
        {
            if(File.Exists("tasks.json"))
            {
                var tasks = JsonConvert.DeserializeObject<List<TaskData>>(File.ReadAllText("tasks.json"));

                foreach(var task in tasks)
                {
                    Panel taskPanel = CreateTaskPanel(task.Name, "", task.Deadline);
                    FlowLayoutPanel targetPanel = task.Category == "InProgress" ? panelInProgress :
                                                  task.Category == "Complete" ? panelComplete : panelPlanned;
                    AddTaskToPanel(targetPanel, taskPanel);
                }
            }
        }

        /*private void SaveTasks()
        {
            List<TaskData> tasks = new List<TaskData>();

            foreach(FlowLayoutPanel panel in new FlowLayoutPanel[] { panelPlanned, panelInProgress, panelComplete })
            {
                string category = panel == panelPlanned ? "Planned" : panel == panelInProgress ? "In-Progress" : "Complete";

                foreach(Control ctrl in panel.Controls)
                {
                    if(ctrl is Panel taskPanel)
                    {
                        Label taskNameLabel = taskPanel.Controls.OfType<Label>().FirstOrDefault();
                        Label taskDescLabel = taskPanel.Controls.OfType<Label>().Skip(1).FirstOrDefault();

                        if(taskNameLabel != null)
                        {
                            tasks.Add(new TaskData
                            {
                                Name = taskNameLabel.Text,
                                Description = taskDescLabel?.Text ?? "",
                                Category = category
                            });
                        }
                    }
                }
            }

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(tasks, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("tasks.json", json);
        }

        private void LoadTasks()
        {
            if(File.Exists("tasks.json"))
            {
                string json = File.ReadAllText("tasks.json");
                List<TaskData> tasks = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TaskData>>(json);

                foreach(TaskData task in tasks)
                {
                    Panel taskPanel = CreateTaskPanel(task.Name, task.Description,);
                    FlowLayoutPanel targetPanel = task.Category == "Planned" ? panelPlanned : task.Category == "In-Progress" ? panelInProgress : panelComplete;

                    AddTaskToPanel(targetPanel, taskPanel);
                }
            }
        }*/

        private void clearTasksButton_Click(object sender, EventArgs e)
        {
            // Show a confirmation dialog to the user...
            DialogResult result = MessageBox.Show("Are you sure you want to clear all tasks?", "Clear All Tasks?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(result == DialogResult.Yes)
            {
                // Clear all tasks if the user confirms...
                ClearAllTasks();
            }

            txtTaskName.Text = null;
            rtbTaskDescription.Text = null;
        }
    }
}