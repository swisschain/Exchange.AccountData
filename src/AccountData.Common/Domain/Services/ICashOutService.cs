using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;

namespace AccountData.Common.Domain.Services
{
    public interface ICashOutService
    {
        Task<CashOut> GetByIdAsync(string brokerId, long id);
    }
}
