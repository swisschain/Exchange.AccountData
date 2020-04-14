using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;

namespace AccountData.Common.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<IReadOnlyList<Order>> GetAllAsync(
            string brokerId, long id, string walletId, string assetPairId,
            ListSortDirection sortOrder = ListSortDirection.Ascending, long cursor = default, int limit = 50);

        Task<Order> GetByIdAsync(string brokerId, long id);
    }
}
