using Newtonsoft.Json;

namespace CryptoMVVMprism.Models
{
    public class CoinsDetailModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public DescriptionModel Description { get; set; }
        [JsonProperty("image")]
        public ImageModel imageModel { get; set; }
        [JsonProperty("market_data")]
        public MarketDataModel MarketData { get; set; }
    }
}
