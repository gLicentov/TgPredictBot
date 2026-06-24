using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TgPredictBot
{
    class Program
    {
        private static TelegramBotClient? _botClient;
        private static CommandHandler? _commandHandler;

        static async Task Main(string[] args)
        {
            string botToken = "Insert your token";

            using (var db = new AppDbContext())
            {
                // Этот метод автоматически создаст файл БД и накатит ВСЕ недостающие таблицы
                // строго по моделям, прописанным в вашем AppDbContext
                db.Database.Migrate();
                DbInitializer.Seed(db);
                Console.WriteLine("База данных успешно инициализирована и наполнена 78 картами!");
            }

            _botClient = new TelegramBotClient(botToken);
            _commandHandler = new CommandHandler();

            using var cts = new CancellationTokenSource();

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = Array.Empty<UpdateType>()
            };

            var me = await _botClient.GetMe(cancellationToken: cts.Token);
            Console.WriteLine($"Бот @{me.Username} успешно запущен!");

            _botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                errorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
            );

            Console.WriteLine("Нажмите Enter для остановки бота...");
            Console.ReadLine();

            cts.Cancel();
        }

        private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is not { Text: { } messageText } message)
                return;

            if (_commandHandler != null)
            {
                await _commandHandler.ExecuteCommandAsync(botClient, message, cancellationToken);
            }
        }

        private static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Ошибка: {exception.Message}");
            return Task.CompletedTask;
        }
    }
}