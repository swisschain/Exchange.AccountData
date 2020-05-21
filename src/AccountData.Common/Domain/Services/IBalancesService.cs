using System.ComponentModel;
using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;

namespace AccountData.Common.Domain.Services
{
    public interface IBalancesService
    {
        Task<Balances> GetAllAsync(string brokerId, long accountId, long walletId, string asset,
            ListSortDirection sortOrder = ListSortDirection.Ascending, long cursor = default, int limit = 50);

        Task<Balances> GetByAssetIdAsync(string brokerId, long accountId, long walletId, string asset);
    }
}
