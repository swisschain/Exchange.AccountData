using System;
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
    public class BalanceRepository : IBalanceRepository
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly IMapper _mapper;

        public BalanceRepository(ConnectionFactory connectionFactory, IMapper mapper)
        {
            _connectionFactory = connectionFactory;
            _mapper = mapper;
        }

        public async Task<Balances> GetAllAsync(string brokerId, long accountId, long walletId, string asset,
            ListSortDirection sortOrder = ListSortDirection.Ascending, long cursor = default, int limit = 50)
        {
            using (var context = _connectionFactory.CreateDataContext())
            {
                IQueryable<BalanceEntity> query = context.Balances;

                query = query.Where(x => x.BrokerId == brokerId);

                query = query.Where(x => x.AccountId == accountId);

                if (walletId != 0)
                    query = query.Where(x => x.WalletId == walletId);

                if (!string.IsNullOrEmpty(asset))
                    query = query.Where(x => x.Asset == asset);

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

                var balances = await query.ToListAsync();

                balances = MergeBalances(balances);

                var result = new Balances();

                result.Timestamp = DateTime.UtcNow;
                result.AccountId = accountId;
                result.WalletId = walletId;

                balances.ForEach(x => result.List.Add(new Balance
                {
                    Amount = decimal.Parse(x.Balance),
                    Asset = x.Asset,
                    Reserved = decimal.Parse(x.Reserved),
                    Timestamp = x.Timestamp
                }));

                return result;
            }
        }

        public async Task<Balances> GetByIdAsync(string brokerId, long accountId, long walletId, string asset)
        {
            using (var context = _connectionFactory.CreateDataContext())
            {
                IQueryable<BalanceEntity> query = context.Balances;

                query = query.Where(x => x.AccountId == accountId);

                if (walletId != 0)
                    query = query.Where(x => x.WalletId == walletId);

                query = query.Where(x => x.BrokerId == brokerId);

                query = query.Where(x => x.Asset.ToUpper() == asset.ToUpper());

                var balances = await query.ToListAsync();

                balances = MergeBalances(balances);

                var result = new Balances();

                result.Timestamp = DateTime.UtcNow;
                result.AccountId = accountId;
                result.WalletId = walletId;

                balances.ForEach(x => result.List.Add(new Balance
                {
                    Amount = decimal.Parse(x.Balance),
                    Asset = x.Asset,
                    Reserved = decimal.Parse(x.Reserved),
                    Timestamp = x.Timestamp
                }));

                return result;
            }
        }

        private List<BalanceEntity> MergeBalances(IEnumerable<BalanceEntity> balances)
        {
            var mergedBalances = new List<BalanceEntity>();

            foreach (var b in balances)
            {
                var existed = mergedBalances.SingleOrDefault(x => x.Asset == b.Asset);

                if (existed == null)
                    mergedBalances.Add(b);
                else
                {
                    existed.Balance += b.Balance;
                    existed.Reserved += b.Reserved;
                    existed.Timestamp = existed.Timestamp > b.Timestamp ? existed.Timestamp : b.Timestamp;
                }
            }

            return mergedBalances;
        }
    }
}
