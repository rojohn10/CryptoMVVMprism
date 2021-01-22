using CryptoMVVMprism.Interfaces;
using CryptoMVVMprism.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CryptoMVVMprism.Services
{
    public class ApiServices : ICoins
    {
        public async Task<List<CoinsModel>> GetCoinsList()
        {
            var coinsUrl = "https://api.coingecko.com/api/v3/coins/list";
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, coinsUrl);
            httpRequestMessage.Headers.Add("Accept", "application/json");
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage responseMessage = await httpClient.SendAsync(httpRequestMessage);
            string responseAsString = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<CoinsModel>>(responseAsString);
        }

        public async Task<CoinsDetailModel> GetCoinsDetails(string id)
        {
            var coinsId = id;
            var coinsUrl = $"https://api.coingecko.com/api/v3/coins/{coinsId}";
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, coinsUrl);
            httpRequestMessage.Headers.Add("Accept", "application/json");
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage responseMessage = await httpClient.SendAsync(httpRequestMessage);
            string responseAsString = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CoinsDetailModel>(responseAsString);
        }
    }
}
