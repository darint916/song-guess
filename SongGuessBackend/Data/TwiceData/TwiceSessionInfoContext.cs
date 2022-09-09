using Microsoft.EntityFrameworkCore;
using SongGuessBackend.Models;

namespace SongGuessBackend.Data.TwiceData
{
    public class TwiceSessionInfoContext : DbContext
    {
        public TwiceSessionInfoContext(DbContextOptions<TwiceSessionInfoContext> opt) : base(opt)
        {

        }
        public DbSet<SessionInfo> SessionInfo { get; set; }
    }
}
