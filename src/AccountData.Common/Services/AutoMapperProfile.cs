using System.Collections.Generic;
using System.Globalization;
using AccountData.Common.Domain.Entities;
using AccountData.Common.Repositories.Entities;
using AutoMapper;
using MatchingEngine.Client.Contracts.Balances;
using MEBalance = MatchingEngine.Client.Contracts.Balances.Balance;
using Balance = AccountData.Common.Domain.Entities.Balance;

namespace AccountData.Common.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            Repositories();

            DomainAndMatchingEngineClient();
        }

        private void Repositories()
        {
            CreateMap<BalanceUpdate, BalanceUpdateEntity>(MemberList.Destination);
            CreateMap<BalanceUpdateEntity, BalanceUpdate>(MemberList.Destination);

            CreateMap<FeeInstruction, FeeInstructionEntity>(MemberList.Destination);
            CreateMap<FeeInstructionEntity, FeeInstruction>(MemberList.Destination);

            CreateMap<FeeTransfer, FeeTransferEntity>(MemberList.Destination);
            CreateMap<FeeTransferEntity, FeeTransfer>(MemberList.Destination);

            CreateMap<Order, OrderEntity>(MemberList.Destination);
            CreateMap<OrderEntity, Order>(MemberList.Destination);

            CreateMap<Trade, TradeEntity>(MemberList.Destination);
            CreateMap<TradeEntity, Trade>(MemberList.Destination);
        }

        private void DomainAndMatchingEngineClient()
        {
            CreateMap<BalancesGetAllResponse, Balances>(MemberList.Destination)
                .ForMember(dest => dest.Timestamp,
                    opt => opt.MapFrom(src => src.Timestamp.ToDateTime()))
                .ForMember(dest => dest.List,
                    opt => opt.MapFrom(src => src.Balances));

            CreateMap<MEBalance, Balance>(MemberList.Destination)
                .ForMember(x => x.Timestamp, opt => opt.Ignore())
                .ForMember(dest => dest.Amount,
                    opt => opt.MapFrom(src => decimal.Parse(src.Amount, CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.Reserved,
                    opt => opt.MapFrom(src => decimal.Parse(src.Reserved, CultureInfo.InvariantCulture)));

            CreateMap<BalancesGetByAssetIdResponse, Balances>(MemberList.Destination)
                .ForMember(dest => dest.Timestamp,
                    opt => opt.MapFrom(src => src.Timestamp.ToDateTime()))
                .ForMember(dest => dest.List,
                    opt => opt.MapFrom((src, dest, destMember, context) =>
                        new List<Balance> { context.Mapper.Map<Balance>(src.Balance) }));
        }
    }
}
