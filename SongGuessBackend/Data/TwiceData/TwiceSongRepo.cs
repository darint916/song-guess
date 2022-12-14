using SongGuessBackend.Data;
using SongGuessBackend.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SongGuessBackend.Dtos;
using SongGuessBackend.Profiles;

/*
 * TODO: Add score reset for end of game, push to leaderboard?
 */
namespace SongGuessBackend.Data.TwiceData
{
    public class TwiceSongRepo : ISongRepo
    {
        private readonly TwiceSongContext _twiceSongContext;
        private readonly TwiceSessionInfoContext _twiceSessionInfoContext;
        private readonly TwiceLeaderboardContext _twiceLeaderboardContext;
        public TwiceSongRepo(TwiceSongContext twiceSongContext, TwiceSessionInfoContext twiceSessionInfoContextContext, TwiceLeaderboardContext twiceLeaderboardContext)
        {
            _twiceSongContext = twiceSongContext;
            _twiceSessionInfoContext = twiceSessionInfoContextContext;
            _twiceLeaderboardContext = twiceLeaderboardContext;
        }
        public async Task<Song> GetSong(Guid sessionId)
        {
            try
            {
                var session = await _twiceSessionInfoContext.SessionInfo.FirstAsync(x => x.SessionId == sessionId);
                int count = session.RandomSongIndexList.Count;
                int songAmount = _twiceSongContext.Song.Max(song => song.Id) + 1;
                if (count != songAmount)  //creates a new shuffled list when new songs are added to db
                {
                    List<int> list = Enumerable.Range(0, songAmount).ToList();
                    ShuffleList(sessionId.GetHashCode(), list);
                    session.RandomSongIndexList = list;
                    session.SongNumber = 0;
                }
                session.SongNumber++;
                if (session.SongNumber >= songAmount) //Reshuffles list when all songs have been played
                {
                    ShuffleList(sessionId.GetHashCode(), session.RandomSongIndexList);
                    session.SongNumber = 0;
                }
                int id = session.RandomSongIndexList[session.SongNumber];
                session.GuessedCurrent = false;
                return await _twiceSongContext.Song.FirstAsync(x => x.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return null;
            }
        }

        public async Task<SessionInfo> GetSessionId(string username)
        {
            try
            {
                return await _twiceSessionInfoContext.SessionInfo.FirstAsync(x => x.Username == username);
            }
            catch
            {
                return null;
            }
        }

        public void CreateSession(string username)
        {
            //Add username validation, add password in future
            if (username == null) throw new ArgumentNullException(nameof(username));
            //Finds total amount of songs
            int songAmount = _twiceSongContext.Song.Max(song => song.Id) + 1;
            Guid sessionId = new Guid();
            List<int> list = Enumerable.Range(0, songAmount).ToList();
            ShuffleList(sessionId.GetHashCode(), list);

            var session = new SessionInfo
            {
                Username = username,
                SessionId = sessionId,
                Seed = sessionId.GetHashCode(),
                SongNumber = 0,
                RandomSongIndexList = list,
                GuessedCurrent = false,
                Mode = "default",
                Score = 0,
                SongsGuessed = 0,
            };
            _twiceSessionInfoContext.Add(session);
        }

        public bool SaveChanges()
        {
            return (_twiceSessionInfoContext.SaveChanges() >= 0 && _twiceSongContext.SaveChanges() >= 0);
        }

        public void CreateSong(IEnumerable<SongCreateDto> songCreateDto)
        {
            int songAmount = _twiceSongContext.Song.Max(song => song.Id) + 1;
            foreach (var song in songCreateDto)
            {
                Guid songId = new Guid();
                var songItem = new Song
                {
                    SongName = song.SongName,
                    SongPath = song.SongPath,
                    SongLength = song.SongLength,
                    SongAlbum = song.SongAlbum,
                    SongMime = song.SongMime,
                    SongId = songId,
                    //Id = songAmount,
                };
                //songAmount += 1;
                _twiceSongContext.Add(songItem);
            }
        }

        
        public async Task<Song> GetSongInfo(int id)
        {
            return await _twiceSongContext.Song.FirstAsync(x => x.Id == id);
        }

        /*
         * TODO: Based on current mode of session, add a score multiplied by mode.
         * TODO: SongsGuessed more details, # guessed per song names (dict)
         */
        public async Task<String?> VerifySong(Guid sessionId, string songName)
        {
            try
            {
                var session = await _twiceSessionInfoContext.SessionInfo.FirstAsync(x => x.SessionId == sessionId);
                int songId = session.RandomSongIndexList[session.SongNumber];
                var song = await _twiceSongContext.Song.FirstAsync(x => x.Id == songId);
                if (song.SongName == songName && !session.GuessedCurrent)
                {
                    session.GuessedCurrent = true;
                    session.SongsGuessed++;
                    return songName;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Song>> GetAllSongs()
        {
            return await _twiceSongContext.Song.ToListAsync();
        } 

        public void ShuffleList(int seed, List<int> list)
        {
            Random rand = new Random(seed);
            //Fisher-Yates modern shuffle
            for (int n = list.Count - 1; n > 0; --n)
            {
                int k = rand.Next(n + 1);
                (list[n], list[k]) = (list[k], list[n]);
            }
        }

        


    }
}
