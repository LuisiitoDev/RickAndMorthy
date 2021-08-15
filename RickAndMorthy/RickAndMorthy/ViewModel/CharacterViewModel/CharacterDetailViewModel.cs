using Microsoft.AppCenter;
using RickAndMorthy.Model;
using RickAndMorthy.Services;
using RickAndMorthy.Utils;
using System;
using System.Threading.Tasks;

namespace RickAndMorthy.ViewModel.CharacterViewModel
{
    public class CharacterDetailViewModel : BaseViewModel
    {
        /// <summary>The service</summary>
        readonly RickAndMortyService service;
        /// <summary>The logging</summary>
        readonly LoggingService logging;

        Location location;
        Character character;
        public Character Character { get => character; set => SetProperty(ref character, value); }
        public Location Location { get => location; set => SetProperty(ref location, value); }

        public CharacterDetailViewModel(RickAndMortyService service, LoggingService logging)
        {
            this.service = service;
            this.logging = logging;
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
    }
}
