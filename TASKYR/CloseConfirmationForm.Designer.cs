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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CloseConfirmationForm));
            this.confirmButton = new System.Windows.Forms.Button();
            this.confirmationTextBox = new System.Windows.Forms.TextBox();
            this.requiredTextLabel = new System.Windows.Forms.Label();
            this.typeInstructionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // confirmButton
            // 
            this.confirmButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.confirmButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.confirmButton.FlatAppearance.BorderSize = 0;
            this.confirmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirmButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmButton.ForeColor = System.Drawing.Color.White;
            this.confirmButton.Location = new System.Drawing.Point(412, 233);
            this.confirmButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(117, 37);
            this.confirmButton.TabIndex = 0;
            this.confirmButton.Text = "Confirm!";
            this.confirmButton.UseVisualStyleBackColor = false;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // confirmationTextBox
            // 
            this.confirmationTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.confirmationTextBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmationTextBox.ForeColor = System.Drawing.Color.White;
            this.confirmationTextBox.Location = new System.Drawing.Point(13, 138);
            this.confirmationTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.confirmationTextBox.Multiline = true;
            this.confirmationTextBox.Name = "confirmationTextBox";
            this.confirmationTextBox.Size = new System.Drawing.Size(905, 83);
            this.confirmationTextBox.TabIndex = 1;
            this.confirmationTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.confirmationTextBox_KeyDown);
            // 
            // requiredTextLabel
            // 
            this.requiredTextLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requiredTextLabel.ForeColor = System.Drawing.Color.White;
            this.requiredTextLabel.Location = new System.Drawing.Point(13, 45);
            this.requiredTextLabel.Name = "requiredTextLabel";
            this.requiredTextLabel.Size = new System.Drawing.Size(905, 81);
            this.requiredTextLabel.TabIndex = 3;
            this.requiredTextLabel.Text = "You should never see this!";
            // 
            // typeInstructionLabel
            // 
            this.typeInstructionLabel.AutoSize = true;
            this.typeInstructionLabel.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeInstructionLabel.ForeColor = System.Drawing.Color.White;
            this.typeInstructionLabel.Location = new System.Drawing.Point(13, 9);
            this.typeInstructionLabel.Name = "typeInstructionLabel";
            this.typeInstructionLabel.Size = new System.Drawing.Size(385, 16);
            this.typeInstructionLabel.TabIndex = 4;
            this.typeInstructionLabel.Text = "Please type out the following text to deactivate work mode:";
            // 
            // CloseConfirmationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(933, 282);
            this.Controls.Add(this.typeInstructionLabel);
            this.Controls.Add(this.requiredTextLabel);
            this.Controls.Add(this.confirmationTextBox);
            this.Controls.Add(this.confirmButton);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "CloseConfirmationForm";
            this.Text = "Close Confirmation...";
            this.Load += new System.EventHandler(this.CloseConfirmationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.TextBox confirmationTextBox;
        private Label requiredTextLabel;
        private Label typeInstructionLabel;
    }
}
