using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Serilog;
using Syphon;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;

namespace syphon_telegram
{
    public static class Program
    {
        private static TelegramBotClient Bot;
        private static SyphonEngine Engine;

        private static readonly object LastMsgIdsLock = new object();
        private static readonly Dictionary<string, int> LastMsgIds = new Dictionary<string, int>();

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Engine = new SyphonEngine(Preset.JointRu, Level.L3, true);

            Log.Logger = new LoggerConfiguration()
                .WriteTo.LiterateConsole()
                .CreateLogger();
            
            var token = Environment.GetEnvironmentVariable("SYPHON_TELEGRAM_TOKEN");
            if (string.IsNullOrEmpty(token))
            {
                Log.Fatal("Variable {Var} is not set", "SYPHON_TELEGRAM_TOKEN");
                Environment.Exit(-1);
                return;
            }
            Bot = new TelegramBotClient(token);

            Bot.OnCallbackQuery += OnCallbackQuery;
            Bot.OnMessage += OnMessage;
            Bot.OnMessageEdited += OnMessageEdited;
            Bot.OnInlineQuery += OnInlineQuery;
            Bot.OnInlineResultChosen += OnInlineResultChosen;
            Bot.OnReceiveError += OnReceiveError;

            var me = Bot.GetMeAsync().Result;
            Log.Information("Started as {Name}", me.Username);

            Console.Title = me.Username;

            Bot.StartReceiving();
            while (true)
            {
                Console.ReadLine();
            }
            Bot.StopReceiving();
        }

        private static void OnReceiveError(object sender, ReceiveErrorEventArgs e)
        {
            Log.Error("OnReceiveError: {Error}. migrate_to_chat_id={MigrateToChatId}, retry_after={RetryAfter}",
                e.ApiRequestException.ErrorCode,
                e.ApiRequestException.Parameters.MigrateToChatId,
                e.ApiRequestException.Parameters.RetryAfter);
        }

        private static void OnInlineResultChosen(object sender, ChosenInlineResultEventArgs e)
        {
            Log.Information("OnInlineResultChosen: {@Result}", e.ChosenInlineResult);
        }

        private static async void OnInlineQuery(object sender, InlineQueryEventArgs e)
        {
            Log.Information("OnInlineResultChosen: {@InlineQuery}", e.InlineQuery);
            await Bot.AnswerInlineQueryAsync(e.InlineQuery.Id, new InlineQueryResult[0], isPersonal: true, cacheTime: 3600);
        }

        private static async void OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message == null || e.Message.Type != MessageType.TextMessage)
            {
                return;
            }

            try
            {
                var response = Process(e.Message);
                var m = await Bot.SendTextMessageAsync(
                    e.Message.Chat.Id,
                    response,
                    ParseMode.Html,
                    disableWebPagePreview: true);
                lock (LastMsgIdsLock)
                {
                    LastMsgIds[m.Chat.Id] = m.MessageId;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception while repling to message #{MessageId} from {User} '{Text}'", e.Message.MessageId, e.Message.From.Username, e.Message.Text);
                await Bot.SendTextMessageAsync(
                    e.Message.Chat.Id,
                    $"Простите, что-то я обосрался ({ex.Message})",
                    ParseMode.Html,
                    disableWebPagePreview: true);

                lock (LastMsgIdsLock)
                {
                    LastMsgIds.Remove(e.Message.Chat.Id);
                }
            }
        }

        private static async void OnMessageEdited(object sender, MessageEventArgs e)
        {
            try
            {
                var response = Process(e.Message);

                int msgId;
                lock (LastMsgIdsLock)
                {
                    LastMsgIds.TryGetValue(e.Message.Chat.Id, out msgId);
                }

                Message m;
                if (msgId != 0)
                {
                    m = await Bot.EditMessageTextAsync(
                        e.Message.Chat.Id,
                        msgId,
                        response,
                        ParseMode.Html,
                        disableWebPagePreview: true
                    );
                }
                else
                {
                    m = await Bot.SendTextMessageAsync(
                        e.Message.Chat.Id,
                        response,
                        ParseMode.Html,
                        disableWebPagePreview: true);
                }

                lock (LastMsgIdsLock)
                {
                    LastMsgIds[m.Chat.Id] = m.MessageId;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception while repling to message #{MessageId} from {User} '{Text}'", e.Message.MessageId, e.Message.From.Username, e.Message.Text);
                await Bot.SendTextMessageAsync(
                    e.Message.Chat.Id,
                    $"Простите, что-то я обосрался ({ex.Message})",
                    ParseMode.Html,
                    disableWebPagePreview: true);

                lock (LastMsgIdsLock)
                {
                    LastMsgIds.Remove(e.Message.Chat.Id);
                }
            }
        }

        private static async void OnCallbackQuery(object sender, CallbackQueryEventArgs e)
        {
            Log.Information("OnCallbackQuery: {@CallbackQuery}", e.CallbackQuery);
            await Bot.AnswerCallbackQueryAsync(e.CallbackQuery.Id);
        }

        private static string Process(Message message)
        {
            var inputText = message.Text;

            if (inputText == "/start")
            {
                Log.Information("Started new chat with {User}", message.MessageId, message.From.Username);
                return "Привет, меня зовут Сифон и я <i>алкоголик</i> матершинник. Напиши мне что-нибудь, а я в ответ буду материться - это все, что мне под силу.";
            }

            if (string.IsNullOrWhiteSpace(inputText))
            {
                Log.Warning("Empty message #{MessageId} from {User} '{Text}'", message.MessageId, message.From.Username, message.Text);
                return "Скажи хоть что-нибудь";
            }

            ResultData result;
            while (true)
            {
                result = Engine.Process(inputText);
                if (result.PossibleChanges == 0)
                {
                    Log.Warning("Nothing to reply to message #{MessageId} from {User} '{Text}'", message.MessageId, message.From.Username, message.Text);
                    return "Тут ловить нечего, давай посложнее чего!";
                }

                if (result.PerformedChanges > 0)
                {
                    break;
                }
            }

            var renderer = new BotHtmlResultRenderer();
            result.Render(renderer);
            var outputText = renderer.Result;

            if (string.IsNullOrWhiteSpace(outputText))
            {
                return "Эх, не вышло ничего у меня";
            }

            Log.Information("Replied to message #{MessageId} from {User} '{Text}'", message.MessageId, message.From.Username, message.Text);
            return outputText;
        }
    }
}