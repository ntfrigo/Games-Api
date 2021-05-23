using Games.Service.Interface;
using Games.Service.Service;
using Microsoft.Extensions.DependencyInjection;

namespace GamesApi.Extentions
{
    public static class ServiceDependencyInjection
    {
        public static void AddServiceScoped(this IServiceCollection services)
        {
            services.AddScoped<IGameService, GameService>();

        }
    }
}
