using System;
using System.Collections.Generic;

namespace Cybersecurity_Chatbot.Classes
{
    public class ActivityLogger
    {
        private readonly List<string> log = new List<string>();

        public void Add(string message)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            log.Add($"{timestamp}: {message}");

            // Limit log to last 100 entries
            if (log.Count > 100)
                log.RemoveAt(0);
        }

        public List<string> GetRecent(int count = 10)
        {
            int skip = Math.Max(0, log.Count - count);
            return log.GetRange(skip, log.Count - skip);
        }
    }
}
