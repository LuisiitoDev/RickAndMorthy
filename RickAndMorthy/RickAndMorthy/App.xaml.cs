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
        public static IServiceProvider ServiceProvider;
        public App()
        {
            InitializeComponent();
            var navigationPage = new NavigationPage(ServiceProvider.GetService<CharactersView>());
            MainPage = navigationPage;
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
