// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SongGuessBackend.Data.TwiceData;

#nullable disable

namespace SongGuessBackend.Migrations.TwiceMigrations.SessionInfo
{
    [DbContext(typeof(TwiceSessionInfoContext))]
    [Migration("20220918002557_renameList")]
    partial class renameList
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SongGuessBackend.Models.SessionInfo", b =>
                {
                    b.Property<Guid>("SessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<List<int>>("RandomSongIndexList")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<int>("Seed")
                        .HasColumnType("integer");

                    b.Property<int>("SongNumber")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SessionId");

                    b.ToTable("SessionInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
