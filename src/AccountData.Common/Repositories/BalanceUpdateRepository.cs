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
    public class BalanceUpdateRepository : IBalanceUpdateRepository
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly IMapper _mapper;

        public BalanceUpdateRepository(ConnectionFactory connectionFactory, IMapper mapper)
        {
            _connectionFactory = connectionFactory;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<BalanceUpdate>> GetAllAsync(
            string brokerId, long id, string wallet, string asset, BalanceUpdateEventType? eventType,
            ListSortDirection sortOrder = ListSortDirection.Ascending, long cursor = default, int limit = 50)
        {
            using (var context = _connectionFactory.CreateDataContext())
            {
                IQueryable<BalanceUpdateEntity> query = context.BalanceUpdates;

                query = query.Where(x => x.BrokerId.ToUpper() == brokerId.ToUpper());

                if (id != default)
                    query = query.Where(x => x.Id == id);

                if (!string.IsNullOrWhiteSpace(wallet))
                    query = query.Where(x => x.Wallet.ToUpper() == wallet.ToUpper());

                if (!string.IsNullOrEmpty(asset))
                    query = query.Where(x => x.Asset == asset);

                if (eventType.HasValue && eventType.Value != BalanceUpdateEventType.Unknown)
                    query = query.Where(x => x.EventType == eventType);

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

                return _mapper.Map<BalanceUpdate[]>(entities);
            }
        }

        public async Task<BalanceUpdate> GetByIdAsync(string brokerId, long id)
        {
            using (var context = _connectionFactory.CreateDataContext())
            {
                IQueryable<BalanceUpdateEntity> query = context.BalanceUpdates;

                query = query.Where(x => x.BrokerId.ToUpper() == brokerId.ToUpper());

                query = query.Where(x => x.Id == id);

                var entity = await query.SingleOrDefaultAsync();

                return _mapper.Map<BalanceUpdate>(entity);
            }
        }
    }
}
