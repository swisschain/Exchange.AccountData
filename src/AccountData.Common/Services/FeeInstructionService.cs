using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;
using AccountData.Common.Domain.Repositories;
using AccountData.Common.Domain.Services;
using Microsoft.Extensions.Logging;

namespace AccountData.Common.Services
{
    public class FeeInstructionService : IFeeInstructionService
    {
        private readonly IFeeInstructionRepository _feeInstructionRepository;
        private readonly ILogger<FeeInstructionService> _logger;

        public FeeInstructionService(IFeeInstructionRepository feeInstructionRepository,
            ILogger<FeeInstructionService> logger)
        {
            _feeInstructionRepository = feeInstructionRepository;
            _logger = logger;
        }

        public Task<IReadOnlyList<FeeInstruction>> GetAllAsync(
            string brokerId, long id, long fromWalletId, long toWalletId, int orderId, string assetId,
            ListSortDirection sortOrder = ListSortDirection.Ascending, long cursor = default, int limit = 50)
        {
            return _feeInstructionRepository.GetAllAsync(brokerId, id, fromWalletId, toWalletId, orderId, assetId,
                sortOrder, cursor, limit);
        }

        public Task<FeeInstruction> GetByIdAsync(string brokerId, long id)
        {
            return _feeInstructionRepository.GetByIdAsync(brokerId, id);
        }
    }
}
