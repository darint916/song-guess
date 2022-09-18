using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SongGuessBackend.Migrations.TwiceMigrations.SessionInfo
{
    public partial class renameList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RandomSongIndex",
                table: "SessionInfo",
                newName: "RandomSongIndexList");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RandomSongIndexList",
                table: "SessionInfo",
                newName: "RandomSongIndex");
        }
    }
}
