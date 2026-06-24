using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Types;
using TgPredictBot.Interfaces;

namespace TgPredictBot.CommandHandlers
{
    public class TarotCommand : IBotCommand
    {
        public string Name => "/tarot";

        public async Task ExecuteAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            // Отправляем начальное сообщение без суффикса Async
            await botClient.SendMessage(
                chatId: message.Chat.Id,
                text: "🔮 Вселенная перемешивает колоду карт...",
                cancellationToken: cancellationToken
            );

            // Небольшая задержка для атмосферности
            await Task.Delay(1000, cancellationToken);

            using (var db = new AppDbContext())
            {
                // Загружаем все доступные карты из БД в массив
                var availableCards = await db.TarotCards.ToArrayAsync(cancellationToken);

                if (availableCards.Length == 0)
                {
                    await botClient.SendMessage(
                        chatId: message.Chat.Id,
                        text: "🚨 В магической библиотеке бота пока нет карт. Проверь инициализацию БД!",
                        cancellationToken: cancellationToken
                    );
                    return;
                }

                // Выбираем случайную карту из 78 загруженных при сиде карт
                var random = new Random();
                var selectedCard = availableCards[random.Next(availableCards.Length)];

                // Формируем красивый текстовый ответ (Markdown-разметка)
                string responseMessage = $"🔮 *ВАШЕ ПРЕДСКАЗАНИЕ ТАРО* 🔮\n\n" +
                                         $"🃏 *Карта:* {selectedCard.Name}\n\n" +
                                         $"📜 *Значение:* {selectedCard.Description}";

                // Отправляем строго через SendMessage (без SendPhoto и без проблемных внешних URL)
                await botClient.SendMessage(
                    chatId: message.Chat.Id,
                    text: responseMessage,
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown, // Чтобы работал жирный шрифт и курсив
                    cancellationToken: cancellationToken
                );
            }
        }
    }
}