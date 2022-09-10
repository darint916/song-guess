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
        private readonly TwiceSessionInfoContext _twiceSessionInfoContext;

        public TwiceSongRepo(TwiceSongContext twiceSongContext, TwiceSessionInfoContext twiceSessionInfoContextContext)
        {
            _songAmount = -1;
            _twiceSongContext = twiceSongContext;
            _twiceSessionInfoContext = twiceSessionInfoContextContext;
        }
        public async Task<Song> GetSong(Guid sessionId)
        {
            var session = _twiceSessionInfoContext.SessionInfo.FirstAsync(x => x.SessionId == sessionId);
            int rand = random.Next(_songAmount);
            throw new NotImplementedException();
            return await _twiceSongContext.Song.FirstOrDefaultAsync(song => song.Id == rand);
        }

        public async Task<SessionInfo> GetSessionId(string username)
        {
            return await _twiceSessionInfoContext.SessionInfo.FirstAsync(x => x.Username == username);
        }

        public void CreateSession(string username)
        {
            //Add username validation, add password in future
            if (username == null) throw new ArgumentNullException(nameof(username));
            //Finds total amount of songs
            if (_songAmount == -1) 
            {
                _songAmount = _twiceSongContext.Song.Max(song => song.Id) + 1;
            }

            Guid sessionId = new Guid();
            Random rand = new Random(sessionId.GetHashCode());
            List<int> list = Enumerable.Range(0, _songAmount).ToList();

            //Fisher-Yates modern shuffle
            for (int n = list.Count - 1; n > 0; --n)
            {
                int k = rand.Next(n + 1);
                (list[n], list[k]) = (list[k], list[n]);
            }

            var session = new SessionInfo
            {
                Username = username,
                SessionId = sessionId,
                Seed = sessionId.GetHashCode(),
                SongNumber = 0,
                RandomSongIndexList = list,
            };

            _twiceSessionInfoContext.Add(session);
        }

        public bool SaveChanges()
        {
            return (_twiceSessionInfoContext.SaveChanges() >= 0);
        }
    }
}
