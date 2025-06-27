using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;


namespace Cybersecurity_Chatbot.Forms
{
    public partial class CyberTaskForm : Form
    {
        private List<TaskItem> taskList = new List<TaskItem>();
        private readonly string taskFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tasks.json");

        public CyberTaskForm()
        {
            InitializeComponent();
        }

        public CyberTaskForm(TaskItem prefillTask) : this()
        {
            if (prefillTask != null)
            {
                textBoxTitle.Text = prefillTask.Title;
                Description.Text = prefillTask.Description;
                if (prefillTask.Reminder.HasValue)
                {
                    checkBoxSetReminder.Checked = true;
                    dateTimePickerReminder.Enabled = true;
                    dateTimePickerReminder.Value = prefillTask.Reminder.Value;
                }
            }
        }


        private void checkBoxSetReminder_CheckedChanged(object sender, EventArgs e)
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
        private void btnDeleteCompleted_Click(object sender, EventArgs e)
        {
            int removedCount = taskList.RemoveAll(t => t.IsCompleted);
            if (removedCount == 0)
            {
                MessageBox.Show("There are no completed tasks to delete.", "Nothing to Remove", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            SaveTasksToFile();
            UpdateTaskListDisplay();
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
                string display = $"{(task.IsCompleted ? "[✓] " : "")}{task.Title} - {task.Description}";
                if (task.Reminder.HasValue)
                    display += $" | Reminder: {task.Reminder.Value:yyyy-MM-dd HH:mm}";
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

        private void SaveTasksToFile()
        {
            try
            {
                string json = JsonConvert.SerializeObject(taskList, Formatting.Indented);
                File.WriteAllText(taskFilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving tasks: " + ex.Message);
            }
        }

        private void LoadTasksFromFile()
        {
            try
            {
                if (File.Exists(taskFilePath))
                {
                    string json = File.ReadAllText(taskFilePath);
                    taskList = JsonConvert.DeserializeObject<List<TaskItem>>(json) ?? new List<TaskItem>();
                    UpdateTaskListDisplay();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tasks: " + ex.Message);
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
}
