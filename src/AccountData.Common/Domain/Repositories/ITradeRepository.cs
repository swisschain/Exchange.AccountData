using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;

namespace AccountData.Common.Domain.Repositories
{
    public interface ITradeRepository
    {
        Task<IReadOnlyList<Trade>> GetAllAsync(
            string brokerId, long id, string externalId, string walletId, string baseAssetId, string quotingAssetId,
            ListSortDirection sortOrder = ListSortDirection.Ascending, long cursor = default, int limit = 50);

        Task<Trade> GetByIdAsync(string brokerId, long id);
    }
}
