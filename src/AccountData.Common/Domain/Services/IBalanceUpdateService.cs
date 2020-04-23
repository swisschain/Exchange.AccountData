using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;
using AccountData.Common.Domain.Entities.Enums;

namespace AccountData.Common.Domain.Services
{
    public interface IBalanceUpdateService
    {
        Task<IReadOnlyList<BalanceUpdate>> GetAllAsync(
            string brokerId, long id, string wallet, string asset, BalanceUpdateEventType? eventType,
            ListSortDirection sortOrder = ListSortDirection.Ascending, long cursor = default, int limit = 50);

        Task<BalanceUpdate> GetByIdAsync(string brokerId, long id);

        Task<BalanceUpdateDetails> GetDetailsByIdAsync(string brokerId, long id);
    }
}
