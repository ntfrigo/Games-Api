using AutoMapper;
using Games.Application.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace Games.Application.Extentions
{
    public static class MapperExtention
    {
        public static void AddAutoMapperConfig(this IServiceCollection services)
        {
            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GameProfile>();
            }).CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
