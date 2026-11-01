using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DAL.EF;

namespace BLL.Extensions
{
    public static class MovieContextExtensions
    {
        public static void AddMovieContext(this IServiceCollection services, string connection) =>
            services.AddDbContext<MovieContext>(options => options.UseSqlServer(connection));
    }
}
