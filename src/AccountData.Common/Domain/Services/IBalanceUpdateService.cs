using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;

namespace AccountData.Common.Domain.Services
{
    public interface IBalanceUpdateService
    {
        Task<IReadOnlyList<BalanceUpdate>> GetAllAsync(
            string brokerId, long id, string walletId, string assetId,
            ListSortDirection sortOrder = ListSortDirection.Ascending, long cursor = default, int limit = 50);

        Task<BalanceUpdate> GetByIdAsync(string brokerId, long id);
    }
}
