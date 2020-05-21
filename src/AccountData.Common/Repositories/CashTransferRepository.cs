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
    public class CashTransferRepository : ICashTransferRepository
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly IMapper _mapper;

        public CashTransferRepository(ConnectionFactory connectionFactory, IMapper mapper)
        {
            _connectionFactory = connectionFactory;
            _mapper = mapper;
        }

        public async Task<CashTransfer> GetByBalanceUpdateIdAsync(string brokerId, long messageId)
        {
            using (var context = _connectionFactory.CreateDataContext())
            {
                IQueryable<CashTransferEntity> query = context.CashTransfers;

                query = query.Where(x => x.BrokerId == brokerId);

                query = query.Where(x => x.MessageId == messageId);

                var entity = await query.SingleOrDefaultAsync();

                return _mapper.Map<CashTransfer>(entity);
            }
        }
    }
}
