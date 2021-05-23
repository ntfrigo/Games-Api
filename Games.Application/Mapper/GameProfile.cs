using AutoMapper;
using Games.Application.ViewModel;
using Games.Domain.Entity;

namespace Games.Application.Mapper
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameViewModel>()
                .ForMember(dst => dst.Descricao, map => map.MapFrom(src => $"{src.Id} - {src.Nome}"))
                .ReverseMap();

            CreateMap<Game, GameInputViewModel>()
                .ReverseMap();

        }
    }
}
