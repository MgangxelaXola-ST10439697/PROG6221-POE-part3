using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Cybersecurity_Chatbot.Classes
{
    public static class KeywordInterpreter
    {
        public enum IntentType
        {
            None,
            LaunchQuiz,
            AddTask,
            ShowTasks,
            CompleteTask,
            DeleteTask,
            ShowLog,
            Unknown
        }

        public static IntentType DetectIntent(string input)
        {
            input = input.ToLower();

            // Simplified keyword-based matching
            if (input.Contains("quiz") || input.Contains("take a quiz") || input.Contains("start quiz"))
                return IntentType.LaunchQuiz;
            if (input.Contains("add task") || input.Contains("remind me") || input.Contains("set reminder"))
                return IntentType.AddTask;
            if (input.Contains("show tasks") || input.Contains("list tasks"))
                return IntentType.ShowTasks;
            if (input.Contains("complete task"))
                return IntentType.CompleteTask;
            if (input.Contains("delete task"))
                return IntentType.DeleteTask;
            if (input.Contains("show log") || input.Contains("activity log"))
                return IntentType.ShowLog;

            return IntentType.Unknown;
        }
    }

}