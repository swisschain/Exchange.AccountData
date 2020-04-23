﻿using System.Linq;
using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;
using AccountData.Common.Domain.Repositories;
using AccountData.Common.Repositories.Context;
using AccountData.Common.Repositories.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AccountData.Common.Repositories
{
    public class CashOutRepository : ICashOutRepository
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly IMapper _mapper;

        public CashOutRepository(ConnectionFactory connectionFactory, IMapper mapper)
        {
            _connectionFactory = connectionFactory;
            _mapper = mapper;
        }

        public async Task<CashOut> GetByBalanceUpdateIdAsync(string brokerId, long balanceUpdateId)
        {
            using (var context = _connectionFactory.CreateDataContext())
            {
                IQueryable<CashOutEntity> query = context.CashOuts;

                query = query.Where(x => x.BrokerId.ToUpper() == brokerId.ToUpper());

                query = query.Where(x => x.BalanceUpdateId == balanceUpdateId);

                var entity = await query.SingleOrDefaultAsync();

                return _mapper.Map<CashOut>(entity);
            }
        }
    }
}
