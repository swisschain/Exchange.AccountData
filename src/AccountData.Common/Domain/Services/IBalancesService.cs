using System.Collections.Generic;
using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;

namespace AccountData.Common.Domain.Services
{
    public interface IBalancesService
    {
        Task<IReadOnlyList<Balance>> GetAllAsync(string walletId);

        Task<Balance> GetByAssetIdAsync(string walletId, string assetId);
    }
}
