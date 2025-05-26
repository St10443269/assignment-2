using System;
using System.Collections.Generic;
using System.Linq;

namespace CybersecurityChatbot
{
    public static class ResponseManager
    {
        private static readonly Dictionary<string, List<string>> TopicKeywords = new()
        {
            { "phishing", new List<string> { "phishing", "spear", "email", "scam", "link", "clicked", "text", "urgent" } },
            { "safe browsing", new List<string> { "safe", "browsing", "https", "secure", "ads", "extension", "incognito", "private", "history", "fake", "website" } },
            { "password", new List<string> { "password", "strong", "change", "2fa", "two-factor", "manager", "store", "cracking", "leaked", "account", "protect" } }
        };

        private static readonly Dictionary<string, List<string>> Responses = new()
        {
            { "phishing", new List<string>
                {
                    "Phishing is a trick to get your personal data by pretending to be someone else.",
                    "Phishing emails often contain urgent language or fake links.",
                    "Common tactics include fake invoices or login pages.",
                    "To avoid phishing scams, never click suspicious links or open attachments from unknown sources.",
                    "If you clicked a phishing link, disconnect from the internet and scan for malware.",
                    "Not all phishing emails are obvious; some look professional.",
                    "Spear phishing targets individuals using personalized information.",
                    "Yes, phishing can happen through text messages and social media too.",
                    "Companies use filters, training, and spam detection to fight phishing.",
                    "No, phishing can also occur via phone calls, social apps, or fake websites."
                }
            },
            { "safe browsing", new List<string>
                {
                    "Safe browsing means avoiding harmful sites and protecting your data.",
                    "Always look for HTTPS in the URL for secure sites.",
                    "Secure websites encrypt your data and start with https://.",
                    "HTTPS ensures your communication with the site is encrypted.",
                    "Avoid clicking on strange ads or popups.",
                    "Some browser extensions may be malicious; only use trusted ones.",
                    "Private or incognito mode hides your browsing history locally.",
                    "Clear your history regularly, especially on shared computers.",
                    "Fake websites can look real—check the domain closely.",
                    "If something feels off about a site, don’t enter personal info."
                }
            },
            { "password", new List<string>
                {
                    "A strong password uses uppercase, lowercase, numbers, and symbols.",
                    "Change your passwords every few months or after a breach.",
                    "Two-factor authentication adds an extra layer of security.",
                    "Use a password manager to organize your credentials safely.",
                    "Never use the same password on different sites.",
                    "Store passwords in a manager or encrypted vault, not on paper.",
                    "Yes, reputable password managers are secure.",
                    "Password cracking is when hackers guess or decrypt your password.",
                    "If your password is leaked, change it immediately and enable 2FA.",
                    "To protect your accounts, use unique passwords and monitor activity."
                }
            }
        };

        public static string GetRandomResponse(string topic)
        {
            return Responses.ContainsKey(topic)
                ? Responses[topic][new Random().Next(Responses[topic].Count)]
                : "I’m not sure about that topic.";
        }

        public static string MatchTopic(string input)
        {
            input = input.ToLower();
            foreach (var topic in TopicKeywords)
            {
                if (topic.Value.Any(keyword => input.Contains(keyword)))
                    return topic.Key;
            }
            return null;
        }
    }
}
