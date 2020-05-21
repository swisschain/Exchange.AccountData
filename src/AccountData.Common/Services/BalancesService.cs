using System.ComponentModel;
using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;
using AccountData.Common.Domain.Repositories;
using AccountData.Common.Domain.Services;
using AutoMapper;

namespace AccountData.Common.Services
{
    public class BalancesService : IBalancesService
    {
        private readonly IBalanceRepository _balanceRepository;
        private readonly IMapper _mapper;

        public BalancesService(IBalanceRepository balanceRepository, IMapper mapper)
        {
            _balanceRepository = balanceRepository;
            _mapper = mapper;
        }

        public Task<Balances> GetAllAsync(string brokerId, long accountId, long walletId, string asset,
            ListSortDirection sortOrder = ListSortDirection.Ascending, long cursor = default, int limit = 50)
        {
            return _balanceRepository.GetAllAsync(brokerId, accountId, walletId, asset, sortOrder, cursor, limit);
        }

        public Task<Balances> GetByAssetIdAsync(string brokerId, long accountId, long walletId, string asset)
        {
            return _balanceRepository.GetByIdAsync(brokerId, accountId, walletId, asset);
        }
    }
}
