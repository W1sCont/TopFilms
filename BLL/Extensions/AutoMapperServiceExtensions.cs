using Microsoft.Extensions.DependencyInjection;
using BLL.Profiles;

namespace BLL.Extensions
{
    public static class AutoMapperServiceExtensions
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MovieProfiles>();
            });
        }
    }
}
