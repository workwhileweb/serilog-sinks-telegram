namespace TelegramSink.TelegramBotClient
{
    public class BotConfiguration
    {
        public BotConfiguration(string apiKey, string chatId)
        {
            ApiKey = apiKey;
            ChatId = chatId;
        }

        public string ChatId { get; set; }
        public string ApiKey { get; set; }
    }
}