using SongGuessBackend.Dtos.TwiceDtos;

namespace SongGuessBackend.Extensions
{
    public static class SongReadDtoExtensions
    {
        public static void MapSongUrl(this TwiceSongReadDto song, Func<Guid, string?> songUrlGenerator)
        {
            var songUrl = songUrlGenerator.Invoke(song.SongId);
            if (songUrl == null)
            {
                throw new InvalidOperationException("Failed to Generate Asset URI. MapSongUrl call returned null");
            }

            song.Url = songUrl;
        }
    }
}
