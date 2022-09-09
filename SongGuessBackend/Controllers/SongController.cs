using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SongGuessBackend.Data;

namespace SongGuessBackend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SongController : ControllerBase
    {
        private ISongRepo _twiceSongRepo;
        private IMapper _mapper;

        public SongController(ISongRepo twiceSongRepo, IMapper mapper)
        {
            _twiceSongRepo = twiceSongRepo;
            _mapper = mapper;
        }

        [HttpGet("{sessionId:Guid}",Name = "nameof(GetSong)")]
        public async Task<IActionResult> GetSong(Guid sessionId)
        {
            var song = await _twiceSongRepo.GetSong(sessionId);
            if (song == null)
            {
                return NotFound();
            }

            FileStream fileStream = new FileStream(song.SongPath, FileMode.Open);

            return File(fileStream, song.SongMime, song.SongName);
        }

        [HttpGet("{username:string}", Name = "nameof(GetSessionID)")]
        public async Task<IActionResult> GetSessionID(string username)
        {
            var sessionInfo = await _twiceSongRepo.GetSessionId(username);
            if (sessionInfo == null)
            {
                return NotFound();
            }
            
        }
    }
}