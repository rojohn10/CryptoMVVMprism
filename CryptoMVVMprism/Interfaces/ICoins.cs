using CryptoMVVMprism.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoMVVMprism.Interfaces
{
    public interface ICoins
    {
        Task<List<CoinsModel>> GetCoinsList();
        Task<CoinsDetailModel> GetCoinsDetails(string id);
    }
}
