using SongGuessBackend.Data;
using SongGuessBackend.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace song_guess_backend.Data.TwiceData
{
    public class TwiceSongRepo : ISongRepo
    {
        private int _songAmount;
        private TwiceSongContext _twiceSongContext;

        public TwiceSongRepo(TwiceSongContext twiceSongContext)
        {
            _songAmount = -1;
            _twiceSongContext = twiceSongContext;
        }
        public async Task<Song> GetSong(int seed)
        {
            Random random = new Random(seed);
            if (_songAmount == -1)
            {
                _songAmount = _twiceSongContext.Song.Max(song => song.Id) + 1;
            }
            int rand = random.Next(_songAmount);
            return await _twiceSongContext.Song.FirstOrDefaultAsync(song => song.Id == rand) ?? throw new InvalidOperationException();;
        }
    }
}
