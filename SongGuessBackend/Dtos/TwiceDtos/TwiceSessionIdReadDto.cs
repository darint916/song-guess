using System.ComponentModel.DataAnnotations;

namespace SongGuessBackend.Dtos.TwiceDtos
{
    public class TwiceSessionIdReadDto
    {
        [Required]
        public Guid SessionId { get; set; }
    }
}
