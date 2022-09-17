using AutoMapper;
using SongGuessBackend.Controllers;
using SongGuessBackend.Dtos.TwiceDtos;
using SongGuessBackend.Models;

namespace SongGuessBackend.Profiles
{
    public class SongUrlMapper : IMemberValueResolver<Song, TwiceSongReadDto, Guid, string>
    {
        private readonly LinkGenerator _linkGenerator;
        private readonly IHttpContextAccessor _contextAccessor;

        public SongUrlMapper(LinkGenerator linkGenerator, IHttpContextAccessor httpContextAccessor)
        {
            _linkGenerator = linkGenerator;
            _contextAccessor = httpContextAccessor;
        }

        public string? Resolve(Song source, TwiceSongReadDto destination, Guid sourceMember, string destMember,
            ResolutionContext context)
        {
            return _linkGenerator.GetUriByName(
                _contextAccessor.HttpContext,
                nameof(SongController.GetSong),
                new { Id = sourceMember },
                fragment: FragmentString.Empty);
        }
    }
}
