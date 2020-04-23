using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;
using AccountData.Common.Domain.Repositories;
using AccountData.Common.Domain.Services;
using Microsoft.Extensions.Logging;

namespace AccountData.Common.Services
{
    public class CashInService : ICashInService
    {
        private readonly ICashInRepository _cashInRepository;
        private readonly ILogger<CashInService> _logger;

        public CashInService(ICashInRepository cashInRepository,
            ILogger<CashInService> logger)
        {
            _cashInRepository = cashInRepository;
            _logger = logger;
        }

        public Task<CashIn> GetByIdAsync(string brokerId, long id)
        {
            return _cashInRepository.GetByBalanceUpdateIdAsync(brokerId, id);
        }
    }
}
