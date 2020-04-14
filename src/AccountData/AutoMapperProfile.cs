using AccountData.Common.Domain.Entities;
using AccountData.WebApi.Models.Balance;
using AccountData.WebApi.Models.BalanceUpdate;
using AccountData.WebApi.Models.FeeInstruction;
using AccountData.WebApi.Models.FeeTransfer;
using AccountData.WebApi.Models.Order;
using AccountData.WebApi.Models.Trade;
using AutoMapper;

namespace AccountData
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Balance, BalanceModel>(MemberList.Destination);
            CreateMap<Balances, BalancesModel>(MemberList.Destination);
            CreateMap<BalanceUpdate, BalanceUpdateModel>(MemberList.Destination);
            CreateMap<FeeInstruction, FeeInstructionModel>(MemberList.Destination);
            CreateMap<FeeTransfer, FeeTransferModel>(MemberList.Destination);
            CreateMap<Order, OrderModel>(MemberList.Destination);
            CreateMap<Trade, TradeModel>(MemberList.Destination);
        }
    }
}
