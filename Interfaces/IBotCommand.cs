using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TgPredictBot.Interfaces
{
    public interface IBotCommand
    {
        string Name { get; }
        Task ExecuteAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken);
    }
}