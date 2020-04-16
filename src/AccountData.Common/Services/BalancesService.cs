using System.Threading.Tasks;
using AccountData.Common.Domain.Entities;
using AccountData.Common.Domain.Services;
using AutoMapper;
using MatchingEngine.Client;
using MatchingEngine.Client.Contracts.Balances;

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

        public async Task<Balances> GetAllAsync(string brokerId, string walletId)
        {
            var request = new BalancesGetAllRequest { BrokerId = brokerId, WalletId = walletId };

            BalancesGetAllResponse balances =
                await _matchingEngineClient.Balances.GetAllAsync(request);

            return _mapper.Map<Balances>(balances);
        }

        public async Task<Balances> GetByAssetIdAsync(string brokerId, string walletId, string assetId)
        {
            var request = new BalancesGetByAssetIdRequest { BrokerId = brokerId, WalletId = walletId, AssetId = assetId };

            BalancesGetByAssetIdResponse balanceResponse = await _matchingEngineClient.Balances.GetByAssetIdAsync(request);

            return _mapper.Map<Balances>(balanceResponse);
        }
    }
}
