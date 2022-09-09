using Microsoft.EntityFrameworkCore;
using SongGuessBackend.Models;

namespace SongGuessBackend.Data.TwiceData
{
    public class TwiceSongContext : DbContext
    {
        public TwiceSongContext(DbContextOptions<TwiceSongContext> opt) : base(opt)
        {

        }

        public DbSet<Song> Song { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Name=ConnectionStrings:ScanVolDiagLogs");
        //    }
        //}


    }
}
