
using LinkBuzz.Domain.Helpers;
using LinkBuzz.Infrastructure.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace LinkBuzz.Api.Installers
{
    public class DbContextInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(configuration.GetConnectionString(Constants.AppSettingKeys.DEFAULT_CONNECTION), x => x.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
        }
    }
}
