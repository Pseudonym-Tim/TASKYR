namespace TASKYR
{
    partial class SelectProcessForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox processesListBox;
        private System.Windows.Forms.Button selectButton;

        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.processesListBox = new System.Windows.Forms.ListBox();
            this.selectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // processesListBox
            // 
            this.processesListBox.FormattingEnabled = true;
            this.processesListBox.Location = new System.Drawing.Point(12, 12);
            this.processesListBox.Name = "processesListBox";
            this.processesListBox.Size = new System.Drawing.Size(260, 186);
            this.processesListBox.TabIndex = 0;
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(197, 204);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(75, 23);
            this.selectButton.TabIndex = 1;
            this.selectButton.Text = "Select";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // SelectProcessForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 239);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.processesListBox);
            this.Name = "SelectProcessForm";
            this.Text = "Select Process";
            this.ResumeLayout(false);
        }
    }
}
