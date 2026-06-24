using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TgPredictBot.Interfaces;

namespace TgPredictBot.CommandHandlers
{
    public class StartCommand : IBotCommand
    {
        public string Name => "/start";

        public async Task ExecuteAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            string welcomeText = $"✨ Приветствую тебя, {message.From?.FirstName}! ✨\n\n" +
                                 "Я твой персональный проводник в мир астрологии и Таро.\n" +
                                 "Выбери интересующий тебя раздел на клавиатуре ниже, чтобы получить предсказание.";

            // Проектируем кнопки главного меню
            var replyKeyboard = new ReplyKeyboardMarkup(new[]
            {
                new[] // Первый ряд кнопок
                {
                    new KeyboardButton("🔮 Расклад Таро"),
                    new KeyboardButton("🌟 Прогноз на день")
                }
            })
            {
                // Подгоняет размер кнопок под экран смартфона (чтобы они не были гигантскими)
                ResizeKeyboard = true,
                // Скрывает клавиатуру сразу после нажатия на кнопку (при необходимости можно убрать)
                InputFieldPlaceholder = "Выберите магическое действие..."
            };

            await botClient.SendMessage(
                chatId: message.Chat.Id,
                text: welcomeText,
                replyMarkup: replyKeyboard, // Прикрепляем клавиатуру к сообщению
                cancellationToken: cancellationToken
            );
        }
    }
}