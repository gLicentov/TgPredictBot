using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TgPredictBot.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTarotModelWithEnum1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "TarotCards");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "TarotCards",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
