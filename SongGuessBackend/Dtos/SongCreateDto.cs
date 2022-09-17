using System.ComponentModel.DataAnnotations;

namespace SongGuessBackend.Dtos
{
    public class SongCreateDto
    {
        [Required]
        public string SongName { get; set; }
        [Required]
        public string SongPath { get; set; }
        [Required]
        public int SongLength { get; set; }
        [Required]
        public string? SongAlbum { get; set; }
        [Required]
        public string? SongMime { get; set; }
    }
}
