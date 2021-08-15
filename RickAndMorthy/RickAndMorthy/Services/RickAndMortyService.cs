using Newtonsoft.Json;
using RickAndMorthy.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RickAndMorthy.Services
{
    public class RickAndMortyService
    {
        readonly HttpClient httpClient;

        public RickAndMortyService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <summary>
        /// it allows to get all Rick and Morthy characters
        /// </summary>
        /// <returns></returns>
        public async Task<(bool isValid, string message, Response<ObservableCollection<Character>> response)> GetCharactersAsync()
        {
            using var response = await this.httpClient.GetAsync("character");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Response<ObservableCollection<Character>>>(content);

                return (true, default, result);
            }

            return (false, response.ReasonPhrase, default);
        }

        /// <summary>
        /// Gets the name of the single location by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public async Task<Location> GetSingleLocationByName(string name)
        {
            using var response = await this.httpClient.GetAsync($"location?name={name}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Response<IEnumerable<Location>>>(content);

                return result.results.FirstOrDefault();
            }

            return default;
        }

    }
}
