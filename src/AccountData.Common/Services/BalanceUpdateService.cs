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
        private readonly ICashInRepository _cashInRepository;
        private readonly ICashOutRepository _cashOutRepository;
        private readonly ICashTransferRepository _cashTransferRepository;
        private readonly ILogger<BalanceUpdateService> _logger;

        public BalanceUpdateService(IBalanceUpdateRepository balanceUpdateRepository,
            ICashInRepository cashInRepository,
            ICashOutRepository cashOutRepository,
            ICashTransferRepository cashTransferRepository,
            ILogger<BalanceUpdateService> logger)
        {
            _balanceUpdateRepository = balanceUpdateRepository;
            _cashInRepository = cashInRepository;
            _cashOutRepository = cashOutRepository;
            _cashTransferRepository = cashTransferRepository;
            _logger = logger;
        }

        public Task<IReadOnlyList<BalanceUpdate>> GetAllAsync(
            string brokerId, long id, long accountId, long walletId, string asset, BalanceUpdateEventType? eventType,
            ListSortDirection sortOrder = ListSortDirection.Ascending, long cursor = default, int limit = 50)
        {
            return _balanceUpdateRepository.GetAllAsync(brokerId, id, accountId, walletId, asset, eventType,
                sortOrder, cursor, limit);
        }

        public Task<BalanceUpdate> GetByIdAsync(string brokerId, long id)
        {
            return _balanceUpdateRepository.GetByIdAsync(brokerId, id);
        }

        public async Task<BalanceUpdateDetails> GetDetailsByIdAsync(string brokerId, long id)
        {
            var balanceUpdate = await _balanceUpdateRepository.GetByIdAsync(brokerId, id);

            if (balanceUpdate == null)
                return null;

            BalanceUpdateDetails result = null;

            switch (balanceUpdate.EventType)
            {
                case BalanceUpdateEventType.CashIn:
                    var cashIn = await _cashInRepository.GetByBalanceUpdateIdAsync(brokerId, balanceUpdate.MessageId);

                    if (cashIn == null)
                        return null;

                    result = new BalanceUpdateDetails
                    {
                        Asset = cashIn.AssetId,
                        Volume = decimal.Parse(cashIn.Volume),
                        Type = BalanceUpdateType.CashIn,
                        Description = cashIn.Description
                    };
                    break;

                case BalanceUpdateEventType.CashOut:
                    var cashOut = await _cashOutRepository.GetByBalanceUpdateIdAsync(brokerId, balanceUpdate.MessageId);

                    if (cashOut == null)
                        return null;

                    result = new BalanceUpdateDetails
                    {
                        Asset = cashOut.AssetId,
                        Volume = decimal.Parse(cashOut.Volume),
                        Type = BalanceUpdateType.CashOut,
                        Description = cashOut.Description
                    };
                    break;

                case BalanceUpdateEventType.CashTransfer:
                    var cashTransfer = await _cashTransferRepository.GetByBalanceUpdateIdAsync(brokerId, balanceUpdate.MessageId);

                    if (cashTransfer == null)
                        return null;

                    result = new BalanceUpdateDetails
                    {
                        Asset = cashTransfer.AssetId,
                        Volume = decimal.Parse(cashTransfer.Volume),
                        Type = BalanceUpdateType.CashTransfer,
                        FromWalletId = cashTransfer.FromWalletId,
                        ToWalletId = cashTransfer.ToWalletId,
                        Description = cashTransfer.Description
                    };
                    break;

                default:
                    _logger.LogWarning("Unsupported type of balance update. {$BalanceUpdateEventType}", balanceUpdate.EventType);
                    break;
            }

            return result;
        }
    }
}
