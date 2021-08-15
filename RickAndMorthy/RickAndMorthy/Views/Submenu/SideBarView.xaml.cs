using RickAndMorthy.ViewModel.Submenu;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RickAndMorthy.Views.Submenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SideBarView : ContentPage
    {
        public SideBarView(SideBarViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}