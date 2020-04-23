using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;

namespace AccountData.Common.Domain.Services
{
    public interface ICashInService
    {
        Task<CashIn> GetByIdAsync(string brokerId, long id);
    }
}
