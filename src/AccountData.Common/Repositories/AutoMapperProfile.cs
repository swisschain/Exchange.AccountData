using AccountData.Common.Domain.Entities;
using AccountData.Common.Repositories.Entities;
using AutoMapper;

namespace AccountData.Common.Repositories
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
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

            CreateMap<CashIn, CashInEntity>(MemberList.Destination);
            CreateMap<CashInEntity, CashIn>(MemberList.Destination);

            CreateMap<CashOut, CashOutEntity>(MemberList.Destination);
            CreateMap<CashOutEntity, CashOut>(MemberList.Destination);

            CreateMap<CashTransfer, CashTransferEntity>(MemberList.Destination);
            CreateMap<CashTransferEntity, CashTransfer>(MemberList.Destination);
        }
    }
}
