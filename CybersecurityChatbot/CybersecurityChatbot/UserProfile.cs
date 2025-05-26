namespace CybersecurityChatbot
{
    public static class UserProfile
    {
        public static string Name { get; set; } = "";
        public static string FavoriteTopic { get; set; } = "";

        public static void SetFavoriteTopic(string topic)
        {
            FavoriteTopic = topic;
        }

        public static bool HasFavoriteTopic()
        {
            return !string.IsNullOrWhiteSpace(FavoriteTopic);
        }
    }
}
