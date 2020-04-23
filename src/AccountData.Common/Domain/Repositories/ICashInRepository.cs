using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;

namespace AccountData.Common.Domain.Repositories
{
    public interface ICashInRepository
    {
        Task<CashIn> GetByBalanceUpdateIdAsync(string brokerId, long balanceUpdateId);
    }
}
