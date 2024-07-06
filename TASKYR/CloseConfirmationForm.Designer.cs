// CloseConfirmationForm.Designer.cs
using System.Windows.Forms;

namespace TASKYR
{
    partial class CloseConfirmationForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.confirmButton = new System.Windows.Forms.Button();
            this.confirmationTextBox = new System.Windows.Forms.TextBox();
            this.requiredTextLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(362, 225);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 0;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // confirmationTextBox
            // 
            this.confirmationTextBox.Location = new System.Drawing.Point(12, 170);
            this.confirmationTextBox.Multiline = true;
            this.confirmationTextBox.Name = "confirmationTextBox";
            this.confirmationTextBox.Size = new System.Drawing.Size(776, 49);
            this.confirmationTextBox.TabIndex = 1;
            this.confirmationTextBox.ContextMenu = new ContextMenu(); // (Prevent windows context menu from opening)
            this.confirmationTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.confirmationTextBox_KeyDown);
            // 
            // requiredTextLabel
            // 
            this.requiredTextLabel.AutoSize = true;
            this.requiredTextLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requiredTextLabel.Location = new System.Drawing.Point(12, 9);
            this.requiredTextLabel.MaximumSize = new System.Drawing.Size(776, 150);
            this.requiredTextLabel.Name = "requiredTextLabel";
            this.requiredTextLabel.Size = new System.Drawing.Size(0, 15);
            this.requiredTextLabel.TabIndex = 2;
            // 
            // CloseConfirmationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 262);
            this.Controls.Add(this.requiredTextLabel);
            this.Controls.Add(this.confirmationTextBox);
            this.Controls.Add(this.confirmButton);
            this.Name = "CloseConfirmationForm";
            this.Text = "Close Confirmation";
            this.Load += new System.EventHandler(this.CloseConfirmationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.TextBox confirmationTextBox;
        private System.Windows.Forms.Label requiredTextLabel;
    }
}
