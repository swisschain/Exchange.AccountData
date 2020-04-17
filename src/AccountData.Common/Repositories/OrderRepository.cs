using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;
using AccountData.Common.Domain.Entities.Enums;
using AccountData.Common.Domain.Repositories;
using AccountData.Common.Repositories.Context;
using AccountData.Common.Repositories.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AccountData.Common.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly IMapper _mapper;

        public OrderRepository(ConnectionFactory connectionFactory, IMapper mapper)
        {
            _connectionFactory = connectionFactory;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<Order>> GetAllAsync(
            string brokerId, long id, string externalId, string walletId, string assetPairId,
            OrderType? orderType, OrderSide? side, OrderStatus? status, OrderTimeInForce? timeInForce,
            ListSortDirection sortOrder = ListSortDirection.Ascending, long cursor = default, int limit = 50)
        {
            using (var context = _connectionFactory.CreateDataContext())
            {
                IQueryable<OrderEntity> query = context.Orders;

                query = query.Where(x => x.BrokerId.ToUpper() == brokerId.ToUpper());

                if (id != default)
                    query = query.Where(x => x.Id == id);

                if (!string.IsNullOrWhiteSpace(externalId))
                    query = query.Where(x => x.ExternalId.ToUpper() == externalId.ToUpper());

                if (!string.IsNullOrWhiteSpace(walletId))
                    query = query.Where(x => x.WalletId.ToUpper() == walletId.ToUpper());

                if (!string.IsNullOrEmpty(assetPairId))
                    query = query.Where(x => x.AssetPairId == assetPairId);

                if (orderType.HasValue)
                    query = query.Where(x => x.OrderType == orderType);

                if (side.HasValue)
                    query = query.Where(x => x.Side == side);

                if (status.HasValue)
                    query = query.Where(x => x.Status == status);

                if (timeInForce.HasValue)
                    query = query.Where(x => x.TimeInForce == timeInForce);

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

                return _mapper.Map<Order[]>(entities);
            }
        }

        public async Task<Order> GetByIdAsync(string brokerId, long id)
        {
            using (var context = _connectionFactory.CreateDataContext())
            {
                IQueryable<OrderEntity> query = context.Orders;

                query = query.Where(x => x.BrokerId.ToUpper() == brokerId.ToUpper());

                query = query.Where(x => x.Id == id);

                var entity = await query.SingleOrDefaultAsync();

                return _mapper.Map<Order>(entity);
            }
        }
    }
}
