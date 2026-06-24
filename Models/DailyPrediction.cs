namespace TgPredictBot.Models
{
    public class DailyPrediction
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!;

        // Категория прогноза (например: "Общий", "Любовь", "Деньги" или названия Знаков Зодиака)
        public string Category { get; set; } = null!;
    }
}