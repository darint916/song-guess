using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SongGuessBackend.Data;
using SongGuessBackend.Dtos;
using SongGuessBackend.Dtos.TwiceDtos;
using SongGuessBackend.Filters;

namespace SongGuessBackend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api")]
    [EnableCors("AllowFrontEnd")]
    public class SongController : ControllerBase
    {
        private ISongRepo _twiceSongRepo;
        private IMapper _mapper;

        public SongController(ISongRepo twiceSongRepo, IMapper mapper)
        {
            _twiceSongRepo = twiceSongRepo;
            _mapper = mapper;
        }

        [HttpGet("id/{sessionId:Guid}",Name = "nameof(GetSong)")]
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

        /*
         * TODO: Add search with password
         * Creates user with scrambled song ids
         */
        [HttpGet("{username}", Name = "nameof(GetSessionID)")]
        public async Task<IActionResult> GetSessionID(string username)
        {
            var sessionInfo = await _twiceSongRepo.GetSessionId(username);
            if (sessionInfo == null)
            {
                return NotFound();
            }
            var mapItem = _mapper.Map<TwiceSessionIdReadDto>(sessionInfo);
            return Ok(mapItem);
        }

        /*
         * TODO: Implement with password and dto body. Authentication
         * Creates user with scrambled song ids
         */

        [HttpPost("NewSession{username}", Name = "nameof(CreateSession)")]
        public async Task<ActionResult> CreateSession(string username) 
        {
            _twiceSongRepo.CreateSession(username);
            _twiceSongRepo.SaveChanges();

            return CreatedAtRoute(nameof(GetSessionID), new { username }, username); //Change content in the future
        }

        [DevelopmentOnly]
        [HttpPost("CreateSong")]
        public async Task<ActionResult> CreateSong(IEnumerable<SongCreateDto> songCreateDto)
        {
            _twiceSongRepo.CreateSong(songCreateDto);
            _twiceSongRepo.SaveChanges();
            return Ok();
        }
    }
}