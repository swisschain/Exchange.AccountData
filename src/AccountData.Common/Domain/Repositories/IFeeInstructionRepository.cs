﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;

namespace AccountData.Common.Domain.Repositories
{
    public interface IFeeInstructionRepository
    {
        Task<IReadOnlyList<FeeInstruction>> GetAllAsync(
            string brokerId, long id, long fromWalletId, long toWalletId, int orderId, string assetId,
            ListSortDirection sortOrder = ListSortDirection.Ascending, long cursor = default, int limit = 50);

        Task<FeeInstruction> GetByIdAsync(string brokerId, long id);
    }
}
