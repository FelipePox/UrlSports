using HelpURL.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HelpURL.WebApi.Configurations
{
    public static class DataBaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            if (services is null) throw new ArgumentNullException(nameof(services));
            string connection = configuration.GetConnectionString("URLConnection")!;

            services.AddDbContext<HelpURLContext>(options =>
            {
                options.UseMySql(connection, ServerVersion.AutoDetect(connection),
                    options => options.EnableRetryOnFailure())
                .EnableSensitiveDataLogging();
            });

        }
    }
}
