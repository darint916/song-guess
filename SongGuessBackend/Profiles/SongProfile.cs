using AutoMapper;
using SongGuessBackend.Dtos;
using SongGuessBackend.Dtos.TwiceDtos;
using SongGuessBackend.Models;

namespace SongGuessBackend.Profiles
{
    public class SongProfile : Profile
    {
        public SongProfile()
        {
            CreateMap<Song, TwiceSongReadDto>()
                .ForMember(a => a.Url,
                    t => t.MapFrom<SongUrlMapper, Guid>(song => song.SongId));
            CreateMap<SessionInfo, TwiceSessionIdReadDto>();
            CreateMap<Song, GeneralSongReadDto>();
        }
    }
}
