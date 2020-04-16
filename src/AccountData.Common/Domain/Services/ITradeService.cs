﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;

namespace AccountData.Common.Domain.Services
{
    public interface ITradeService
    {
        Task<IReadOnlyList<Trade>> GetAllAsync(
            string brokerId, string externalId, string walletId, string baseAssetId, string quotingAssetId,
            ListSortDirection sortOrder = ListSortDirection.Ascending, string cursor = null, int limit = 50);

        Task<Trade> GetByIdAsync(string brokerId, long id);
    }
}
