namespace LinkBuzz.Api.Installers
{
    public static class InstallerExtentsions
    {
        public static void InstallerServiceInAsssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var installer = typeof(Program).Assembly.ExportedTypes.Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IInstaller>().ToList();


            installer.ForEach(installer => installer.InstallServices(services, configuration));
        }
    }
}
