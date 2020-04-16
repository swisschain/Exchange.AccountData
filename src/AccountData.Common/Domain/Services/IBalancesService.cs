using System.Collections.Generic;
using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;

namespace AccountData.Common.Domain.Services
{
    public interface IBalancesService
    {
        Task<Balances> GetAllAsync(string brokerId, string walletId);

        Task<Balances> GetByAssetIdAsync(string brokerId, string walletId, string assetId);
    }
}
