﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;
using AccountData.Common.Domain.Repositories;
using AccountData.Common.Repositories.Context;
using AccountData.Common.Repositories.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AccountData.Common.Repositories
{
    public class OrderHistoryRepository : IOrderHistoryRepository
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly IMapper _mapper;

        public OrderHistoryRepository(ConnectionFactory connectionFactory, IMapper mapper)
        {
            _connectionFactory = connectionFactory;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<OrderHistory>> GetAllAsync(
            string brokerId, long id, long accountId, long walletId, string assetPairId,
            ListSortDirection sortOrder = ListSortDirection.Ascending, long cursor = default, int limit = 50)
        {
            using (var context = _connectionFactory.CreateDataContext())
            {
                IQueryable<OrderHistoryEntity> query = context.OrdersHistory;

                query = query.Where(x => x.BrokerId.ToUpper() == brokerId.ToUpper());

                if (id != default)
                    query = query.Where(x => x.Id == id);

                query = query.Where(x => x.AccountId == accountId);

                if (walletId != 0)
                    query = query.Where(x => x.WalletId == walletId);

                if (!string.IsNullOrEmpty(assetPairId))
                    query = query.Where(x => x.AssetPairId == assetPairId);

                if (sortOrder == ListSortDirection.Ascending)
                {
                    if (cursor != default)
                        query = query.Where(x => x.Id >= cursor);

                    query = query.OrderBy(x => x.Id);
                }
                else
                {
                    if (cursor != default)
                        query = query.Where(x => x.Id < cursor);

                    query = query.OrderByDescending(x => x.Id);
                }

                query = query.Take(limit);

                var entities = await query.ToListAsync();

                return _mapper.Map<OrderHistory[]>(entities);
            }
        }

        public async Task<OrderHistory> GetByIdAsync(string brokerId, long id)
        {
            using (var context = _connectionFactory.CreateDataContext())
            {
                IQueryable<OrderHistoryEntity> query = context.OrdersHistory;

                query = query.Where(x => x.BrokerId.ToUpper() == brokerId.ToUpper());

                query = query.Where(x => x.Id == id);

                var entity = await query.SingleOrDefaultAsync();

                return _mapper.Map<OrderHistory>(entity);
            }
        }
    }
}
