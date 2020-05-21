using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;

namespace AccountData.Common.Domain.Repositories
{
    public interface ITradeRepository
    {
        Task<IReadOnlyList<Trade>> GetAllAsync(
            string brokerId, string externalId, long accountId, long walletId, string baseAsset, string quotingAsset,
            ListSortDirection sortOrder = ListSortDirection.Ascending, string cursor = null, int limit = 50);

        Task<Trade> GetByIdAsync(string brokerId, long id);
    }
}
