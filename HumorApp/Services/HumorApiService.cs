using HumorApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HumorApp.Services
{
    public class HumorApiService
    {
        // HTTP-клиент для выполнения запросов к API
        private readonly HttpClient _client;

        // API-ключ для авторизации
        private readonly string _apiKey = "700ede184cde42d785cce493d3a99c00";

        // Базовый адрес Humor API
        private readonly string _baseUrl = "https://api.humorapi.com";

        public HumorApiService()
        {
            _client = new HttpClient();

            // Добавляем API-ключ в заголовок каждого запроса
            _client.DefaultRequestHeaders.Add("X-Api-Key", _apiKey);
        }

        // Получение случайной шутки
        public async Task<Joke> GetRandomJokeAsync()
        {
            // Формируем URL для запроса
            string url = $"{_baseUrl}/jokes/random";

            // Отправляем GET-запрос и получаем ответ в формате JSON
            string response = await _client.GetStringAsync(url);

            // Преобразуем JSON в объект Joke
            return JsonConvert.DeserializeObject<Joke>(response);
        }

        // Поиск шуток по ключевому слову
        public async Task<List<Joke>> SearchJokesAsync(string keyword)
        {
            // Добавляем поисковый запрос в URL
            string url = $"{_baseUrl}/jokes/search?query={keyword}";

            // Получаем ответ от сервера
            string response = await _client.GetStringAsync(url);

            // Преобразуем JSON в объект ответа
            var result = JsonConvert.DeserializeObject<JokeSearchResponse>(response);

            // Если список отсутствует, возвращаем пустую коллекцию
            return result?.Jokes ?? new List<Joke>();
        }
    }
}