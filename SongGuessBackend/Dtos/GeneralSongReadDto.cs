using System.ComponentModel.DataAnnotations;

namespace SongGuessBackend.Dtos
{
    public class GeneralSongReadDto
    {
        [Required]
        public string SongName { get; set; }
        public string? SongAlbum { get; set; }
    }
}
