using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TgPredictBot.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTarotModelWithEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CardType",
                table: "TarotCards",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardType",
                table: "TarotCards");
        }
    }
}
