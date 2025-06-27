using System;
using System.Collections.Generic;
using System.Linq;
using Cybersecurity_Chatbot.Classes;

namespace Cybersecurity_Chatbot.Classes
{
    public class CyberTaskManager
    {
        private class CyberTask
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime? Reminder { get; set; }
            public bool Completed { get; set; } = false;
        }

        private List<CyberTask> tasks = new List<CyberTask>();

        public void AddTask(string title, string description, DateTime? reminder)
        {
            tasks.Add(new CyberTask { Title = title, Description = description, Reminder = reminder });
            Console.WriteLine($"Chatbot: Task \"{title}\" added to your cybersecurity checklist.");
        }

        public void ListTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Chatbot: Your cybersecurity checklist is empty.");
                return;
            }

            Console.WriteLine("\n--- Your Cybersecurity Tasks ---");
            for (int i = 0; i < tasks.Count; i++)
            {
                var task = tasks[i];
                string status = task.Completed ? "[✓]" : "[ ]";
                string reminderText = task.Reminder.HasValue ? $" (Reminder: {task.Reminder.Value})" : "";
                Console.WriteLine($"{i + 1}. {status} {task.Title}{reminderText}\n   Description: {task.Description}");
            }
            Console.WriteLine("---------------------------------");
        }

        public void CompleteTask(int taskNumber)
        {
            if (taskNumber < 1 || taskNumber > tasks.Count)
            {
                Console.WriteLine("Chatbot: Invalid task number.");
                return;
            }

            tasks[taskNumber - 1].Completed = true;
            Console.WriteLine($"Chatbot: Marked \"{tasks[taskNumber - 1].Title}\" as completed.");
        }

        public void DeleteTask(int taskNumber)
        {
            if (taskNumber < 1 || taskNumber > tasks.Count)
            {
                Console.WriteLine("Chatbot: Invalid task number.");
                return;
            }

            var task = tasks[taskNumber - 1];
            tasks.RemoveAt(taskNumber - 1);
            Console.WriteLine($"Chatbot: Deleted task \"{task.Title}\".");
        }

        public void ClearCompleted()
        {
            int beforeCount = tasks.Count;
            tasks = tasks.Where(t => !t.Completed).ToList();
            Console.WriteLine($"Chatbot: Cleared {beforeCount - tasks.Count} completed task(s).");
        }
    }
}
