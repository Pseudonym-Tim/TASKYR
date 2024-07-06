using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TASKYR
{
    public partial class SelectProcessForm : Form
    {
        public string SelectedProcess { get; private set; }

        public SelectProcessForm(List<string> processes)
        {
            InitializeComponent();
            processesListBox.Items.AddRange(processes.ToArray());
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            if(processesListBox.SelectedItem != null)
            {
                SelectedProcess = processesListBox.SelectedItem.ToString();
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please select a process.");
            }
        }
    }
}
