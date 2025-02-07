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
        public TaskBoardForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeCategoryPanel(panelPlanned, "Planned");
            InitializeCategoryPanel(panelInProgress, "In-Progress");
            InitializeCategoryPanel(panelComplete, "Complete");

            LoadTasks(); // Load saved tasks on startup...
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
            panel.WrapContents = false;  // (Prevents wrapping of tasks...)
        }

        private void btnCreateTask_Click(object sender, EventArgs e)
        {
            string taskName = txtTaskName.Text;
            string taskDescription = rtbTaskDescription.Text;

            if(!string.IsNullOrEmpty(taskName))
            {
                Panel newTask = CreateTaskPanel(taskName, taskDescription);
                AddTaskToPanel(panelPlanned, newTask);
                SaveTasks(); // Save after creating a new task...
            }
        }

        private Panel CreateTaskPanel(string taskName, string taskDescription)
        {
            // Create a new Panel to hold the task name and description...
            Panel taskPanel = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                MaximumSize = new Size(215, 9999),
                Padding = new Padding(10, 5, 10, 5), // Add padding to the left and right of the task...
                Margin = new Padding(5),
                BackColor = System.Drawing.Color.LightGray
            };

            bool taskDescriptionIsEmpty = string.IsNullOrEmpty(taskDescription);

            // Create a Label for the task name with larger font and underlined text...
            Label taskNameLabel = new Label
            {
                Text = taskName,
                AutoSize = true,
                Font = new Font("Arial", 12, taskDescriptionIsEmpty ? FontStyle.Bold : (FontStyle.Underline | FontStyle.Bold)), 
                ForeColor = System.Drawing.Color.Black,
                Padding = new Padding(0, 5, 0, 5) // Padding for spacing between labels...
            };

            // Create a Label for the task description only if it's not empty...
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

            // Add event handlers to propagate MouseDown event from labels to panel...
            taskNameLabel.MouseDown += (s, e) => TaskPanel_MouseDown(taskPanel, e);

            if(taskDescriptionLabel != null)
                taskDescriptionLabel.MouseDown += (s, e) => TaskPanel_MouseDown(taskPanel, e);

            // Add labels to the task panel...
            taskPanel.Controls.Add(taskNameLabel);

            if(taskDescriptionLabel != null)
                taskPanel.Controls.Add(taskDescriptionLabel);

            // Position the labels manually, starting from the top of the panel...
            int currentTop = taskNameLabel.Height + taskPanel.Padding.Top;

            if(taskDescriptionLabel != null)
            {
                taskDescriptionLabel.Top = currentTop;
                currentTop += taskDescriptionLabel.Height + 5; // Add some margin below the description...
            }

            // Set the panel's height based on the labels' heights...
            taskPanel.Height = currentTop + taskPanel.Padding.Bottom - 5;

            // Assign event handlers for dragging...
            taskPanel.MouseDown += TaskPanel_MouseDown;
            taskPanel.DragOver += TaskPanel_DragOver;

            return taskPanel;
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
            // Determine the background color based on the category panel...
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
            }

            // Add the taskPanel to the FlowLayoutPanel...
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
                    Panel taskPanel = CreateTaskPanel(task.Name, task.Description);
                    FlowLayoutPanel targetPanel = task.Category == "Planned" ? panelPlanned : task.Category == "In-Progress" ? panelInProgress : panelComplete;

                    AddTaskToPanel(targetPanel, taskPanel);
                }
            }
        }

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