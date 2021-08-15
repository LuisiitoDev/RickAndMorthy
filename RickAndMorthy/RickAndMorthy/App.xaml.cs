using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RickAndMorthy.Services;
using RickAndMorthy.ViewModel.CharacterViewModel;
using RickAndMorthy.Views.Character;
using System;
using System.Reflection;
using Xamarin.Forms;

namespace RickAndMorthy
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            ConfigureApp();
        }

        void ConfigureApp()
        {
            var services = new ServiceCollection();
            var configStream = GetType()
                                .GetTypeInfo()
                                .Assembly.GetManifestResourceStream("RickAndMorthy.appsetting.json");

            RegisterPages(services);

            var configuration = new ConfigurationBuilder()
                                    .AddJsonStream(configStream)
                                    .Build();

            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<RickAndMortyService>();

            services.AddHttpClient("Service", config => {
                config.BaseAddress = new Uri(configuration["rickAndMorthyService"]);
            });

            var serviceProvider = services.BuildServiceProvider();

            MainPage = serviceProvider.GetService<CharactersView>();

        }

        void RegisterPages(ServiceCollection services)
        {
            services.AddScoped<CharactersViewModel>();
            services.AddScoped<CharactersView>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
