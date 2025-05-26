using System;
using System.Collections.Generic;
using System.Linq;

namespace CybersecurityChatbot
{
    public static class SentimentAnalyzer
    {
        private static readonly Dictionary<string, string> SentimentKeywords = new()
        {
            { "worried", "It's completely understandable to feel worried. Cyber threats can be intimidating, but you're not alone. Let's go through it step-by-step." },
            { "frustrated", "I get that you're feeling frustrated. Online safety can be tricky, but I'm here to help make things clearer." },
            { "confused", "It's okay to be confused—cybersecurity terms can be complex. Let me explain it more simply." },
            { "scared", "Feeling scared is normal. Scammers can be very convincing, but you're taking the right step by learning more." },
            { "overwhelmed", "Cybersecurity can feel overwhelming, but don’t worry—you’re doing great by asking questions!" },
            { "unsure", "It’s okay to be unsure. Let's work through it together." }
        };

        public static string AnalyzeSentiment(string input)
        {
            input = input.ToLower();
            foreach (var kvp in SentimentKeywords)
            {
                if (input.Contains(kvp.Key))
                    return kvp.Value;
            }
            return null;
        }
    }
}
