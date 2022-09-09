using System.ComponentModel.DataAnnotations;

namespace SongGuessBackend.Models
{
    public class SessionInfo
    {
        [Key]
        [Required]
        public Guid SessionId { get; set; }
        public string Username { get; set; }
        public int Seed { get; set; }
        public int SongNumber { get; set; }
        public List<int> RandomSongIndexList { get; set; }

    }
}
