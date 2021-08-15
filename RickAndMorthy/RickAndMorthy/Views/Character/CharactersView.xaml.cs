

using RickAndMorthy.ViewModel.CharacterViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RickAndMorthy.Views.Character
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharactersView : ContentPage
    {
        public CharactersView(CharactersViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}