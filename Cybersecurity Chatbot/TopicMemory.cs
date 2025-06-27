using System.Collections.Generic;
using System.Linq;

namespace Cybersecurity_Chatbot.Classes
{
    public class TopicMemory
    {
        private List<(string userInput, string botResponse)> interactions = new List<(string, string)>();

        public void AddInteraction(string userInput, string botResponse)
        {
            interactions.Add((userInput, botResponse));
        }

        public string GetLastResponse()
            => interactions.Count > 0 ? interactions.Last().botResponse : null;

        public int InteractionCount => interactions.Count;
    }

    public class SentimentDetector
    {
        private static readonly string[] WorryKeywords = { "worried", "scared", "anxious", "nervous", "concerned", "panic", "fear" };

        public static bool ContainsWorry(string input)
        {
            return WorryKeywords.Any(keyword => input.ToLower().Contains(keyword));
        }
    }
}