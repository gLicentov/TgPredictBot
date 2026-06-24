namespace TgPredictBot.Models
{
    public class TarotCard
    {
        public int Id { get; set; }

        public TarotCardType CardType { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}