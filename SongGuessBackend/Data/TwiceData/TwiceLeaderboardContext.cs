using Microsoft.EntityFrameworkCore;
using SongGuessBackend.Models;

namespace SongGuessBackend.Data.TwiceData
{
    public class TwiceLeaderboardContext : DbContext
    {
        public TwiceLeaderboardContext(DbContextOptions<TwiceLeaderboardContext> opt) : base(opt)
        {

        }
        public DbSet<Leaderboard> Leaderboard { get; set; }
    }
}