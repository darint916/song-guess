using SongGuessBackend.Models;

namespace SongGuessBackend.Data
{
    public interface ISongRepo
    {
        public Task<Song> GetSong(Guid sessionId);
        public Task<SessionInfo> GetSessionId(string username);
    }
}
