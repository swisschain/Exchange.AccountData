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
    public class CashInRepository : ICashInRepository
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly IMapper _mapper;

        public CashInRepository(ConnectionFactory connectionFactory, IMapper mapper)
        {
            _connectionFactory = connectionFactory;
            _mapper = mapper;
        }

        public async Task<CashIn> GetByBalanceUpdateIdAsync(string brokerId, long balanceUpdateId)
        {
            using (var context = _connectionFactory.CreateDataContext())
            {
                IQueryable<CashInEntity> query = context.CashIns;

                query = query.Where(x => x.BrokerId == brokerId);

                query = query.Where(x => x.BalanceUpdateId == balanceUpdateId);

                var entity = await query.SingleOrDefaultAsync();

                return _mapper.Map<CashIn>(entity);
            }
        }
    }
}
