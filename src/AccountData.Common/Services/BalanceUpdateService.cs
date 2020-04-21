using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;
using AccountData.Common.Domain.Entities.Enums;
using AccountData.Common.Domain.Repositories;
using AccountData.Common.Domain.Services;
using Microsoft.Extensions.Logging;

namespace AccountData.Common.Services
{
    public class BalanceUpdateService : IBalanceUpdateService
    {
        private readonly IBalanceUpdateRepository _balanceUpdateRepository;
        private readonly ILogger<BalanceUpdateService> _logger;

        public BalanceUpdateService(IBalanceUpdateRepository balanceUpdateRepository,
            ILogger<BalanceUpdateService> logger)
        {
            _balanceUpdateRepository = balanceUpdateRepository;
            _logger = logger;
        }

        public Task<IReadOnlyList<BalanceUpdate>> GetAllAsync(
            string brokerId, long id, string walletId, string asset, BalanceUpdateEventType eventType,
            ListSortDirection sortOrder = ListSortDirection.Ascending, long cursor = default, int limit = 50)
        {
            return _balanceUpdateRepository.GetAllAsync(brokerId, id, walletId, asset, eventType,
                sortOrder, cursor, limit);
        }

        public Task<BalanceUpdate> GetByIdAsync(string brokerId, long id)
        {
            return _balanceUpdateRepository.GetByIdAsync(brokerId, id);
        }
    }
}
