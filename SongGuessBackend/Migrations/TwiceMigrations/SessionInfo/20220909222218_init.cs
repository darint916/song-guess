using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SongGuessBackend.Migrations.TwiceMigrations.SessionInfo
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SessionInfo",
                columns: table => new
                {
                    SessionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Seed = table.Column<int>(type: "integer", nullable: false),
                    SongNumber = table.Column<int>(type: "integer", nullable: false),
                    RandomSongIndex = table.Column<List<int>>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionInfo", x => x.SessionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SessionInfo");
        }
    }
}
