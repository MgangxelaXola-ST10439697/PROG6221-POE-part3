using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Cybersecurity_Chatbot.Classes;
using Cybersecurity_Chatbot.Forms;


namespace Cybersecurity_Chatbot
{
    namespace Cybersecurity_Chatbot
    {
        public class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                string lastTopic = null;
                Random rand = new Random();
                ConversationMemory memory = new ConversationMemory();
                CyberTaskManager taskManager = new CyberTaskManager();
                ActivityLogger log = new ActivityLogger();

                Logo();

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("#############################################################");
                Console.WriteLine(" Welcome to the Cybersecurity Chatbot! Talk to me :)");
                Console.WriteLine("#############################################################");
                Console.ResetColor();

                try
                {
                    string soundFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "voiceMessage.wav");
                    if (File.Exists(soundFilePath))
                    {
                        using (SoundPlayer player = new SoundPlayer(soundFilePath))
                        {
                            player.PlaySync();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Audio not played: " + ex.Message);
                }

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("\n Please enter your name: ");
                Console.ResetColor();
                string userName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userName))
                    userName = "User";

                memory.UserName = userName;

                TypingEffect($"\n Hello, {userName}! I'm here to help you with cybersecurity questions.");
                TypingEffect("You can ask anything about cybersecurity—no need to be formal!");
                TypingEffect("Not sure where to start? Just type 'menu' and pick a topic you’re curious about.\n");
                TypingEffect("Type 'exit' or 'quit' to end the chat.\n");

                DisplayMenu();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"\n{userName}: ");
                    Console.ResetColor();
                    string userInput = Console.ReadLine()?.ToLower();

                    if (string.IsNullOrWhiteSpace(userInput))
                    {
                        TypingEffect("Chatbot: Can you please type a question?");
                        continue;
                    }

                    if (SentimentDetector.ContainsWorry(userInput))
                    {
                        TypingEffect("Chatbot: I sense you're worried. Take a deep breath—everything will be okay. You're not alone in this.");
                        TypingEffect("Chatbot: If there's anything specific making you feel this way, feel free to share. I'm here to help.");
                        log.Add("Recognized user worry and provided reassurance.");
                        continue;
                    }

                    if (userInput == "exit" || userInput == "quit")
                    {
                        TypingEffect($"Chatbot: Goodbye {memory.UserName}! Stay safe online.");
                        break;
                    }

                    if (userInput == "menu")
                    {
                        DisplayMenu();
                        continue;
                    }

                    if (userInput.Contains("quiz"))
                    {
                        TypingEffect("Chatbot: Launching the Cybersecurity Quiz...");
                        log.Add("Launched Cybersecurity Quiz.");
                        Application.Run(new CyberQuizForm());
                        continue;
                    }

                    if (userInput.Contains("task") || userInput.Contains("reminder") || userInput.Contains("set a reminder") || userInput.Contains("add a task"))
                    {
                        TypingEffect("Chatbot: Please enter the title of the task:");
                        Console.Write("Title: ");
                        string title = Console.ReadLine();

                        TypingEffect("Chatbot: Please enter a description for this task:");
                        Console.Write("Description: ");
                        string description = Console.ReadLine();

                        TypingEffect("Chatbot: Enter a reminder (optional, yyyy-MM-dd HH:mm or 'in 3 days'):");
                        Console.Write("Reminder: ");
                        string reminderInput = Console.ReadLine();

                        DateTime? reminder = null;
                        if (!string.IsNullOrWhiteSpace(reminderInput))
                        {
                            if (DateTime.TryParse(reminderInput, out DateTime parsed))
                                reminder = parsed;
                            else if (reminderInput.StartsWith("in "))
                            {
                                Match match = Regex.Match(reminderInput, @"in (\\d+) (day|days|hour|hours|minute|minutes)");
                                if (match.Success)
                                {
                                    int amount = int.Parse(match.Groups[1].Value);
                                    string unit = match.Groups[2].Value;

                                    switch (unit)
                                    {
                                        case "day":
                                        case "days": reminder = DateTime.Now.AddDays(amount); break;
                                        case "hour":
                                        case "hours": reminder = DateTime.Now.AddHours(amount); break;
                                        case "minute":
                                        case "minutes": reminder = DateTime.Now.AddMinutes(amount); break;
                                    }
                                }
                            }
                        }

                        taskManager.AddTask(title, description, reminder);
                        log.Add($"Task added: {title}");
                        continue;
                    }

                    if (userInput == "show tasks")
                    {
                        taskManager.ListTasks();
                        continue;
                    }

                    if (userInput.StartsWith("complete task "))
                    {
                        if (int.TryParse(userInput.Substring("complete task ".Length), out int num))
                        {
                            taskManager.CompleteTask(num);
                            log.Add($"Completed task #{num}");
                        }
                        else TypingEffect("Chatbot: Invalid task number.");
                        continue;
                    }

                    if (userInput.StartsWith("delete task "))
                    {
                        if (int.TryParse(userInput.Substring("delete task ".Length), out int num))
                        {
                            taskManager.DeleteTask(num);
                            log.Add($"Deleted task #{num}");
                        }
                        else TypingEffect("Chatbot: Invalid task number.");
                        continue;
                    }

                    if (userInput == "activity log" || userInput == "show activity log")
                    {
                        Application.Run(new ActivityLogForm(log.GetRecent()));
                        continue;
                    }

                    TypingEffect("Chatbot: Hmm, I didn’t catch that. Could you rephrase it or pick a topic from the menu?");
                }
            }

            static void Logo()
            {
                Console.WriteLine("CYBERSECURITY CHATBOT\n========================");
            }

            static void TypingEffect(string text)
            {
                foreach (char c in text)
                {
                    Console.Write(c);
                    Thread.Sleep(20);
                }
                Console.WriteLine();
            }

            static void DisplayMenu()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n========= MENU: Cybersecurity Topics & Features =========");
                Console.WriteLine("Type 'quiz' to start the Cybersecurity Quiz Game");
                Console.WriteLine("Type 'add task' or 'set a reminder' to manage tasks");
                Console.WriteLine("Type 'show tasks' to list your tasks");
                Console.WriteLine("Type 'complete task [number]' to complete a task");
                Console.WriteLine("Type 'delete task [number]' to delete a task");
                Console.WriteLine("Type 'show activity log' to view recent actions");
                Console.WriteLine("==========================================================\n");
                Console.ResetColor();
            }
        }
    }

}
