using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;

namespace AccountData.Common.Domain.Services
{
    public interface IOrderHistoryService
    {
        Task<IReadOnlyList<OrderHistory>> GetAllAsync(
            string brokerId, long id, long accountId, long walletId, string assetPairId,
            ListSortDirection sortOrder = ListSortDirection.Ascending, long cursor = default, int limit = 50);

        Task<OrderHistory> GetByIdAsync(string brokerId, long id);
    }
}
