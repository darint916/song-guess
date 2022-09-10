using System.ComponentModel.DataAnnotations;

namespace SongGuessBackend.Dtos.TwiceDtos
{
    public class TwiceSongReadDto
    {
        public Guid SongId { get; set; }
        [Required]
        public string SongName { get; set; }
        [Required]
        public string SongPath { get; set; }
        public int SongLength { get; set; }
        public string? SongAlbum { get; set; }
        public string? SongMime { get; set; }
        [Required]
        public string Url { get; set; }
    }
}
