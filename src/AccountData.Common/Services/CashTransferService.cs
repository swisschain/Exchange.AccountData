using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;
using AccountData.Common.Domain.Repositories;
using AccountData.Common.Domain.Services;
using Microsoft.Extensions.Logging;

namespace AccountData.Common.Services
{
    public class CashTransferService : ICashTransferService
    {
        private readonly ICashTransferRepository _cashTransferRepository;
        private readonly ILogger<CashTransferService> _logger;

        public CashTransferService(ICashTransferRepository cashTransferRepository,
            ILogger<CashTransferService> logger)
        {
            _cashTransferRepository = cashTransferRepository;
            _logger = logger;
        }

        public Task<CashTransfer> GetByIdAsync(string brokerId, long id)
        {
            return _cashTransferRepository.GetByBalanceUpdateIdAsync(brokerId, id);
        }
    }
}
