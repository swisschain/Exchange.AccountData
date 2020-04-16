using System.Collections.Generic;
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
    public class TradeRepository : ITradeRepository
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly IMapper _mapper;

        public TradeRepository(ConnectionFactory connectionFactory, IMapper mapper)
        {
            _connectionFactory = connectionFactory;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<Trade>> GetAllAsync(
            string brokerId, string externalId, string walletId, string baseAssetId, string quotingAssetId,
            ListSortDirection sortOrder = ListSortDirection.Ascending, string cursor = null, int limit = 50)
        {
            using (var context = _connectionFactory.CreateDataContext())
            {
                IQueryable<TradeEntity> query = context.Trades;

                query = query.Where(x => x.BrokerId.ToUpper() == brokerId.ToUpper());

                if (!string.IsNullOrWhiteSpace(externalId))
                    query = query.Where(x => x.ExternalId.ToUpper() == externalId.ToUpper());

                if (!string.IsNullOrWhiteSpace(walletId))
                    query = query.Where(x => x.WalletId.ToUpper() == walletId.ToUpper());

                if (!string.IsNullOrEmpty(baseAssetId))
                    query = query.Where(x => x.BaseAssetId.ToUpper() == baseAssetId.ToUpper());

                if (!string.IsNullOrEmpty(quotingAssetId))
                    query = query.Where(x => x.QuotingAssetId.ToUpper() == quotingAssetId.ToUpper());

                if (sortOrder == ListSortDirection.Ascending)
                {
                    if (cursor != null)
                        query = query.Where(x => x.ExternalId.CompareTo(cursor) >= 0);

                    query = query.OrderBy(x => x.Id);
                }
                else
                {
                    if (cursor != null)
                        query = query.Where(x => x.ExternalId.CompareTo(cursor) < 0);

                    query = query.OrderByDescending(x => x.Id);
                }

                query = query.Take(limit);

                var entities = await query.ToListAsync();

                return _mapper.Map<Trade[]>(entities);
            }
        }

        public async Task<Trade> GetByIdAsync(string brokerId, long id)
        {
            using (var context = _connectionFactory.CreateDataContext())
            {
                IQueryable<TradeEntity> query = context.Trades;

                query = query.Where(x => x.BrokerId.ToUpper() == brokerId.ToUpper());

                query = query.Where(x => x.Id == id);

                var entity = await query.SingleOrDefaultAsync();

                return _mapper.Map<Trade>(entity);
            }
        }
    }
}
