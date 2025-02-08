using System.Drawing;
using System.Windows.Forms;
using TASKYR.Properties;

namespace TASKYR
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blockButton = new System.Windows.Forms.Button();
            this.browserComboBox = new System.Windows.Forms.ComboBox();
            this.defaultBrowserLabel = new System.Windows.Forms.Label();
            this.addProgramButton = new System.Windows.Forms.Button();
            this.blockedProgramsLabel = new System.Windows.Forms.Label();
            this.blockedWebsitesLabel = new System.Windows.Forms.Label();
            this.blockedProgramsListBox = new System.Windows.Forms.ListBox();
            this.blockedWebsitesListBox = new System.Windows.Forms.ListBox();
            this.statusText = new System.Windows.Forms.Label();
            this.addWebsiteButton = new System.Windows.Forms.Button();
            this.addWebsiteTextBox = new System.Windows.Forms.TextBox();
            this.optionsLabel = new System.Windows.Forms.Label();
            this.removeProgramButton = new System.Windows.Forms.Button();
            this.removeWebsiteButton = new System.Windows.Forms.Button();
            this.configureScheduleButton = new System.Windows.Forms.Button();
            this.useScheduleCheckBox = new System.Windows.Forms.CheckBox();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.addToStartupCheckBox = new System.Windows.Forms.CheckBox();
            this.minimizeToTrayCheckBox = new System.Windows.Forms.CheckBox();
            this.coffeeBreakButton = new System.Windows.Forms.Button();
            this.taskBoardButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Click to show TASKYR!";
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(94, 26);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // blockButton
            // 
            this.blockButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.blockButton.FlatAppearance.BorderSize = 0;
            this.blockButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.blockButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blockButton.ForeColor = System.Drawing.Color.White;
            this.blockButton.Location = new System.Drawing.Point(279, 388);
            this.blockButton.Name = "blockButton";
            this.blockButton.Size = new System.Drawing.Size(243, 50);
            this.blockButton.TabIndex = 0;
            this.blockButton.Text = "Start Working!";
            this.blockButton.UseVisualStyleBackColor = false;
            this.blockButton.Click += new System.EventHandler(this.blockButton_Click);
            // 
            // browserComboBox
            // 
            this.browserComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.browserComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.browserComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.browserComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.browserComboBox.ForeColor = System.Drawing.Color.White;
            this.browserComboBox.FormattingEnabled = true;
            this.browserComboBox.Location = new System.Drawing.Point(30, 100);
            this.browserComboBox.Name = "browserComboBox";
            this.browserComboBox.Size = new System.Drawing.Size(162, 21);
            this.browserComboBox.TabIndex = 1;
            this.browserComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.browserComboBox_DrawItem);
            this.browserComboBox.SelectedIndexChanged += new System.EventHandler(this.browserComboBox_SelectedIndexChanged);
            // 
            // defaultBrowserLabel
            // 
            this.defaultBrowserLabel.AutoSize = true;
            this.defaultBrowserLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultBrowserLabel.Location = new System.Drawing.Point(46, 81);
            this.defaultBrowserLabel.Name = "defaultBrowserLabel";
            this.defaultBrowserLabel.Size = new System.Drawing.Size(125, 15);
            this.defaultBrowserLabel.TabIndex = 2;
            this.defaultBrowserLabel.Text = "Default web browser";
            this.defaultBrowserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addProgramButton
            // 
            this.addProgramButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.addProgramButton.FlatAppearance.BorderSize = 0;
            this.addProgramButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addProgramButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addProgramButton.ForeColor = System.Drawing.Color.White;
            this.addProgramButton.Location = new System.Drawing.Point(269, 216);
            this.addProgramButton.Name = "addProgramButton";
            this.addProgramButton.Size = new System.Drawing.Size(156, 36);
            this.addProgramButton.TabIndex = 3;
            this.addProgramButton.Text = "Add Program!";
            this.addProgramButton.UseVisualStyleBackColor = false;
            this.addProgramButton.Click += new System.EventHandler(this.addProgramButton_Click);
            // 
            // blockedProgramsLabel
            // 
            this.blockedProgramsLabel.AutoSize = true;
            this.blockedProgramsLabel.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blockedProgramsLabel.Location = new System.Drawing.Point(265, 18);
            this.blockedProgramsLabel.Name = "blockedProgramsLabel";
            this.blockedProgramsLabel.Size = new System.Drawing.Size(151, 19);
            this.blockedProgramsLabel.TabIndex = 4;
            this.blockedProgramsLabel.Text = "Blocked Programs";
            // 
            // blockedWebsitesLabel
            // 
            this.blockedWebsitesLabel.AutoSize = true;
            this.blockedWebsitesLabel.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blockedWebsitesLabel.Location = new System.Drawing.Point(600, 18);
            this.blockedWebsitesLabel.Name = "blockedWebsitesLabel";
            this.blockedWebsitesLabel.Size = new System.Drawing.Size(146, 19);
            this.blockedWebsitesLabel.TabIndex = 6;
            this.blockedWebsitesLabel.Text = "Blocked Websites";
            // 
            // blockedProgramsListBox
            // 
            this.blockedProgramsListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.blockedProgramsListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.blockedProgramsListBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blockedProgramsListBox.ForeColor = System.Drawing.Color.White;
            this.blockedProgramsListBox.FormattingEnabled = true;
            this.blockedProgramsListBox.ItemHeight = 16;
            this.blockedProgramsListBox.Location = new System.Drawing.Point(251, 42);
            this.blockedProgramsListBox.Name = "blockedProgramsListBox";
            this.blockedProgramsListBox.Size = new System.Drawing.Size(187, 160);
            this.blockedProgramsListBox.TabIndex = 7;
            // 
            // blockedWebsitesListBox
            // 
            this.blockedWebsitesListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.blockedWebsitesListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.blockedWebsitesListBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blockedWebsitesListBox.ForeColor = System.Drawing.Color.White;
            this.blockedWebsitesListBox.FormattingEnabled = true;
            this.blockedWebsitesListBox.ItemHeight = 16;
            this.blockedWebsitesListBox.Location = new System.Drawing.Point(576, 42);
            this.blockedWebsitesListBox.Name = "blockedWebsitesListBox";
            this.blockedWebsitesListBox.Size = new System.Drawing.Size(187, 160);
            this.blockedWebsitesListBox.TabIndex = 8;
            // 
            // statusText
            // 
            this.statusText.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.statusText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.statusText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusText.ForeColor = System.Drawing.Color.White;
            this.statusText.Location = new System.Drawing.Point(12, 355);
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(776, 19);
            this.statusText.TabIndex = 9;
            this.statusText.Text = "You\'ve been working for 10 minutes and 60 seconds";
            this.statusText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addWebsiteButton
            // 
            this.addWebsiteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.addWebsiteButton.FlatAppearance.BorderSize = 0;
            this.addWebsiteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addWebsiteButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addWebsiteButton.ForeColor = System.Drawing.Color.White;
            this.addWebsiteButton.Location = new System.Drawing.Point(590, 263);
            this.addWebsiteButton.Name = "addWebsiteButton";
            this.addWebsiteButton.Size = new System.Drawing.Size(156, 36);
            this.addWebsiteButton.TabIndex = 10;
            this.addWebsiteButton.Text = "Add Website!";
            this.addWebsiteButton.UseVisualStyleBackColor = false;
            this.addWebsiteButton.Click += new System.EventHandler(this.addWebsiteButton_Click);
            // 
            // addWebsiteTextBox
            // 
            this.addWebsiteTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.addWebsiteTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.addWebsiteTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addWebsiteTextBox.ForeColor = System.Drawing.Color.White;
            this.addWebsiteTextBox.Location = new System.Drawing.Point(576, 233);
            this.addWebsiteTextBox.Name = "addWebsiteTextBox";
            this.addWebsiteTextBox.Size = new System.Drawing.Size(187, 19);
            this.addWebsiteTextBox.TabIndex = 11;
            // 
            // optionsLabel
            // 
            this.optionsLabel.AutoSize = true;
            this.optionsLabel.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionsLabel.Location = new System.Drawing.Point(78, 53);
            this.optionsLabel.Name = "optionsLabel";
            this.optionsLabel.Size = new System.Drawing.Size(69, 19);
            this.optionsLabel.TabIndex = 12;
            this.optionsLabel.Text = "Options";
            // 
            // removeProgramButton
            // 
            this.removeProgramButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.removeProgramButton.FlatAppearance.BorderSize = 0;
            this.removeProgramButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeProgramButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeProgramButton.ForeColor = System.Drawing.Color.White;
            this.removeProgramButton.Location = new System.Drawing.Point(251, 258);
            this.removeProgramButton.Name = "removeProgramButton";
            this.removeProgramButton.Size = new System.Drawing.Size(187, 36);
            this.removeProgramButton.TabIndex = 13;
            this.removeProgramButton.Text = "Remove Program...";
            this.removeProgramButton.UseVisualStyleBackColor = false;
            this.removeProgramButton.Click += new System.EventHandler(this.removeProgramButton_Click);
            // 
            // removeWebsiteButton
            // 
            this.removeWebsiteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.removeWebsiteButton.FlatAppearance.BorderSize = 0;
            this.removeWebsiteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeWebsiteButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeWebsiteButton.ForeColor = System.Drawing.Color.White;
            this.removeWebsiteButton.Location = new System.Drawing.Point(576, 305);
            this.removeWebsiteButton.Name = "removeWebsiteButton";
            this.removeWebsiteButton.Size = new System.Drawing.Size(187, 36);
            this.removeWebsiteButton.TabIndex = 14;
            this.removeWebsiteButton.Text = "Remove Website...";
            this.removeWebsiteButton.UseVisualStyleBackColor = false;
            this.removeWebsiteButton.Click += new System.EventHandler(this.removeWebsiteButton_Click);
            // 
            // configureScheduleButton
            // 
            this.configureScheduleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.configureScheduleButton.FlatAppearance.BorderSize = 0;
            this.configureScheduleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.configureScheduleButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.configureScheduleButton.ForeColor = System.Drawing.Color.White;
            this.configureScheduleButton.Location = new System.Drawing.Point(30, 202);
            this.configureScheduleButton.Name = "configureScheduleButton";
            this.configureScheduleButton.Size = new System.Drawing.Size(141, 40);
            this.configureScheduleButton.TabIndex = 15;
            this.configureScheduleButton.Text = "Schedule...";
            this.configureScheduleButton.UseVisualStyleBackColor = false;
            this.configureScheduleButton.Click += new System.EventHandler(this.configureScheduleButton_Click);
            // 
            // useScheduleCheckBox
            // 
            this.useScheduleCheckBox.AutoSize = true;
            this.useScheduleCheckBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useScheduleCheckBox.Location = new System.Drawing.Point(30, 127);
            this.useScheduleCheckBox.Name = "useScheduleCheckBox";
            this.useScheduleCheckBox.Size = new System.Drawing.Size(103, 19);
            this.useScheduleCheckBox.TabIndex = 16;
            this.useScheduleCheckBox.Text = "Use schedule";
            this.useScheduleCheckBox.UseVisualStyleBackColor = true;
            this.useScheduleCheckBox.CheckedChanged += new System.EventHandler(this.useScheduleCheckBox_CheckedChanged);
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.saveSettingsButton.FlatAppearance.BorderSize = 0;
            this.saveSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveSettingsButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveSettingsButton.ForeColor = System.Drawing.Color.White;
            this.saveSettingsButton.Location = new System.Drawing.Point(30, 252);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(143, 42);
            this.saveSettingsButton.TabIndex = 17;
            this.saveSettingsButton.Text = "Save Settings!";
            this.saveSettingsButton.UseVisualStyleBackColor = false;
            this.saveSettingsButton.Visible = false;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // addToStartupCheckBox
            // 
            this.addToStartupCheckBox.AutoSize = true;
            this.addToStartupCheckBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addToStartupCheckBox.Location = new System.Drawing.Point(30, 177);
            this.addToStartupCheckBox.Name = "addToStartupCheckBox";
            this.addToStartupCheckBox.Size = new System.Drawing.Size(106, 19);
            this.addToStartupCheckBox.TabIndex = 19;
            this.addToStartupCheckBox.Text = "Add to startup";
            this.addToStartupCheckBox.UseVisualStyleBackColor = true;
            this.addToStartupCheckBox.CheckedChanged += new System.EventHandler(this.addToStartupCheckBox_CheckedChanged);
            // 
            // minimizeToTrayCheckBox
            // 
            this.minimizeToTrayCheckBox.AutoSize = true;
            this.minimizeToTrayCheckBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizeToTrayCheckBox.Location = new System.Drawing.Point(30, 152);
            this.minimizeToTrayCheckBox.Name = "minimizeToTrayCheckBox";
            this.minimizeToTrayCheckBox.Size = new System.Drawing.Size(115, 19);
            this.minimizeToTrayCheckBox.TabIndex = 20;
            this.minimizeToTrayCheckBox.Text = "Minimize to tray";
            this.minimizeToTrayCheckBox.UseVisualStyleBackColor = true;
            this.minimizeToTrayCheckBox.CheckedChanged += new System.EventHandler(this.minimizeToTrayCheckBox_CheckedChanged);
            // 
            // coffeeBreakButton
            // 
            this.coffeeBreakButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.coffeeBreakButton.FlatAppearance.BorderSize = 0;
            this.coffeeBreakButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.coffeeBreakButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coffeeBreakButton.ForeColor = System.Drawing.Color.White;
            this.coffeeBreakButton.Location = new System.Drawing.Point(30, 388);
            this.coffeeBreakButton.Name = "coffeeBreakButton";
            this.coffeeBreakButton.Size = new System.Drawing.Size(175, 50);
            this.coffeeBreakButton.TabIndex = 21;
            this.coffeeBreakButton.Text = "Coffee Break!";
            this.coffeeBreakButton.UseVisualStyleBackColor = false;
            this.coffeeBreakButton.Click += new System.EventHandler(this.coffeeBreakButton_Click);
            // 
            // taskBoardButton
            // 
            this.taskBoardButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.taskBoardButton.FlatAppearance.BorderSize = 0;
            this.taskBoardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.taskBoardButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taskBoardButton.ForeColor = System.Drawing.Color.White;
            this.taskBoardButton.Location = new System.Drawing.Point(576, 388);
            this.taskBoardButton.Name = "taskBoardButton";
            this.taskBoardButton.Size = new System.Drawing.Size(175, 50);
            this.taskBoardButton.TabIndex = 22;
            this.taskBoardButton.Text = "Taskboard...";
            this.taskBoardButton.UseVisualStyleBackColor = false;
            this.taskBoardButton.Click += new System.EventHandler(this.taskBoardButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(622, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "Website URL:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.taskBoardButton);
            this.Controls.Add(this.coffeeBreakButton);
            this.Controls.Add(this.minimizeToTrayCheckBox);
            this.Controls.Add(this.addToStartupCheckBox);
            this.Controls.Add(this.saveSettingsButton);
            this.Controls.Add(this.useScheduleCheckBox);
            this.Controls.Add(this.configureScheduleButton);
            this.Controls.Add(this.removeWebsiteButton);
            this.Controls.Add(this.removeProgramButton);
            this.Controls.Add(this.optionsLabel);
            this.Controls.Add(this.addWebsiteTextBox);
            this.Controls.Add(this.addWebsiteButton);
            this.Controls.Add(this.statusText);
            this.Controls.Add(this.blockedWebsitesListBox);
            this.Controls.Add(this.blockedProgramsListBox);
            this.Controls.Add(this.blockedWebsitesLabel);
            this.Controls.Add(this.blockedProgramsLabel);
            this.Controls.Add(this.addProgramButton);
            this.Controls.Add(this.defaultBrowserLabel);
            this.Controls.Add(this.browserComboBox);
            this.Controls.Add(this.blockButton);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "TASKYR";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private void browserComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if(e.Index < 0) return;

            // Set default background and text colors
            e.DrawBackground();
            Brush textBrush = Brushes.White;
            Color backgroundColor = Color.FromArgb(60, 60, 60);

            // Highlight selected item
            if((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                backgroundColor = Color.FromArgb(80, 80, 80);
            }

            // Fill background (no border)
            e.Graphics.FillRectangle(new SolidBrush(backgroundColor), e.Bounds);
            string itemText = ((ComboBox)sender).Items[e.Index].ToString();
            e.Graphics.DrawString(itemText, e.Font, textBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.CheckBox addToStartupCheckBox;
        private System.Windows.Forms.Button blockButton;
        private System.Windows.Forms.ComboBox browserComboBox;
        private System.Windows.Forms.Label defaultBrowserLabel;
        private System.Windows.Forms.Button addProgramButton;
        private System.Windows.Forms.Label blockedProgramsLabel;
        private System.Windows.Forms.Label blockedWebsitesLabel;
        private System.Windows.Forms.ListBox blockedProgramsListBox;
        private System.Windows.Forms.ListBox blockedWebsitesListBox;
        private System.Windows.Forms.Label statusText;
        private System.Windows.Forms.Button addWebsiteButton;
        private System.Windows.Forms.TextBox addWebsiteTextBox;
        private System.Windows.Forms.Label optionsLabel;
        private System.Windows.Forms.Button removeProgramButton;
        private System.Windows.Forms.Button removeWebsiteButton;
        private System.Windows.Forms.Button configureScheduleButton;
        private System.Windows.Forms.CheckBox useScheduleCheckBox;
        private System.Windows.Forms.Button saveSettingsButton;
        private System.Windows.Forms.CheckBox minimizeToTrayCheckBox;
        private System.Windows.Forms.Button coffeeBreakButton;
        private Button taskBoardButton;
        private Label label1;
    }
}

