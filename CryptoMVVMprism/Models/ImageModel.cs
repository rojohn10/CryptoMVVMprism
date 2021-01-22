using Newtonsoft.Json;

namespace CryptoMVVMprism.Models
{
    public class ImageModel
    {
        [JsonProperty("thumb")]
        public string Thumb { get; set; }
    }
}
