using SongGuessBackend.Models;

namespace SongGuessBackend.Data
{
    public interface ISongRepo
    {
        public Task<Song> GetSong(int seed);
    }
}
