using Microsoft.Extensions.DependencyInjection;
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
            var detailPage = ServiceProvider.GetService<CharactersView>();
            var masterPage = ServiceProvider.GetService<SideBarView>();

            MainPage = new FlyoutPage()
            {
                Detail = new NavigationPage(detailPage) { BarBackgroundColor = Color.FromHex("#193048") },
                Flyout = masterPage
            };
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
