using System;
using System.Linq;

namespace CybersecurityChatbot
{
    public static class ConversationManager
    {
        public static string CurrentTopic { get; set; } = "";

        private static readonly string[] FollowUpPhrases = new[]
        {
            "tell me more", "more", "again", "continue", "explain", "go on",
            "explain better", "i don't understand", "what should i do", "help me",
            "what now", "what if", "then what", "what to do", "what happens if", "and then", "how can i"
        };

        public static bool IsFollowUp(string input)
        {
            return FollowUpPhrases.Any(phrase => input.Contains(phrase));
        }

        public static void ResetTopic()
        {
            CurrentTopic = "";
        }
    }
}
