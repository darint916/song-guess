using SongGuessBackend.Dtos;
using SongGuessBackend.Models;

namespace SongGuessBackend.Data
{
    public interface ISongRepo
    {
        public Task<Song> GetSong(Guid sessionId);
        public Task<SessionInfo> GetSessionId(string username);
        public void CreateSession(string username);
        public bool SaveChanges();
        public void CreateSong(IEnumerable<SongCreateDto> songCreateDto);
        public Task<Song> GetSongInfo(int id);
    }
}
