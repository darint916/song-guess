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

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}