using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;

namespace AccountData.Common.Domain.Services
{
    public interface ICashTransferService
    {
        Task<CashTransfer> GetByIdAsync(string brokerId, long id);
    }
}
