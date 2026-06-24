using Microsoft.EntityFrameworkCore;
using System.IO;
using TgPredictBot.Models;

namespace TgPredictBot
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<TarotCard> TarotCards { get; set; } = null!;
        public DbSet<DailyPrediction> DailyPredictions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // База данных будет создана в файле bot.db прямо в папке запущенного приложения
            string dbPath = Path.Combine(System.AppContext.BaseDirectory, "bot.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Дополнительные настройки индексов для быстрого поиска
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<TarotCard>().HasKey(c => c.Id);
            modelBuilder.Entity<DailyPrediction>().HasKey(p => p.Id);
        }
    }
}