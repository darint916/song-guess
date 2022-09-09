using System.ComponentModel.DataAnnotations;

namespace SongGuessBackend.Models
{
    public class Song
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public Guid SongId { get; set; }
        [Required]
        public string SongName { get; set; }
        [Required]
        public string SongPath { get; set; }
        public int SongLength { get; set; }
        public string? SongAlbum { get; set; }
        public string? SongMime { get; set; }

    }
}
