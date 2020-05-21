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
    public class FeeInstructionRepository : IFeeInstructionRepository
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly IMapper _mapper;

        public FeeInstructionRepository(ConnectionFactory connectionFactory, IMapper mapper)
        {
            _connectionFactory = connectionFactory;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<FeeInstruction>> GetAllAsync(
            string brokerId, long id, long fromWalletId, long toWalletId, int orderId, string assetId,
            ListSortDirection sortOrder = ListSortDirection.Ascending, long cursor = default, int limit = 50)
        {
            using (var context = _connectionFactory.CreateDataContext())
            {
                IQueryable<FeeInstructionEntity> query = context.FeeInstructions;

                query = query.Where(x => x.BrokerId.ToUpper() == brokerId.ToUpper());

                if (id != default)
                    query = query.Where(x => x.Id == id);

                if (fromWalletId != 0)
                    query = query.Where(x => x.FromWalletId == fromWalletId);

                if (toWalletId != 0)
                    query = query.Where(x => x.ToWalletId == toWalletId);

                if (orderId != default)
                    query = query.Where(x => x.OrderId == orderId);

                if (!string.IsNullOrWhiteSpace(assetId))
                    query = query.Where(x => x.AssetsIds.ToUpper() == assetId.ToUpper());

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

                return _mapper.Map<FeeInstruction[]>(entities);
            }
        }

        public async Task<FeeInstruction> GetByIdAsync(string brokerId, long id)
        {
            using (var context = _connectionFactory.CreateDataContext())
            {
                IQueryable<FeeInstructionEntity> query = context.FeeInstructions;

                query = query.Where(x => x.BrokerId.ToUpper() == brokerId.ToUpper());

                query = query.Where(x => x.Id == id);

                var entity = await query.SingleOrDefaultAsync();

                return _mapper.Map<FeeInstruction>(entity);
            }
        }
    }
}
