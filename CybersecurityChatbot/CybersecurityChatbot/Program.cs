using System;
using System.Media;
using System.Linq;
using CybersecurityChatbot;

namespace CybersecurityChatbot
{
    class Program
    {
        static readonly string[] Questions = new string[]
        {
            "What is phishing?",
            "How can I identify a phishing email?",
            "What are some common phishing tactics?",
            "How do I avoid phishing scams?",
            "What should I do if I clicked a phishing link?",
            "Are phishing emails always obvious?",
            "What is spear phishing?",
            "Can phishing occur via text messages?",
            "How do companies protect against phishing?",
            "Is phishing only done through email?",
            "What is safe browsing?",
            "How do I stay safe while browsing online?",
            "What are secure websites?",
            "What is HTTPS and why is it important?",
            "How do I avoid malicious ads?",
            "Can browser extensions be dangerous?",
            "What is private/incognito mode?",
            "How do I clear my browsing history?",
            "What is a fake website?",
            "How do I know if a website is fake?",
            "What makes a strong password?",
            "How often should I change my passwords?",
            "What is two-factor authentication?",
            "How do I manage my passwords securely?",
            "Should I use the same password everywhere?",
            "How do I store passwords safely?",
            "Are password managers safe?",
            "What is password cracking?",
            "What should I do if my password is leaked?",
            "How do I protect my accounts online?"
        };

        static void Main(string[] args)
        {
            Console.Title = "Cybersecurity Awareness Bot";

            PlayVoiceGreeting();
            DisplayASCIIArt();
            GetUserDetails();
            AskFavoriteTopic();
            ChatLoop();
        }

        static void PlayVoiceGreeting()
        {
            try
            {
                using (SoundPlayer player = new SoundPlayer("Sounds\\greeting.wav"))
                {
                    player.Load();
                    player.PlaySync();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Voice greeting failed to play: {ex.Message}");
                Console.ResetColor();
            }
        }

        static void DisplayASCIIArt()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
 ..................                                          
                                        .....=***+++*+-....                                         
                                        ....*****=++***+...                                         
                                        ...=*****=++***#+..                                         
                                        ...*##**+++++*#%#:.                                         
                                        ..*#******+++**+%=.                                         
                                     ....=##+#@@@@@@@@%=#%:......                                   
                                     ...-#*%@@@@@@@@@@@@%*#-.....                                   
                                     ...-%@@@@@@@@+-::#@@@*=.....                                   
                                  .......*@@@@@@@@#:..#@@@%-....... ..                              
                                  ......-##@@@@%@@%#:%@@@#%=.....                                   
                                ...-+###=#@@@@@@@@%:@@@@@@#+*##+-.....                              
                             ....:#####**%@@@@@@@@@@@@@@@@%*+####%-....                             
                             ...:#######**#@@%@@@@@@@@@%@#**#######-...                             
                             ...=#*%@*%*###@@+@@@@@@@@##@###*##@%##*...                             
                             ..:####%%%*###@@=@@@@@@@@@=@###*%%%####-.                              
                             ..*####%-:::::::.:::::::::.::::::-%####%..                             
                             ..######..........................*%####:.                             
                             .=####%%..........................%%####+.                             
                             .*####%%..........................%%#####:.....                        
                          .. =%%%@@@@..........................%@@@%%%+.....                        
                          ..=##@%%@@@:.:.........:::...........@@@@%@%#+....                        
                          ..=%#####@@::::::::::::::::::::::::::@@%####%+....                        
                          ...#####***--------------------------***#####.....                        
                             .#%%%%%%==========================#@%#%%#:.....                        
                       ........*%%@#=**************************=*@%%#.......                        
                       .....................................................                        
                             ........ .............................. .                              
                             ........ .............................. .                      

                                         CYBER SENTINEL
                                       [ DEFENSE SYSTEM ]
                                     [==========||=========]

                          Cybersecurity Awareness Bot - Keeping You Safe Online!
            ");
            Console.ResetColor();
        }

        static void GetUserDetails()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nPlease enter your name: ");
            Console.ResetColor();

            string name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Name can't be empty! Please enter your name: ");
                Console.ResetColor();
                name = Console.ReadLine();
            }

            UserProfile.Name = name;
            Console.WriteLine($"\nWelcome, {UserProfile.Name}! Feel free to ask me anything about cybersecurity.");
            Console.WriteLine(new string('-', 60));
        }

        static void AskFavoriteTopic()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nWhat is your favorite cybersecurity topic (phishing, password, or safe browsing)? ");
            Console.ResetColor();

            string topic = Console.ReadLine()?.ToLower();

            while (string.IsNullOrWhiteSpace(topic) ||
                   !(topic.Contains("phishing") || topic.Contains("password") || topic.Contains("browsing")))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Please choose one of the valid topics (phishing, password, or safe browsing): ");
                Console.ResetColor();
                topic = Console.ReadLine()?.ToLower();
            }

            if (topic.Contains("phishing")) UserProfile.SetFavoriteTopic("phishing");
            else if (topic.Contains("browsing")) UserProfile.SetFavoriteTopic("safe browsing");
            else UserProfile.SetFavoriteTopic("password");

            Console.WriteLine($"Got it, {UserProfile.Name}! I'll keep {UserProfile.FavoriteTopic} in mind.");
        }

        static void ChatLoop()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\nYou: ");
                Console.ResetColor();

                string input = Console.ReadLine()?.ToLower();

                if (string.IsNullOrWhiteSpace(input))
                {
                    TypingEffect("I didn't quite catch that. Could you try again?");
                    continue;
                }

                if (input.Contains("exit"))
                {
                    TypingEffect($"Goodbye, {UserProfile.Name}! Stay safe online.");
                    break;
                }
                string sentimentResponse = SentimentAnalyzer.AnalyzeSentiment(input);
                if (sentimentResponse != null)
                {
                    TypingEffect(sentimentResponse);
                    continue;
                }


                if (ConversationManager.IsFollowUp(input) && !string.IsNullOrEmpty(ConversationManager.CurrentTopic))
                {
                    string followUp = ResponseManager.GetRandomResponse(ConversationManager.CurrentTopic);
                    TypingEffect(followUp);
                    continue;
                }

                string matchedTopic = ResponseManager.MatchTopic(input);

                if (matchedTopic != null)
                {
                    ConversationManager.CurrentTopic = matchedTopic;

                    string response = ResponseManager.GetRandomResponse(matchedTopic);

                    if (matchedTopic == UserProfile.FavoriteTopic)
                    {
                        response = $"Since you like {matchedTopic}, {UserProfile.Name}, here's a tip: {response}";
                    }

                    TypingEffect(response);
                }
                else if (input.Contains("what can i ask"))
                {
                    TypingEffect("Here are some things you can ask me:");
                    foreach (var question in Questions)
                    {
                        Console.WriteLine($"- {question}");
                        System.Threading.Thread.Sleep(40);
                    }
                }
                else
                {
                    TypingEffect("I'm not sure I understood. Try asking about phishing, passwords, or safe browsing.");
                    ConversationManager.ResetTopic();
                }
            }
        }

        static void TypingEffect(string message)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (char c in message)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(30);
            }
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
