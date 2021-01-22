using Newtonsoft.Json;

namespace CryptoMVVMprism.Models
{
    public class CurrentPriceModel
    {
        [JsonProperty("usd")]
        public double Usd { get; set; }
    }
}
