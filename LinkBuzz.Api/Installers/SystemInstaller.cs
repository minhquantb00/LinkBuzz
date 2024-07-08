
namespace LinkBuzz.Api.Installers
{
    public class SystemInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
        }
    }
}
