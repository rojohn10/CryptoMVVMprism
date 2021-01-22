using Newtonsoft.Json;

namespace CryptoMVVMprism.Models
{
    public class MarketDataModel
    {
        [JsonProperty("current_price")]
        public CurrentPriceModel CurrentPrice { get; set; }
    }
}
