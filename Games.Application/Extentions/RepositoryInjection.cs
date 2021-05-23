using Games.Repository.Interface;
using Games.Repository.Service;
using Microsoft.Extensions.DependencyInjection;

namespace GamesApi.Extentions
{
    public static class RepositoryDependencyInjection
    {
        public static void AddRepositoryScoped(this IServiceCollection services)
        {
            services.AddScoped<IGameRepository, GameRepository>();


        }
    }
}
