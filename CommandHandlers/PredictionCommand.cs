using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TgPredictBot.Interfaces;

namespace TgPredictBot.CommandHandlers
{
    public class PredictionCommand : IBotCommand
    {
        public string Name => "/prediction";

        public async Task ExecuteAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            await botClient.SendMessage(
                chatId: message.Chat.Id,
                text: "🌌 Звезды начинают свой танец... Сейчас я загляну в таблицу предсказаний!",
                cancellationToken: cancellationToken
            );
        }
    }
}