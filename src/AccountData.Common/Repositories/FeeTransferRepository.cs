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
    public class FeeTransferRepository : IFeeTransferRepository
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly IMapper _mapper;

        public FeeTransferRepository(ConnectionFactory connectionFactory, IMapper mapper)
        {
            _connectionFactory = connectionFactory;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<FeeTransfer>> GetAllAsync(
            string brokerId, long id, string sourceWalletId, string targetWalletId, int orderId, string assetId,
            ListSortDirection sortOrder = ListSortDirection.Ascending, long cursor = default, int limit = 50)
        {
            using (var context = _connectionFactory.CreateDataContext())
            {
                IQueryable<FeeTransferEntity> query = context.FeeTransfers;

                query = query.Where(x => x.BrokerId.ToUpper() == brokerId.ToUpper());

                if (id != default)
                    query = query.Where(x => x.Id == id);

                if (!string.IsNullOrWhiteSpace(sourceWalletId))
                    query = query.Where(x => x.SourceWalletId.ToUpper() == sourceWalletId.ToUpper());

                if (!string.IsNullOrWhiteSpace(targetWalletId))
                    query = query.Where(x => x.TargetWalletId.ToUpper() == targetWalletId.ToUpper());

                if (orderId != default)
                    query = query.Where(x => x.OrderId == orderId);

                if (!string.IsNullOrWhiteSpace(assetId))
                    query = query.Where(x => x.AssetsId.ToUpper() == assetId.ToUpper());

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

                return _mapper.Map<FeeTransfer[]>(entities);
            }
        }

        public async Task<FeeTransfer> GetByIdAsync(string brokerId, long id)
        {
            using (var context = _connectionFactory.CreateDataContext())
            {
                IQueryable<FeeTransferEntity> query = context.FeeTransfers;

                query = query.Where(x => x.BrokerId.ToUpper() == brokerId.ToUpper());

                query = query.Where(x => x.Id == id);

                var entity = await query.SingleOrDefaultAsync();

                return _mapper.Map<FeeTransfer>(entity);
            }
        }
    }
}
