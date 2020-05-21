using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;

namespace AccountData.Common.Domain.Services
{
    public interface IFeeTransferService
    {
        Task<IReadOnlyList<FeeTransfer>> GetAllAsync(
            string brokerId, long id, long fromWalletId, long toWalletId, int orderId, string assetId,
            ListSortDirection sortOrder = ListSortDirection.Ascending, long cursor = default, int limit = 50);

        Task<FeeTransfer> GetByIdAsync(string brokerId, long id);
    }
}
