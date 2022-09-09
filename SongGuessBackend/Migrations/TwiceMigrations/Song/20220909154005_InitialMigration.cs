using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SongGuessBackend.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SongId = table.Column<Guid>(type: "uuid", nullable: false),
                    SongName = table.Column<string>(type: "text", nullable: false),
                    SongPath = table.Column<string>(type: "text", nullable: false),
                    SongLength = table.Column<int>(type: "integer", nullable: false),
                    SongAlbum = table.Column<string>(type: "text", nullable: true),
                    SongMime = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Song");
        }
    }
}
