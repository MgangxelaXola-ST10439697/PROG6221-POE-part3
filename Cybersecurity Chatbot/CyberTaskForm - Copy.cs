using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cybersecurity_Chatbot.Forms
{
    public partial class CyberTaskForm : Form
    {
        private List<TaskItem> taskList = new List<TaskItem>();

        public CyberTaskForm()
        {
            InitializeComponent();
        }

        private void chkSetReminder_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerReminder.Enabled = checkBoxSetReminder.Checked;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string title = textBoxTitle.Text.Trim();
            string description = Description.Text.Trim();
            DateTime? reminder = checkBoxSetReminder.Checked ? dateTimePickerReminder.Value : (DateTime?)null;

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Please enter a task title.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TaskItem newTask = new TaskItem { Title = title, Description = description, Reminder = reminder };
            taskList.Add(newTask);

            UpdateTaskListDisplay();
            ClearInputs();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxTasks.SelectedIndex >= 0)
            {
                taskList.RemoveAt(listBoxTasks.SelectedIndex);
                UpdateTaskListDisplay();
            }
            else
            {
                MessageBox.Show("Please select a task to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (listBoxTasks.SelectedIndex >= 0)
            {
                taskList[listBoxTasks.SelectedIndex].IsCompleted = true;
                UpdateTaskListDisplay();
            }
            else
            {
                MessageBox.Show("Please select a task to mark as completed.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateTaskListDisplay()
        {
            listBoxTasks.Items.Clear();
            foreach (var task in taskList)
            {
                string display = $"{task.Title} - {task.Description}";
                if (task.Reminder.HasValue)
                    display += $" | Reminder: {task.Reminder.Value.ToString("yyyy-MM-dd HH:mm")}";
                if (task.IsCompleted)
                    display += " [Completed]";

                listBoxTasks.Items.Add(display);
            }
        }

        private void ClearInputs()
        {
            textBoxTitle.Clear();
            Description.Clear();
            checkBoxSetReminder.Checked = false;
            dateTimePickerReminder.Value = DateTime.Now;
        }

        private void Description_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class TaskItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Reminder { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}


