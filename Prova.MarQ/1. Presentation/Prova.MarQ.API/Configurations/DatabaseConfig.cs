using Microsoft.EntityFrameworkCore;
using Prova.MarQ.Infra.Context;

namespace Prova.MarQ.API.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<ProvaMarQContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("ProvaMarQDB")));

        }
    }
}
