using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

class Program
{
    private static ITelegramBotClient _botClient;
    private static CommandHandler _commandHandler;

    static async Task Main(string[] args)
    {
        // Вставь сюда токен своего бота от @BotFather
        string botToken = "YOUR_TELEGRAM_BOT_TOKEN";

        _botClient = new TelegramBotClient(botToken);
        _commandHandler = new CommandHandler();

        using var cts = new CancellationTokenSource();

        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = Array.Empty<UpdateType>() // Получать все типы апдейтов
        };

        var me = await _botClient.GetMeAsync();
        Console.WriteLine($"Бот @{me.Username} успешно запущен в режиме Long Polling!");

        _botClient.StartReceiving(
            updateHandler: HandleUpdateAsync,
            errorHandler: HandlePollingErrorAsync,
            receiverOptions: receiverOptions,
            cancellationToken: cts.Token
        );

        Console.WriteLine("Нажмите Enter для остановки бота...");
        Console.ReadLine();

        // Останавливаем бота
        cts.Cancel();
    }

    private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        // Обрабатываем только текстовые сообщения
        if (update.Message is not { Text: { } messageText } message)
            return;

        long chatId = message.Chat.Id;
        Console.WriteLine($"Получено сообщение '{messageText}' в чате {chatId}.");

        // Передаем обработку хендлеру команд
        await _commandHandler.ExecuteCommandAsync(botClient, message, cancellationToken);
    }

    private static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Ошибка во время пуллинга: {exception.Message}");
        return Task.CompletedTask;
    }
}