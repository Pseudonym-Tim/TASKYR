using System.Windows.Forms;

namespace TASKYR
{
    partial class TaskBoardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.rtbTaskDescription = new System.Windows.Forms.RichTextBox();
            this.btnCreateTask = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.clearTasksButton = new System.Windows.Forms.Button();
            this.plannedHeaderText = new System.Windows.Forms.Label();
            this.inProgressHeaderText = new System.Windows.Forms.Label();
            this.completedHeaderText = new System.Windows.Forms.Label();
            this.panelPlanned = new System.Windows.Forms.FlowLayoutPanel();
            this.panelInProgress = new System.Windows.Forms.FlowLayoutPanel();
            this.panelComplete = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // txtTaskName
            // 
            this.txtTaskName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtTaskName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTaskName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaskName.ForeColor = System.Drawing.Color.White;
            this.txtTaskName.Location = new System.Drawing.Point(117, 11);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(284, 19);
            this.txtTaskName.TabIndex = 3;
            // 
            // rtbTaskDescription
            // 
            this.rtbTaskDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.rtbTaskDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbTaskDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbTaskDescription.ForeColor = System.Drawing.Color.White;
            this.rtbTaskDescription.Location = new System.Drawing.Point(117, 43);
            this.rtbTaskDescription.Name = "rtbTaskDescription";
            this.rtbTaskDescription.Size = new System.Drawing.Size(284, 63);
            this.rtbTaskDescription.TabIndex = 4;
            this.rtbTaskDescription.Text = "";
            // 
            // btnCreateTask
            // 
            this.btnCreateTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnCreateTask.FlatAppearance.BorderSize = 0;
            this.btnCreateTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateTask.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateTask.ForeColor = System.Drawing.Color.White;
            this.btnCreateTask.Location = new System.Drawing.Point(417, 11);
            this.btnCreateTask.Name = "btnCreateTask";
            this.btnCreateTask.Size = new System.Drawing.Size(145, 45);
            this.btnCreateTask.TabIndex = 5;
            this.btnCreateTask.Text = "Create Task!";
            this.btnCreateTask.UseVisualStyleBackColor = false;
            this.btnCreateTask.Click += new System.EventHandler(this.btnCreateTask_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Task Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Description:";
            // 
            // clearTasksButton
            // 
            this.clearTasksButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.clearTasksButton.FlatAppearance.BorderSize = 0;
            this.clearTasksButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearTasksButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearTasksButton.ForeColor = System.Drawing.Color.White;
            this.clearTasksButton.Location = new System.Drawing.Point(629, 12);
            this.clearTasksButton.Name = "clearTasksButton";
            this.clearTasksButton.Size = new System.Drawing.Size(145, 45);
            this.clearTasksButton.TabIndex = 8;
            this.clearTasksButton.Text = "Wipe All Tasks!";
            this.clearTasksButton.UseVisualStyleBackColor = false;
            this.clearTasksButton.Click += new System.EventHandler(this.clearTasksButton_Click);
            // 
            // plannedHeaderText
            // 
            this.plannedHeaderText.BackColor = System.Drawing.Color.LightGray;
            this.plannedHeaderText.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plannedHeaderText.Location = new System.Drawing.Point(12, 120);
            this.plannedHeaderText.Name = "plannedHeaderText";
            this.plannedHeaderText.Size = new System.Drawing.Size(250, 30);
            this.plannedHeaderText.TabIndex = 0;
            this.plannedHeaderText.Text = "Planned";
            this.plannedHeaderText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // inProgressHeaderText
            // 
            this.inProgressHeaderText.BackColor = System.Drawing.Color.LightBlue;
            this.inProgressHeaderText.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inProgressHeaderText.Location = new System.Drawing.Point(268, 120);
            this.inProgressHeaderText.Name = "inProgressHeaderText";
            this.inProgressHeaderText.Size = new System.Drawing.Size(250, 30);
            this.inProgressHeaderText.TabIndex = 1;
            this.inProgressHeaderText.Text = "In Progress";
            this.inProgressHeaderText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // completedHeaderText
            // 
            this.completedHeaderText.BackColor = System.Drawing.Color.LightGreen;
            this.completedHeaderText.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completedHeaderText.Location = new System.Drawing.Point(524, 120);
            this.completedHeaderText.Name = "completedHeaderText";
            this.completedHeaderText.Size = new System.Drawing.Size(250, 30);
            this.completedHeaderText.TabIndex = 2;
            this.completedHeaderText.Text = "Completed";
            this.completedHeaderText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelPlanned
            // 
            this.panelPlanned.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panelPlanned.Location = new System.Drawing.Point(13, 154);
            this.panelPlanned.Name = "panelPlanned";
            this.panelPlanned.Size = new System.Drawing.Size(249, 295);
            this.panelPlanned.TabIndex = 9;
            // 
            // panelInProgress
            // 
            this.panelInProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panelInProgress.Location = new System.Drawing.Point(268, 154);
            this.panelInProgress.Name = "panelInProgress";
            this.panelInProgress.Size = new System.Drawing.Size(249, 295);
            this.panelInProgress.TabIndex = 10;
            // 
            // panelComplete
            // 
            this.panelComplete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panelComplete.Location = new System.Drawing.Point(523, 154);
            this.panelComplete.Name = "panelComplete";
            this.panelComplete.Size = new System.Drawing.Size(249, 295);
            this.panelComplete.TabIndex = 11;
            // 
            // TaskBoardForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.panelComplete);
            this.Controls.Add(this.panelInProgress);
            this.Controls.Add(this.panelPlanned);
            this.Controls.Add(this.completedHeaderText);
            this.Controls.Add(this.inProgressHeaderText);
            this.Controls.Add(this.plannedHeaderText);
            this.Controls.Add(this.clearTasksButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCreateTask);
            this.Controls.Add(this.rtbTaskDescription);
            this.Controls.Add(this.txtTaskName);
            this.Name = "TaskBoardForm";
            this.Text = "Taskboard";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private TextBox txtTaskName;
        private RichTextBox rtbTaskDescription;
        private Button btnCreateTask;

        #endregion

        private Label label1;
        private Label label2;
        private Button clearTasksButton;
        private Label plannedHeaderText;
        private Label inProgressHeaderText;
        private Label completedHeaderText;
        private FlowLayoutPanel panelPlanned;
        private FlowLayoutPanel panelInProgress;
        private FlowLayoutPanel panelComplete;
    }
}