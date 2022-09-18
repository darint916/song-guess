using System.ComponentModel.DataAnnotations;

namespace SongGuessBackend.Models
{
    public class Leaderboard
    {
        [Key]
        [Required]
        public Guid SessionId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Mode { get; set; }
        [Required]
        public int SongsGuessed { get; set; }
    }
}
