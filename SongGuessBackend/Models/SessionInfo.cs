using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

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
        public Boolean GuessedCurrent { get; set; }
        public string Mode { get; set; }
        public int Score { get; set; }
        public int SongsGuessed { get; set; }
    }
}
