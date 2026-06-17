using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TgPredictBot.Interfaces;

namespace TgPredictBot.ComnmandHandlers
{
    public class StartCommand : IBotCommand
    {
        public string Name => "/start";

        public Task ExecuteAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            string welcomeText = "Приветствую! Я твой персональный проводник в мир Таро и Астрологии. 🌟\n\n" +
                                 "Каждый день тебе доступна бесплатная 'Карта дня'.\n" +
                                 "Чтобы сделать расклад, введи команду /tarot";

            return botClient.SendMessageAsync(
                chatId: message.Chat.Id,
                text: welcomeText,
                cancellationToken: cancellationToken
            );
        }
    }
}
