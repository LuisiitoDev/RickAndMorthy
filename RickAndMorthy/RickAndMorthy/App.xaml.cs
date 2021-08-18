using Microsoft.Extensions.DependencyInjection;
using RickAndMorthy.Views.Application;
using RickAndMorthy.Views.Character;
using RickAndMorthy.Views.Submenu;
using System;
using Xamarin.Forms;

namespace RickAndMorthy
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider;
        public App()
        {
            InitializeComponent();
            var tabbedPage = ServiceProvider.GetService<TabApplicationView>();
            MainPage = tabbedPage;
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
