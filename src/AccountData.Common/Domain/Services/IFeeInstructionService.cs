using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;

namespace AccountData.Common.Domain.Services
{
    public interface IFeeInstructionService
    {
        Task<IReadOnlyList<FeeInstruction>> GetAllAsync(
            string brokerId, long id, string sourceWalletId, string targetWalletId, int orderId, string assetId,
            ListSortDirection sortOrder = ListSortDirection.Ascending, long cursor = default, int limit = 50);

        Task<FeeInstruction> GetByIdAsync(string brokerId, long id);
    }
}
