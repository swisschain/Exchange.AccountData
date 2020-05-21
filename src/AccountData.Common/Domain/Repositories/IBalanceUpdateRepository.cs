using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;
using AccountData.Common.Domain.Entities.Enums;

namespace AccountData.Common.Domain.Repositories
{
    public interface IBalanceUpdateRepository
    {
        Task<IReadOnlyList<BalanceUpdate>> GetAllAsync(
            string brokerId, long id, long accountId, long walletId, string asset, BalanceUpdateEventType? eventType,
            ListSortDirection sortOrder = ListSortDirection.Ascending, long cursor = default, int limit = 50);

        Task<BalanceUpdate> GetByIdAsync(string brokerId, long id);
    }
}
