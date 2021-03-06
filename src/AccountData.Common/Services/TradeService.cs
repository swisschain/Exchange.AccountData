﻿using System.Collections.Generic;
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
            string brokerId, string externalId, long accountId, long walletId, string baseAsset, string quotingAsset,
            ListSortDirection sortOrder = ListSortDirection.Ascending, string cursor = null, int limit = 50)
        {
            return _tradeRepository.GetAllAsync(brokerId, externalId, accountId, walletId, baseAsset, quotingAsset,
                sortOrder, cursor, limit);
        }

        public Task<Trade> GetByIdAsync(string brokerId, long id)
        {
            return _tradeRepository.GetByIdAsync(brokerId, id);
        }
    }
}
