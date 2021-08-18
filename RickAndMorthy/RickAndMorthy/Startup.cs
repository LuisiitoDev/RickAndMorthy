using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RickAndMorthy.Data.Repository;
using RickAndMorthy.Services;
using RickAndMorthy.Utils;
using RickAndMorthy.ViewModel.CharacterViewModel;
using RickAndMorthy.ViewModel.Submenu;
using RickAndMorthy.Views.Application;
using RickAndMorthy.Views.Character;
using RickAndMorthy.Views.Submenu;
using System;
using System.IO;
using Xamarin.Essentials;

namespace RickAndMorthy
{
    public static class Startup
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <returns></returns>
        public static App Init()
        {
            var systemDir = FileSystem.CacheDirectory;
            ResourceUtils.ExtractSaveResource("RickAndMorthy.appsetting.json",systemDir);
            var fullConfig = Path.Combine(systemDir, "RickAndMorthy.appsetting.json");

            var host = new HostBuilder()
                .ConfigureHostConfiguration(cfg =>
                {
                    cfg.AddCommandLine(new string[] { $"ContentRoot={FileSystem.AppDataDirectory}" });
                    cfg.AddJsonFile(fullConfig);
                })
                .ConfigureServices((builder, services) =>
                {
                    ServicesConfiguration(builder, services);
                })
                .Build();

            App.ServiceProvider = host.Services;

            return App.ServiceProvider.GetService<App>();
        }

        /// <summary>
        /// Serviceses the configuration.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        /// <param name="services">The services.</param>
        static void ServicesConfiguration(HostBuilderContext ctx, IServiceCollection services)
        {
            services.AddScoped<SideBarViewModel>();
            services.AddScoped<FavoritesViewModel>();
            services.AddScoped<SideBarView>();
            services.AddScoped<FavoritesView>();
            services.AddScoped<NavigationService>();
            services.AddScoped<RickAndMortyService>();
            services.AddScoped<LoggingService>();
            services.AddScoped<CharactersViewModel>();
            services.AddScoped<CharactersView>();
            services.AddScoped<CharacterDetailViewModel>();
            services.AddScoped<CharacterDetail>();
            services.AddScoped<FavoriteRepository>();
            services.AddScoped<TabApplicationView>();
            services.AddSingleton<App>();
            services.AddHttpClient<RickAndMortyService>()
                    .ConfigureHttpClient(cfg => cfg.BaseAddress = new Uri(ctx.Configuration["rickAndMorthyService"]));
        }
    }
}
