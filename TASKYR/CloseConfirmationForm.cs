using System;
using System.Windows.Forms;

namespace TASKYR
{
    public partial class CloseConfirmationForm : Form
    {
        public bool IsConfirmed { get; private set; } = false;

        private const string RequiredText = "The procrastinator is often remarkably optimistic about his ability to complete a task on a tight deadline; this is usually accompanied by expressions of reassurance that everything is under control. (Therefore, there is no need to start.) Lulled by a false sense of security, time passes. At some point, he crosses over an imaginary starting time and suddenly realizes, \"Oh no! I am not in control! There isn't enough time!\"";

        public CloseConfirmationForm()
        {
            InitializeComponent();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if(confirmationTextBox.Text == RequiredText)
            {
                IsConfirmed = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("The text is incorrect. Try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                confirmationTextBox.Focus();
            }
        }

        private void CloseConfirmationForm_Load(object sender, EventArgs e)
        {
            requiredTextLabel.Text = RequiredText;
        }

        // Disable copy-paste via keyboard shortcuts...
        private void confirmationTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V || e.KeyCode == Keys.X))
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
