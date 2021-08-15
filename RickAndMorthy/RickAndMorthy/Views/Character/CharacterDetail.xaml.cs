using RickAndMorthy.ViewModel.CharacterViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RickAndMorthy.Views.Character
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterDetail : ContentPage
    {
        public CharacterDetail(CharacterDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}