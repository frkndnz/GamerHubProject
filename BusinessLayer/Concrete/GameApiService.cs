using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.ApiModel;

namespace BusinessLayer.Concrete
{
    public class GameApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public GameApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ApiGame>> GetGamesFromApiAsync()
        {


            var response = await _httpClient.GetStringAsync("https://api.rawg.io/api/games?key=0f7ecc270ffe4029b2f68e73143055e0&page=1&page_size=12");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var games = JsonSerializer.Deserialize<ApiGameList>(response, options);

            return games.Results;

        }
        public class ApiGameList
        {
            public List<ApiGame> Results { get; set; }
        }
    }
}