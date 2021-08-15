using RickAndMorthy.Data.Model;
using RickAndMorthy.Data.Repository;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RickAndMorthy.ViewModel.Submenu
{
    public class FavoritesViewModel : BaseViewModel
    {
        /// <summary>Favorite Repository</summary>
        readonly FavoriteRepository favoriteRepository;

        ObservableCollection<Favorite> favorites;
        public ObservableCollection<Favorite> Favorites { get => favorites; set => SetProperty(ref favorites, value); }

        public FavoritesViewModel(FavoriteRepository favoriteRepository)
        {
            this.favoriteRepository = favoriteRepository;
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
    }
}
