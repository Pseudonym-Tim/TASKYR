namespace TASKYR
{
    partial class ScheduleForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button saveButton;

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
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(250, 399);
            this.saveButton.Margin = new System.Windows.Forms.Padding(2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 40);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // ScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ScheduleForm";
            this.Text = "Configure Schedule";
            this.Load += new System.EventHandler(this.ScheduleForm_Load);
            this.ResumeLayout(false);

        }

        // Commenting out the Resize event handler since resizing is disabled
        //private void ScheduleForm_Resize(object sender, System.EventArgs e)
        //{
        //    CenterSaveButton();
        //}

        //private void CenterSaveButton()
        //{
        //    if(this.saveButton != null)
        //    {
        //        this.saveButton.Location = new System.Drawing.Point(
        //            (this.ClientSize.Width - this.saveButton.Width) / 2,
        //            this.ClientSize.Height - 70);
        //    }
        //}
    }
}
