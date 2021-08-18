
using RickAndMorthy.Views.Character;
using RickAndMorthy.Views.Submenu;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace RickAndMorthy.Views.Application
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabApplicationView : Xamarin.Forms.TabbedPage
    {
        public TabApplicationView()
        {
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            this.BarBackgroundColor = Color.FromHex("#193048");
            this.SelectedTabColor = Color.White;

            var favoritesPage = App.ServiceProvider.GetService<FavoritesView>();
            var characters = App.ServiceProvider.GetService<CharactersView>();

            Children.Add(new NavigationPage(characters) 
            {
                IconImageSource = "ic_rick.png",
                BarBackgroundColor = Color.FromHex("#193048")
            });
            Children.Add(favoritesPage);
        }

    }
}