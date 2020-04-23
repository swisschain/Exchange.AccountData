using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;
using AccountData.Common.Domain.Repositories;
using AccountData.Common.Domain.Services;
using Microsoft.Extensions.Logging;

namespace AccountData.Common.Services
{
    public class CashOutService : ICashOutService
    {
        private readonly ICashOutRepository _cashOutRepository;
        private readonly ILogger<CashOutService> _logger;

        public CashOutService(ICashOutRepository cashOutRepository,
            ILogger<CashOutService> logger)
        {
            _cashOutRepository = cashOutRepository;
            _logger = logger;
        }

        public Task<CashOut> GetByIdAsync(string brokerId, long id)
        {
            return _cashOutRepository.GetByBalanceUpdateIdAsync(brokerId, id);
        }
    }
}
