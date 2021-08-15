using RickAndMorthy.Model;
using RickAndMorthy.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RickAndMorthy.ViewModel.CharacterViewModel
{
    public class CharactersViewModel : BaseViewModel
    {
        Response<ObservableCollection<Character>> characters;
        public Response<ObservableCollection<Character>> Characters
        {
            get => characters;
            set => SetProperty(ref characters, value);
        }

        public CharactersViewModel(RickAndMortyService service)
        {
            Task.Run(() => LoadCharacters(service));
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
                    this.Characters = response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
