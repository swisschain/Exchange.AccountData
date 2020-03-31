using System.Collections.Generic;
using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;
using AccountData.Common.Domain.Services;
using AutoMapper;
using MatchingEngine.Client;

namespace AccountData.Common.Services
{
    public class BalancesService : IBalancesService
    {
        private readonly IMatchingEngineClient _matchingEngineClient;
        private readonly IMapper _mapper;

        public BalancesService(IMatchingEngineClient matchingEngineClient, IMapper mapper)
        {
            _matchingEngineClient = matchingEngineClient;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<Balance>> GetAllAsync(string walletId)
        {
            var balances = await _matchingEngineClient.Balances.GetAllAsync(walletId);

            return _mapper.Map<List<Balance>>(balances);
        }

        public async Task<Balance> GetByAssetIdAsync(string walletId, string assetId)
        {
            var balance = await _matchingEngineClient.Balances.GetByAssetIdAsync(walletId, assetId);

            return _mapper.Map<Balance>(balance);
        }
    }
}
