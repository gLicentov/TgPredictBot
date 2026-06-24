using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TgPredictBot.Interfaces;       // Подключаем интерфейс!
using TgPredictBot.CommandHandlers; // Подключаем обработчики!

namespace TgPredictBot
{
    public class CommandHandler
    {
        private readonly Dictionary<string, IBotCommand> _commands;

        public CommandHandler()
        {
            var startCommand = new StartCommand();
            var tarotCommand = new TarotCommand();
            var predictionCommand = new PredictionCommand(); // 1. Создаем экземпляр новой команды 

            _commands = new Dictionary<string, IBotCommand>
            {
                { startCommand.Name, startCommand },
                { tarotCommand.Name, tarotCommand },
                { predictionCommand.Name, predictionCommand } // 2. Регистрируем её по ключу "/prediction" 
            };
        }

        public async Task ExecuteCommandAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            string rawText = message.Text ?? string.Empty;
            string targetCommand = rawText;

            // 3. Проверяем, если пришел чистый текст с кнопки — подменяем его на системную команду 
            if (rawText == "🔮 Расклад Таро")
            {
                targetCommand = "/tarot";
            }
            else if (rawText == "🌟 Прогноз на день")
            {
                targetCommand = "/prediction";
            }
            else
            {
                // Если это обычная команда (например, /start или /start от реферала), отсекаем аргументы 
                targetCommand = rawText.Split(' ')[0];
            }

            // 4. Ищем команду в нашем словаре
            if (_commands.TryGetValue(targetCommand, out var command))
            {
                await command.ExecuteAsync(botClient, message, cancellationToken);
            }
            else
            {
                // Обновили текст заглушки, чтобы пользователь понимал, что можно нажимать кнопки
                await botClient.SendMessage(
                    chatId: message.Chat.Id,
                    text: "Я пока не знаю такой магии. Используйте кнопки главного меню или команды /start и /tarot.",
                    cancellationToken: cancellationToken
                );
            }
        }
    }
}