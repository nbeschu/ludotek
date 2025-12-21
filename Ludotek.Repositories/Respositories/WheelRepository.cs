using Ludotek.Repositories.Interfaces;
using Ludotek.Repositories.Models;
using System.Text.Json;

namespace Ludotek.Repositories.Respositories
{
    public class WheelRepository : IWheelRepository
    {
        /// <summary>
        /// Le client HTTP
        /// </summary>
        public readonly HttpClient _httpClient;
        private const string ApiKey = "53e0b8ac-7f92-4476-b9a9-424e3250bd10";
        private const string BaseUrl = "https://wheelofnames.com/api/v2/wheels/private";

        /// <summary>
        /// Constructeur avec injection de dépendance
        /// </summary>
        public WheelRepository()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Récupère une roue
        /// </summary>
        /// <param name="nomRoue"></param>
        /// <returns>La roue ainsi trouvée</returns>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<Wheel> GetWheel(string nomRoue)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, BaseUrl);
            request.Headers.Add("x-api-key", ApiKey);

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Erreur lors de l'appel API de récupération de la roue : {response.StatusCode}");
            }

            var responseStream = await response.Content.ReadAsStreamAsync();

            var wheelResponse = await JsonSerializer.DeserializeAsync<WheelResponse>(responseStream, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true
            });

            if (wheelResponse == null)
            {
                throw new Exception("Pas de roue trouvée");
            }

            Wheel wheel = wheelResponse.Data?.Wheels?.FirstOrDefault(x => x.WheelConfig?.Title == nomRoue);

            if (wheel == null)
            {
                throw new Exception($"La roue '{nomRoue}' n'existe pas");
            }

            return wheel;
        }
    }
}
