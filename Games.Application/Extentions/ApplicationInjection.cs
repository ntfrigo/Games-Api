using Games.Application.Interface;
using Games.Application.Service;
using Microsoft.Extensions.DependencyInjection;

namespace GamesApi.Extentions
{
    public static class ApplicationInjection
    {
        public static void AddApplicationScoped(this IServiceCollection services)
        {
            services.AddScoped<IGameApp, GameApp>();


        }
    }
}
