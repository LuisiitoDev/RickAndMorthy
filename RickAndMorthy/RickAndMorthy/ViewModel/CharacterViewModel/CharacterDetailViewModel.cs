using Microsoft.AppCenter;
using RickAndMorthy.Data.Model;
using RickAndMorthy.Data.Repository;
using RickAndMorthy.Model;
using RickAndMorthy.Services;
using RickAndMorthy.Utils;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RickAndMorthy.ViewModel.CharacterViewModel
{
    public class CharacterDetailViewModel : BaseViewModel
    {
        /// <summary>The service</summary>
        readonly RickAndMortyService service;
        /// <summary>The logging</summary>
        readonly LoggingService logging;
        /// <summary>The repository of favorites</summary>
        readonly FavoriteRepository favoriteRepository;

        Location location;
        Character character;
        public Character Character { get => character; set => SetProperty(ref character, value); }
        public Location Location { get => location; set => SetProperty(ref location, value); }

        public ICommand AddFavoriteCommand { get; set; }

        public CharacterDetailViewModel(RickAndMortyService service, LoggingService logging, FavoriteRepository favoriteRepository)
        {
            this.service = service;
            this.logging = logging;
            this.favoriteRepository = favoriteRepository;

            this.AddFavoriteCommand = new Command(async () => await this.AddFavorite());
        }

        /// <summary>
        /// Initializes the character informaction.
        /// </summary>
        /// <param name="characterSelected">The character selected.</param>
        public async Task InitCharacterInformaction(Character characterSelected)
        {
            LoadingUtils.ShowLoading("Loading information...");
            try
            {
                this.Character = characterSelected;
                this.Location = await service.GetSingleLocationByName(characterSelected.location.name);
            }
            catch (Exception ex)
            {
                logging.Log(this, LogLevel.Error, ex);
            }
            finally
            {
                LoadingUtils.HideLoading();
            }
        }

        /// <summary>
        /// it allows to store this character as a favorite
        /// </summary>
        /// <returns></returns>
        public async Task AddFavorite()
        {
            try
            {
                Favorite favorite = new()
                {
                    Image = this.character.image,
                    Name = this.character.name,
                    Id = this.character.id
                };

                await this.favoriteRepository.AddFavoriteAsync(favorite);
            }
            catch (Exception ex)
            {
                this.logging.Log(this,LogLevel.Error, ex);
            }
        }
    }
}
