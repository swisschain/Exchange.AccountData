using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;
using AccountData.Common.Domain.Repositories;
using AccountData.Common.Domain.Services;
using Microsoft.Extensions.Logging;

namespace AccountData.Common.Services
{
    public class OrderHistoryService : IOrderHistoryService
    {
        private readonly IOrderHistoryRepository _orderHistoryRepository;
        private readonly ILogger<OrderService> _logger;

        public OrderHistoryService(IOrderHistoryRepository orderHistoryRepository,
            ILogger<OrderService> logger)
        {
            _orderHistoryRepository = orderHistoryRepository;
            _logger = logger;
        }

        public Task<IReadOnlyList<OrderHistory>> GetAllAsync(
            string brokerId, long id, string walletId, string assetPairId,
            ListSortDirection sortOrder = ListSortDirection.Ascending, long cursor = default, int limit = 50)
        {
            return _orderHistoryRepository.GetAllAsync(brokerId, id, walletId, assetPairId,
                sortOrder, cursor, limit);
        }

        public Task<OrderHistory> GetByIdAsync(string brokerId, long id)
        {
            return _orderHistoryRepository.GetByIdAsync(brokerId, id);
        }
    }
}
