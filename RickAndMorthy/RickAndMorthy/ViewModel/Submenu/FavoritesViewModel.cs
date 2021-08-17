using RickAndMorthy.Data.Model;
using RickAndMorthy.Data.Repository;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RickAndMorthy.ViewModel.Submenu
{
    public class FavoritesViewModel : BaseViewModel
    {
        /// <summary>Favorite Repository</summary>
        readonly FavoriteRepository favoriteRepository;

        ObservableCollection<Favorite> favorites;
        public ObservableCollection<Favorite> Favorites { get => favorites; set => SetProperty(ref favorites, value); }

        public ICommand DeleteFavoriteCommand { get; set; }

        public FavoritesViewModel(FavoriteRepository favoriteRepository)
        {
            this.favoriteRepository = favoriteRepository;
            Task.Run(async () => await this.LoadFavorites());

            DeleteFavoriteCommand = new Command<Favorite>(async favorite => await this.DeleteFavorite(favorite));
        }

        /// <summary>
        /// it allows to get all favorites stored in local database
        /// </summary>
        /// <returns></returns>
        async Task LoadFavorites()
        {
            var favoriteList = await this.favoriteRepository.GetAllFavoritesAsync();
            this.Favorites = new ObservableCollection<Favorite>(favoriteList);
        }

        /// <summary>
        /// it allows to delete a favorite chosen
        /// </summary>
        /// <param name="favorite"></param>
        /// <returns></returns>
        async Task DeleteFavorite(Favorite favorite)
        {
            await this.favoriteRepository.RemoveFavoriteAsync(favorite);
        }
    }
}
