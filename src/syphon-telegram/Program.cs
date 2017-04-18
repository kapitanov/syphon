using System;
using System.Text;
using System.Text.RegularExpressions;
using Serilog;
using Syphon;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;

namespace syphon_telegram
{
    public static class Program
    {
        private static TelegramBotClient Bot;
        private static SyphonEngine Engine;

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Engine = new SyphonEngine(Preset.PetrovichRu, Level.L3, true);

            Log.Logger = new LoggerConfiguration()
                .WriteTo.LiterateConsole()
                .CreateLogger();
            Bot = new TelegramBotClient(Environment.GetEnvironmentVariable("SYPHON_TELEGRAM_TOKEN"));

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
            Console.ReadLine();
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

            var inputText = e.Message.Text;
            if (inputText == "/start")
            {
                await Bot.SendTextMessageAsync(
                    e.Message.Chat.Id,
                    "Привет, меня зовут Сифон и я ~алкоголик~ матершинник",
                    ParseMode.Markdown);
                Log.Information("Started new chat with {User}", e.Message.MessageId, e.Message.From.Username);
                return;
            }

            if (!Regex.IsMatch(inputText, @"^[а-яА-Я]+[а-яА-Я\s-_.,;]+.*$"))
            {
                await Bot.SendTextMessageAsync(e.Message.Chat.Id, "Скажи хоть что-нибудь");
                Log.Warning("Nothing to reply to message #{MessageId} from {User} '{Text}'", e.Message.MessageId, e.Message.From.Username, e.Message.Text);
                return;
            }

            var result = Engine.Process(inputText);

            var renderer = new BotHtmlResultRenderer();
            result.Render(renderer);
            var outputText = renderer.Result;

            if (string.IsNullOrWhiteSpace(outputText))
            {
                await Bot.SendTextMessageAsync(e.Message.Chat.Id, "Простите, что-то я обосрался");
                Log.Warning("Failed to reply to message #{MessageId} from {User} '{Text}'", e.Message.MessageId, e.Message.From.Username, e.Message.Text);
                return;
            }

            await Bot.SendTextMessageAsync(
                e.Message.Chat.Id,
                outputText,
                ParseMode.Html,
                disableWebPagePreview: true);
            Log.Information("Replied to message #{MessageId} from {User} '{Text}'", e.Message.MessageId, e.Message.From.Username, e.Message.Text);
        }

        private static async void OnMessageEdited(object sender, MessageEventArgs e)
        {
            await Bot.SendTextMessageAsync(e.Message.Chat.Id, "Don't even try to edit anything!");
        }

        private static async void OnCallbackQuery(object sender, CallbackQueryEventArgs e)
        {
            Log.Information("OnCallbackQuery: {@CallbackQuery}", e.CallbackQuery);
            await Bot.AnswerCallbackQueryAsync(e.CallbackQuery.Id);
        }
    }

    internal sealed class BotHtmlResultRenderer : IResultRenderer
    {
        private readonly StringBuilder _builder = new StringBuilder();

        public string Result => _builder.ToString().Replace("\n", "<br />");

        public void AppendUnchanged(string str)
        {
            _builder.Append(str);
        }

        public void AppendChanged(string str)
        {
            _builder.Append("<i>");
            _builder.Append(str);
            _builder.Append("</i>");
        }

        public void End() { }
    }
}