using System;
using System.Collections.Generic;
using System.Linq;

namespace Cybersecurity_Chatbot.Classes
{
    public class ConversationMemory
    {
        private Dictionary<string, TopicMemory> topicMemories = new Dictionary<string, TopicMemory>(StringComparer.OrdinalIgnoreCase);
        private int maxMemoryCount = 10;
        public string UserName { get; set; } = "User";

        public void AddInteraction(string topic, string userInput, string botResponse)
        {
            if (!topicMemories.ContainsKey(topic))
            {
                if (topicMemories.Count >= maxMemoryCount)
                {
                    var oldestKey = topicMemories.Keys.First();
                    topicMemories.Remove(oldestKey);
                }
                topicMemories[topic] = new TopicMemory();
            }
            topicMemories[topic].AddInteraction(userInput, botResponse);
        }

        public bool HasDiscussed(string topic) => topicMemories.ContainsKey(topic);

        public string GetLastResponse(string topic)
            => topicMemories.ContainsKey(topic) ? topicMemories[topic].GetLastResponse() : null;

        public int GetTopicCount(string topic)
            => topicMemories.ContainsKey(topic) ? topicMemories[topic].InteractionCount : 0;
    }
}
