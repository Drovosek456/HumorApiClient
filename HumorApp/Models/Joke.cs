using Newtonsoft.Json;

namespace HumorApp.Models
{
    public class Joke
    {
        public int Id { get; set; }

        [JsonProperty("joke")]
        public string JokeText { get; set; }
    }
}