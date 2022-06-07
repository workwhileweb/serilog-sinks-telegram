﻿using Flurl;
using Flurl.Http;
using TelegramSink.TelegramBotClient.Domain;

namespace TelegramSink.TelegramBotClient
{
    public class Bot
    {
        private const string TelegramApiBaseUrl = "https://api.telegram.org";
        private readonly BotConfiguration _botConfiguration;

        public Bot(BotConfiguration botConfiguration)
        {
            _botConfiguration = botConfiguration;
        }

        public RestResult SendMessage(string message)
        {
            var response = TelegramApiBaseUrl
                .AppendPathSegment($"bot{_botConfiguration.ApiKey}/sendMessage")
                .PostJsonAsync(new {chat_id = _botConfiguration.ChatId, text = message})
                .ReceiveJson<RestResult>().Result;

            return response;
        }
    }

    public class RestResult
    {
        public bool Ok { get; set; }
        public Message Result { get; set; }
    }
}