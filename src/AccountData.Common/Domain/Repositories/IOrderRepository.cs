using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;
using AccountData.Common.Domain.Entities.Enums;

namespace AccountData.Common.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<IReadOnlyList<Order>> GetAllAsync(
            string brokerId, long id, string externalId, long accountId, long walletId, string assetPairId,
            OrderType? orderType, OrderSide? side, OrderStatus? status, OrderTimeInForce? timeInForce,
            ListSortDirection sortOrder = ListSortDirection.Ascending, long cursor = default, int limit = 50);

        Task<Order> GetByIdAsync(string brokerId, long id);
    }
}
