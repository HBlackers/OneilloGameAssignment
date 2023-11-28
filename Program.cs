using Microsoft.Extensions.DependencyInjection;
using O_neilloGame.Services;
using O_NeilloGame;

namespace O_neilloGame
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static ServiceProvider ConfigureServices() 
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<GameService>();
            services.AddSingleton<SettingsService>();
            services.AddSingleton<Main>();
            return services.BuildServiceProvider();
        }
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var services = ConfigureServices();
            Application.Run(services.GetService<Main>());

        }
    }
}