using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;
using AccountData.Common.Domain.Repositories;
using AccountData.Common.Domain.Services;
using Microsoft.Extensions.Logging;

namespace AccountData.Common.Services
{
    public class TradeService : ITradeService
    {
        private readonly ITradeRepository _tradeRepository;
        private readonly ILogger<TradeService> _logger;

        public TradeService(ITradeRepository tradeRepository,
            ILogger<TradeService> logger)
        {
            _tradeRepository = tradeRepository;
            _logger = logger;
        }

        public Task<IReadOnlyList<Trade>> GetAllAsync(
            string brokerId, long id, string tradeId, string walletId, string oppositeWalletId,
            long orderId, string oppositeOrderId, string oppositeExternalOrderId,
            long orderHistoryId, string baseAssetId, string quotingAssetId,
            ListSortDirection sortOrder = ListSortDirection.Ascending, long cursor = default, int limit = 50)
        {
            return _tradeRepository.GetAllAsync(brokerId, id, tradeId, walletId, oppositeWalletId,
                orderId, oppositeOrderId, oppositeExternalOrderId, orderHistoryId, baseAssetId, quotingAssetId,
                sortOrder, cursor, limit);
        }

        public Task<Trade> GetByIdAsync(string brokerId, long id)
        {
            return _tradeRepository.GetByIdAsync(brokerId, id);
        }
    }
}
