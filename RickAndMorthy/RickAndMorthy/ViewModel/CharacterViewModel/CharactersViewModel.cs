using Microsoft.AppCenter;
using Microsoft.Extensions.DependencyInjection;
using RickAndMorthy.Model;
using RickAndMorthy.Services;
using RickAndMorthy.Views.Character;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RickAndMorthy.ViewModel.CharacterViewModel
{
    public class CharactersViewModel : BaseViewModel
    {
        /// <summary>Loggin Services to track errors and events for the app</summary>
        readonly LoggingService logging;
        /// <summary>Navigation services to navigate to other pages over the app flow</summary>
        readonly NavigationService navigationService;

        ObservableCollection<Character> characters;
        Response<ObservableCollection<Character>> charactersResponse;

        public ObservableCollection<Character> Characters { get => characters; set => SetProperty(ref characters, value); }
        public ICommand SelectCharacterCommand { get; set; }

        public CharactersViewModel(RickAndMortyService service, LoggingService logging, NavigationService navigationService)
        {
            this.logging = logging;
            this.navigationService = navigationService;

            Task.Run(() => LoadCharacters(service));

            SelectCharacterCommand = new Command<Character>(async character => await SelectCharacter(character));
        }

        /// <summary>
        /// it allows to load the characters to show up in the View
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        async Task LoadCharacters(RickAndMortyService service)
        {
            try
            {
                (bool isValid, string message, Response<ObservableCollection<Character>> response) = await service.GetCharactersAsync();

                if (isValid)
                {
                    this.charactersResponse = response;
                    this.Characters = response.results;
                }
            }
            catch (Exception ex)
            {
                logging.Log(this, LogLevel.Error, ex);
            }
        }

        /// <summary>
        /// Selects the character.
        /// </summary>
        /// <param name="character">The character.</param>
        async Task SelectCharacter(Character character)
        {
            await App.ServiceProvider.GetService<CharacterDetailViewModel>().InitCharacterInformaction(character);
            await navigationService.PushAsync(App.ServiceProvider.GetService<CharacterDetail>());
        }

    }
}
