using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;
using AccountData.Common.Domain.Repositories;
using AccountData.Common.Domain.Services;
using Microsoft.Extensions.Logging;

namespace AccountData.Common.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IOrderRepository orderRepository,
            ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        public Task<IReadOnlyList<Order>> GetAllAsync(
            string brokerId, long id, string walletId, string assetPairId,
            ListSortDirection sortOrder = ListSortDirection.Ascending, long cursor = default, int limit = 50)
        {
            return _orderRepository.GetAllAsync(brokerId, id, walletId, assetPairId,
                sortOrder, cursor, limit);
        }

        public Task<Order> GetByIdAsync(string brokerId, long id)
        {
            return _orderRepository.GetByIdAsync(brokerId, id);
        }
    }
}
