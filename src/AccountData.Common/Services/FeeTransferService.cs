using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;
using AccountData.Common.Domain.Repositories;
using AccountData.Common.Domain.Services;
using Microsoft.Extensions.Logging;

namespace AccountData.Common.Services
{
    public class FeeTransferService : IFeeTransferService
    {
        private readonly IFeeTransferRepository _feeTransferRepository;
        private readonly ILogger<FeeTransferService> _logger;

        public FeeTransferService(IFeeTransferRepository feeTransferRepository,
            ILogger<FeeTransferService> logger)
        {
            _feeTransferRepository = feeTransferRepository;
            _logger = logger;
        }

        public Task<IReadOnlyList<FeeTransfer>> GetAllAsync(
            string brokerId, long id, long fromAccountId, long toAccountId, long fromWalletId, long toWalletId, int orderId, string assetId,
            ListSortDirection sortOrder = ListSortDirection.Ascending, long cursor = default, int limit = 50)
        {
            return _feeTransferRepository.GetAllAsync(brokerId, id, fromAccountId, toAccountId, fromWalletId, toWalletId, orderId, assetId,
                sortOrder, cursor, limit);
        }

        public Task<FeeTransfer> GetByIdAsync(string brokerId, long id)
        {
            return _feeTransferRepository.GetByIdAsync(brokerId, id);
        }
    }
}
