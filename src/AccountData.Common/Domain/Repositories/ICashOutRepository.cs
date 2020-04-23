using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;

namespace AccountData.Common.Domain.Repositories
{
    public interface ICashOutRepository
    {
        Task<CashOut> GetByBalanceUpdateIdAsync(string brokerId, long balanceUpdateId);
    }
}
