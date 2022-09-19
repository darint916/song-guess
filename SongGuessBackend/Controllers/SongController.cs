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
using SongGuessBackend.Models;

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

        /*
         * 
         * PATCH api/artists/twice/song/{sessionId:Guid}
         * Changes song index, and returns song file
         */
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

            return File(fileStream, song.SongMime, song.SongId.ToString());
        }

        /*
         * TODO: Add password and token to search
         * GET api/artists/twice/users/{nameId}
         * Searches for session id given username (and password TBD)
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
         *
         * POST api/artists/twice/users/{username}
         * Creates user entry into db with username
         */

        [HttpPost("users/{username}", Name = nameof(CreateSession))]
        public async Task<ActionResult> CreateSession(string username) 
        {
            _twiceSongRepo.CreateSession(username);
            _twiceSongRepo.SaveChanges();

            return CreatedAtRoute(nameof(GetSessionID), new { nameId = username }, username); //Change content in the future
        }

        /*
         * TODO: ADD Query for determining when player gives up, revealing song name, disable song add
         * PATCH api/artists/twice/users/{sessionId:Guid}/song/{songName}/verify
         * Called when guessing, checks if song name matches, adds to score
         */
        [HttpPatch("users/{sessionId:Guid}/song/{songName}/verify", Name = nameof(VerifySong))]
        public async Task<ActionResult> VerifySong(Guid sessionId, string songName)
        {
            var response = await _twiceSongRepo.VerifySong(sessionId, songName);
            if (response == null)
            {
                return NoContent();
            }
            _twiceSongRepo.SaveChanges();
            return Ok(response);
        }

        /*
         * GET api/artists/twice/song
         * Gets all song names for option search when guessing
         */
        [HttpGet("song", Name = nameof(GetAllSongs))]
        public async Task<ActionResult<IEnumerable<GeneralSongReadDto>>>GetAllSongs()
        {
            var songList = await _twiceSongRepo.GetAllSongs();
            return Ok(_mapper.Map<IEnumerable<GeneralSongReadDto>>(songList));
        }

        /*
         * POST api/artists/twice/song
         * Adds songs to database
         */
        [DevelopmentOnly]
        [HttpPost("song", Name =nameof(CreateSong))]
        public async Task<ActionResult> CreateSong(IEnumerable<SongCreateDto> songCreateDto)
        {
            _twiceSongRepo.CreateSong(songCreateDto);
            _twiceSongRepo.SaveChanges();
            return NoContent();
        }

        /*
         * GET api/artists/twice/song/{id}
         * Fetches all info about song
         */
        [DevelopmentOnly] 
        [HttpGet("song/{id}", Name = nameof(GetSongInfo))]
        public async Task<ActionResult<Song>> GetSongInfo(int id)
        {
            var song = await _twiceSongRepo.GetSongInfo(id);
            return Ok(song);
        }
    }
}