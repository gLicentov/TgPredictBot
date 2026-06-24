using System;

namespace TgPredictBot.Models
{
    public class User
    {
        public long Id { get; set; } // Telegram Chat ID
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

        // Для будущих астрологических расчетов
        public DateTime? BirthDate { get; set; }
        public string? ZodiacSign { get; set; }

        // Финансовая часть
        public bool IsPremium { get; set; } = false;
        public DateTime? PremiumExpiresAt { get; set; }
    }
}