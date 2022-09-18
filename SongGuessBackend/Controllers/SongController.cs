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
    [Route("api/artists/twice")]
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

        [HttpPatch("song/{sessionId:Guid}",Name = nameof(GetSong))]
        public async Task<IActionResult> GetSong(Guid sessionId)
        {
            var song = await _twiceSongRepo.GetSong(sessionId);
            _twiceSongRepo.SaveChanges();
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
        [HttpGet("users/{nameId}", Name = nameof(GetSessionID))]
        public async Task<IActionResult> GetSessionID(string nameId)
        {
            var sessionInfo = await _twiceSongRepo.GetSessionId(nameId);
            if (sessionInfo == null)
            {
                return NotFound();
            }
            var mapItem = _mapper.Map<TwiceSessionIdReadDto>(sessionInfo);
            return Ok(mapItem);
        }

        /*
         * TODO: Implement with password and dto body. Authentication
         * TODO: add created at route
         * Creates user with scrambled song ids
         */

        [HttpPost("users/{username}", Name = nameof(CreateSession))]
        public async Task<ActionResult> CreateSession(string username) 
        {
            _twiceSongRepo.CreateSession(username);
            _twiceSongRepo.SaveChanges();

            return CreatedAtRoute(nameof(GetSessionID), new { nameId = username }, username); //Change content in the future
        }

        [HttpGet()]

        [DevelopmentOnly]
        [HttpPost("song", Name ="nameof(CreateSong)")]
        public async Task<ActionResult> CreateSong(IEnumerable<SongCreateDto> songCreateDto)
        {
            _twiceSongRepo.CreateSong(songCreateDto);
            _twiceSongRepo.SaveChanges();
            return Ok();
        }

        [DevelopmentOnly]
        [HttpGet("song/{id}", Name = nameof(GetSongInfo))]
        public async Task<ActionResult> GetSongInfo(int id)
        {
            var song = await _twiceSongRepo.GetSongInfo(id);
            return Ok(song);
        }
    }
}