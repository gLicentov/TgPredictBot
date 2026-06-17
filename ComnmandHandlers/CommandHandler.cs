using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TgPredictBot.Interfaces;

namespace TgPredictBot.ComnmandHandlers
{
    public class CommandHandler
    {
        private readonly Dictionary<string, IBotCommand> _commands;

        public CommandHandler()
        {
            // Регистрируем доступные команды
            var startCommand = new StartCommand();
            var tarotCommand = new TarotCommand();

            _commands = new Dictionary<string, IBotCommand>
        {
            { startCommand.Name, startCommand },
            { tarotCommand.Name, tarotCommand }
        };
        }

        public async Task ExecuteCommandAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            string text = message.Text.Split(' ')[0]; // Вычленяем саму команду

            if (_commands.TryGetValue(text, out var command))
            {
                await command.ExecuteAsync(botClient, message, cancellationToken);
            }
            else
            {
                await botClient.SendMessageAsync(
                    chatId: message.Chat.Id,
                    text: "Я пока не знаю такой магии. Используйте /start или /tarot",
                    cancellationToken: cancellationToken
                );
            }
        }
    }
}
