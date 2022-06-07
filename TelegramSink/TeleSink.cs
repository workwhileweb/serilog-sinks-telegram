﻿using System;
using Serilog.Core;
using Serilog.Events;
using TelegramSink.TelegramBotClient;

namespace TelegramSink
{
    public class TeleSink : ILogEventSink
    {
        private readonly IFormatProvider _formatProvider;
        private readonly LogEventLevel _minimumLevel;
        private readonly Bot _telegramBot;

        public TeleSink(IFormatProvider formatProvider, string telegramApiKey, string chatId,
            LogEventLevel minimumLevel)
        {
            _formatProvider = formatProvider;
            _minimumLevel = minimumLevel;
            _telegramBot = new Bot(new BotConfiguration(telegramApiKey, chatId));
        }

        public void Emit(LogEvent logEvent)
        {
            if (logEvent.Level < _minimumLevel) return;

            var loggedMessage = logEvent.RenderMessage(_formatProvider);

            _telegramBot.SendMessage(loggedMessage);
        }
    }
}