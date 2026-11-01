using BLL.Services;
using DAL.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Extensions
{
    public static class MovieExtensions
    {
        public static void AddMovieServices(this IServiceCollection services)
        {
            services.AddScoped<IMovieServices, MovieServices>();
            services.AddScoped<IRepository, Repository>();
        }
    }
}
