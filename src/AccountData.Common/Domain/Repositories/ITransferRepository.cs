using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;

namespace AccountData.Common.Domain.Repositories
{
    public interface ICashTransferRepository
    {
        Task<CashTransfer> GetByBalanceUpdateIdAsync(string brokerId, long messageId);
    }
}
