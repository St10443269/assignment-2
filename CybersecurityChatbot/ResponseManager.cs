using System;
using System.Collections.Generic;

namespace CybersecurityChatbot
{
    public static class ResponseManager
    {
        private static readonly Random random = new Random();

        private static readonly Dictionary<string, List<string>> ResponseDictionary = new Dictionary<string, List<string>>
        {
            ["phishing"] = new List<string>
            {
                "Phishing is a scam where attackers trick you into giving personal info.",
                "Be cautious of emails asking for personal information.",
                "Scammers often disguise themselves as trusted organizations.",
                "Never click on links from suspicious or unknown sources.",
                "Phishing messages often use urgent language to pressure you."
            },
            ["safe browsing"] = new List<string>
            {
                "Use up-to-date browsers and enable pop-up blockers.",
                "Avoid suspicious websites and only download from trusted sources.",
                "Look for HTTPS and a padlock icon before entering sensitive info.",
                "Don’t install random browser extensions or plug-ins.",
                "Clear your cache and cookies regularly for better security."
            },
            ["password"] = new List<string>
            {
                "Use a mix of letters, numbers, and symbols for strong passwords.",
                "Don't reuse the same password across different websites.",
                "Password managers help generate and store secure passwords.",
                "Enable two-factor authentication wherever possible.",
                "Avoid using personal info like birthdays or names in passwords."
            }
        };

        public static string GetRandomResponse(string keyword)
        {
            if (ResponseDictionary.ContainsKey(keyword))
            {
                var responses = ResponseDictionary[keyword];
                return responses[random.Next(responses.Count)];
            }

            return "I'm not sure I have information on that. Try asking about phishing, passwords, or safe browsing.";
        }
    }
}
