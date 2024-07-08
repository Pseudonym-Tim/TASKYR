using System.Drawing;
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
            this.blockButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blockButton.Location = new System.Drawing.Point(279, 388);
            this.blockButton.Name = "blockButton";
            this.blockButton.Size = new System.Drawing.Size(243, 50);
            this.blockButton.TabIndex = 0;
            this.blockButton.Text = "Start Working!";
            this.blockButton.UseVisualStyleBackColor = true;
            this.blockButton.Click += new System.EventHandler(this.blockButton_Click);
            // 
            // browserComboBox
            // 
            this.browserComboBox.FormattingEnabled = true;
            this.browserComboBox.Location = new System.Drawing.Point(30, 100);
            this.browserComboBox.Name = "browserComboBox";
            this.browserComboBox.Size = new System.Drawing.Size(162, 21);
            this.browserComboBox.TabIndex = 1;
            this.browserComboBox.SelectedIndexChanged += new System.EventHandler(this.browserComboBox_SelectedIndexChanged);
            // 
            // defaultBrowserLabel
            // 
            this.defaultBrowserLabel.AutoSize = true;
            this.defaultBrowserLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultBrowserLabel.Location = new System.Drawing.Point(48, 82);
            this.defaultBrowserLabel.Name = "defaultBrowserLabel";
            this.defaultBrowserLabel.Size = new System.Drawing.Size(125, 15);
            this.defaultBrowserLabel.TabIndex = 2;
            this.defaultBrowserLabel.Text = "Default web browser";
            this.defaultBrowserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addProgramButton
            // 
            this.addProgramButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addProgramButton.Location = new System.Drawing.Point(269, 232);
            this.addProgramButton.Name = "addProgramButton";
            this.addProgramButton.Size = new System.Drawing.Size(156, 36);
            this.addProgramButton.TabIndex = 3;
            this.addProgramButton.Text = "Add program...";
            this.addProgramButton.UseVisualStyleBackColor = true;
            this.addProgramButton.Click += new System.EventHandler(this.addProgramButton_Click);
            // 
            // blockedProgramsLabel
            // 
            this.blockedProgramsLabel.AutoSize = true;
            this.blockedProgramsLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blockedProgramsLabel.Location = new System.Drawing.Point(247, 18);
            this.blockedProgramsLabel.Name = "blockedProgramsLabel";
            this.blockedProgramsLabel.Size = new System.Drawing.Size(150, 19);
            this.blockedProgramsLabel.TabIndex = 4;
            this.blockedProgramsLabel.Text = "Blocked programs";
            // 
            // blockedWebsitesLabel
            // 
            this.blockedWebsitesLabel.AutoSize = true;
            this.blockedWebsitesLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blockedWebsitesLabel.Location = new System.Drawing.Point(572, 18);
            this.blockedWebsitesLabel.Name = "blockedWebsitesLabel";
            this.blockedWebsitesLabel.Size = new System.Drawing.Size(144, 19);
            this.blockedWebsitesLabel.TabIndex = 6;
            this.blockedWebsitesLabel.Text = "Blocked websites";
            // 
            // blockedProgramsListBox
            // 
            this.blockedProgramsListBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blockedProgramsListBox.FormattingEnabled = true;
            this.blockedProgramsListBox.ItemHeight = 16;
            this.blockedProgramsListBox.Location = new System.Drawing.Point(251, 40);
            this.blockedProgramsListBox.Name = "blockedProgramsListBox";
            this.blockedProgramsListBox.Size = new System.Drawing.Size(187, 180);
            this.blockedProgramsListBox.TabIndex = 7;
            // 
            // blockedWebsitesListBox
            // 
            this.blockedWebsitesListBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blockedWebsitesListBox.FormattingEnabled = true;
            this.blockedWebsitesListBox.ItemHeight = 16;
            this.blockedWebsitesListBox.Location = new System.Drawing.Point(576, 40);
            this.blockedWebsitesListBox.Name = "blockedWebsitesListBox";
            this.blockedWebsitesListBox.Size = new System.Drawing.Size(187, 180);
            this.blockedWebsitesListBox.TabIndex = 8;
            // 
            // statusText
            // 
            this.statusText.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.statusText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusText.Location = new System.Drawing.Point(12, 355);
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(776, 19);
            this.statusText.TabIndex = 9;
            this.statusText.Text = "You\'ve been working for 10 minutes and 60 seconds";
            this.statusText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addWebsiteButton
            // 
            this.addWebsiteButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addWebsiteButton.Location = new System.Drawing.Point(590, 258);
            this.addWebsiteButton.Name = "addWebsiteButton";
            this.addWebsiteButton.Size = new System.Drawing.Size(156, 36);
            this.addWebsiteButton.TabIndex = 10;
            this.addWebsiteButton.Text = "Add website!";
            this.addWebsiteButton.UseVisualStyleBackColor = true;
            this.addWebsiteButton.Click += new System.EventHandler(this.addWebsiteButton_Click);
            // 
            // addWebsiteTextBox
            // 
            this.addWebsiteTextBox.Location = new System.Drawing.Point(590, 232);
            this.addWebsiteTextBox.Name = "addWebsiteTextBox";
            this.addWebsiteTextBox.Size = new System.Drawing.Size(156, 20);
            this.addWebsiteTextBox.TabIndex = 11;
            // 
            // optionsLabel
            // 
            this.optionsLabel.AutoSize = true;
            this.optionsLabel.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionsLabel.Location = new System.Drawing.Point(72, 40);
            this.optionsLabel.Name = "optionsLabel";
            this.optionsLabel.Size = new System.Drawing.Size(69, 19);
            this.optionsLabel.TabIndex = 12;
            this.optionsLabel.Text = "Options";
            // 
            // removeProgramButton
            // 
            this.removeProgramButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeProgramButton.Location = new System.Drawing.Point(269, 274);
            this.removeProgramButton.Name = "removeProgramButton";
            this.removeProgramButton.Size = new System.Drawing.Size(156, 36);
            this.removeProgramButton.TabIndex = 13;
            this.removeProgramButton.Text = "Remove program";
            this.removeProgramButton.UseVisualStyleBackColor = true;
            this.removeProgramButton.Click += new System.EventHandler(this.removeProgramButton_Click);
            // 
            // removeWebsiteButton
            // 
            this.removeWebsiteButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeWebsiteButton.Location = new System.Drawing.Point(590, 300);
            this.removeWebsiteButton.Name = "removeWebsiteButton";
            this.removeWebsiteButton.Size = new System.Drawing.Size(156, 36);
            this.removeWebsiteButton.TabIndex = 14;
            this.removeWebsiteButton.Text = "Remove website";
            this.removeWebsiteButton.UseVisualStyleBackColor = true;
            this.removeWebsiteButton.Click += new System.EventHandler(this.removeWebsiteButton_Click);
            // 
            // configureScheduleButton
            // 
            this.configureScheduleButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.configureScheduleButton.Location = new System.Drawing.Point(30, 232);
            this.configureScheduleButton.Name = "configureScheduleButton";
            this.configureScheduleButton.Size = new System.Drawing.Size(141, 48);
            this.configureScheduleButton.TabIndex = 15;
            this.configureScheduleButton.Text = "Schedule...";
            this.configureScheduleButton.UseVisualStyleBackColor = true;
            this.configureScheduleButton.Click += new System.EventHandler(this.configureScheduleButton_Click);
            // 
            // useScheduleCheckBox
            // 
            this.useScheduleCheckBox.AutoSize = true;
            this.useScheduleCheckBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useScheduleCheckBox.Location = new System.Drawing.Point(30, 127);
            this.useScheduleCheckBox.Name = "useScheduleCheckBox";
            this.useScheduleCheckBox.Size = new System.Drawing.Size(104, 19);
            this.useScheduleCheckBox.TabIndex = 16;
            this.useScheduleCheckBox.Text = "Use Schedule";
            this.useScheduleCheckBox.UseVisualStyleBackColor = true;
            this.useScheduleCheckBox.CheckedChanged += new System.EventHandler(this.useScheduleCheckBox_CheckedChanged);
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.Hide(); // No longer needed, we autosave user settings now...
            this.saveSettingsButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveSettingsButton.Location = new System.Drawing.Point(30, 285);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(143, 42);
            this.saveSettingsButton.TabIndex = 17;
            this.saveSettingsButton.Text = "Save Settings!";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // addToStartupCheckBox
            // 
            this.addToStartupCheckBox.AutoSize = true;
            this.addToStartupCheckBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addToStartupCheckBox.Location = new System.Drawing.Point(30, 177);
            this.addToStartupCheckBox.Name = "addToStartupCheckBox";
            this.addToStartupCheckBox.Size = new System.Drawing.Size(107, 19);
            this.addToStartupCheckBox.TabIndex = 19;
            this.addToStartupCheckBox.Text = "Add to Startup";
            this.addToStartupCheckBox.UseVisualStyleBackColor = true;
            this.addToStartupCheckBox.CheckedChanged += new System.EventHandler(this.addToStartupCheckBox_CheckedChanged);
            // 
            // minimizeToTrayCheckBox
            // 
            this.minimizeToTrayCheckBox.AutoSize = true;
            this.minimizeToTrayCheckBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizeToTrayCheckBox.Location = new System.Drawing.Point(30, 152);
            this.minimizeToTrayCheckBox.Name = "minimizeToTrayCheckBox";
            this.minimizeToTrayCheckBox.Size = new System.Drawing.Size(117, 19);
            this.minimizeToTrayCheckBox.TabIndex = 20;
            this.minimizeToTrayCheckBox.Text = "Minimize to Tray";
            this.minimizeToTrayCheckBox.UseVisualStyleBackColor = true;
            this.minimizeToTrayCheckBox.CheckedChanged += new System.EventHandler(this.minimizeToTrayCheckBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "TASKYR";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
    }
}

