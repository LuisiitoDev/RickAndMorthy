using RickAndMorthy.ViewModel.Submenu;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RickAndMorthy.Views.Submenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritesView : ContentPage
    {
        public FavoritesView(FavoritesViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}