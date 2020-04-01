using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;

namespace AccountData.Common.Domain.Services
{
    public interface IBalancesService
    {
        Task<Balances> GetAllAsync(string walletId);

        Task<Balances> GetByAssetIdAsync(string walletId, string assetId);
    }
}
