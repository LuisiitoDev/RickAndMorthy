using RickAndMorthy.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace RickAndMorthy.Services
{
    public class RickAndMortyService
    {
        readonly IHttpClientFactory httpClient;

        public RickAndMortyService(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <summary>
        /// it allows to get all Rick and Morthy characters
        /// </summary>
        /// <returns></returns>
        public async Task<(bool isValid, string message, Response<ObservableCollection<Character>> response)> GetCharactersAsync()
        {
            using (var client = this.httpClient.CreateClient("Service"))
            {
                var response = await client.GetAsync("character");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<Response<ObservableCollection<Character>>>(content);

                    return (true, default, result);
                }

                return (false, response.ReasonPhrase, default);
            }
        }

    }
}
