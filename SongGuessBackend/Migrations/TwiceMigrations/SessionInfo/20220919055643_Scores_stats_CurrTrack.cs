using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SongGuessBackend.Migrations.TwiceMigrations.SessionInfo
{
    public partial class Scores_stats_CurrTrack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "GuessedCurrent",
                table: "SessionInfo",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Mode",
                table: "SessionInfo",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "SessionInfo",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SongsGuessed",
                table: "SessionInfo",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GuessedCurrent",
                table: "SessionInfo");

            migrationBuilder.DropColumn(
                name: "Mode",
                table: "SessionInfo");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "SessionInfo");

            migrationBuilder.DropColumn(
                name: "SongsGuessed",
                table: "SessionInfo");
        }
    }
}
