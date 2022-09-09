using SongGuessBackend.Data;
using SongGuessBackend.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SongGuessBackend.Data.TwiceData
{
    public class TwiceSongRepo : ISongRepo
    {
        private int _songAmount;
        private readonly TwiceSongContext _twiceSongContext;
        private readonly TwiceSessionInfoContext _twiceSessionInfo;

        public TwiceSongRepo(TwiceSongContext twiceSongContext, TwiceSessionInfoContext twiceSessionInfoContext)
        {
            _songAmount = -1;
            _twiceSongContext = twiceSongContext;
            _twiceSessionInfo = twiceSessionInfoContext;
        }
        public async Task<Song> GetSong(Guid sessionId)
        {
            
            if (_songAmount == -1)
            {
                _songAmount = _twiceSongContext.Song.Max(song => song.Id) + 1;
            }
            int rand = random.Next(_songAmount);
            throw new NotImplementedException();
            return await _twiceSongContext.Song.FirstOrDefaultAsync(song => song.Id == rand);
        }

        public async Task<SessionInfo> GetSessionId(string username)
        {
            return await _twiceSessionInfo.SessionInfo.FirstAsync(x => x.Username == username);
        }
        public Task<Guid> 
    }
}
