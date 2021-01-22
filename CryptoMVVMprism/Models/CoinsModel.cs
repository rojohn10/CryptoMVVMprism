using Newtonsoft.Json;

namespace CryptoMVVMprism.Models
{
    public class CoinsModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        public string NameSort => Name[0].ToString();
    }
}
