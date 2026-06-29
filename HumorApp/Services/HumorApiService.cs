using HumorApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HumorApp.Services
{
    public class HumorApiService
    {
        private readonly HttpClient _client;
        private readonly string _apiKey = "700ede184cde42d785cce493d3a99c00";
        private readonly string _baseUrl = "https://api.humorapi.com";

        public HumorApiService()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("X-Api-Key", _apiKey);
        }

        // 1. Случайная шутка
        public async Task<Joke> GetRandomJokeAsync()
        {
            string url = $"{_baseUrl}/jokes/random";
            string response = await _client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<Joke>(response);
        }

        // 2. Поиск шуток по ключевому слову
        public async Task<List<Joke>> SearchJokesAsync(string keyword)
        {
            string url = $"{_baseUrl}/jokes/search?query={keyword}";
            string response = await _client.GetStringAsync(url);
            var result = JsonConvert.DeserializeObject<JokeSearchResponse>(response);
            return result?.Jokes ?? new List<Joke>();
        }
    }
}