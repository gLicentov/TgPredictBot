using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TgPredictBot.Interfaces;

namespace TgPredictBot.ComnmandHandlers
{
    public class TarotCommand : IBotCommand
    {
        public string Name => "/tarot";

        public async Task ExecuteAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            await botClient.SendMessageAsync(
                chatId: message.Chat.Id,
                text: "🔮 Вселенная выбирает карту для тебя...",
                cancellationToken: cancellationToken
            );

            // Имитируем задержку для атмосферности
            await Task.Delay(1500, cancellationToken);

            [cite_start]// Заглушка: в будущем это будет тянуться из БД/генератора [cite: 58, 64]
            string imageUrl = "https://images.unsplash.com/photo-1601024418022-34d31d24e13f?w=500"; // Пример картинки
            string predictionText = "🃏 **Твоя карта: Маг (The Magician)**\n\n" +
                                    "Сегодня день проявления твоей воли. У тебя есть все необходимые ресурсы, " +
                                    "чтобы запустить новый проект или решить старую проблему. Действуй уверенно!";

            // Отправляем фото вместе с подписью (текстом предсказания)
            await botClient.SendPhotoAsync(
                chatId: message.Chat.Id,
                photo: InputFile.FromUri(imageUrl),
                caption: predictionText,
                parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown,
                cancellationToken: cancellationToken
            );
        }
    }
}
