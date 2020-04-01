using System.Collections.Generic;
using System.Globalization;
using AccountData.Common.Domain.Entities;
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
            CreateMap<BalancesGetAllResponse, Balances>(MemberList.Destination)
                .ForMember(dest => dest.Timestamp,
                    opt => opt.MapFrom(src => src.Timestamp.ToDateTime()))
                .ForMember(dest => dest.List,
                    opt => opt.MapFrom(src => src.Balances));

            CreateMap<MEBalance, Balance>(MemberList.Destination)
                .ForMember(dest => dest.Amount,
                    opt => opt.MapFrom(src => decimal.Parse(src.Amount, CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.Reserved,
                    opt => opt.MapFrom(src => decimal.Parse(src.Reserved, CultureInfo.InvariantCulture)));

            CreateMap<MEBalance, IEnumerable<Balance>>(MemberList.Destination)
                .ConvertUsing<BalanceToListConverter>();

            CreateMap<BalancesGetByAssetIdResponse, Balances>(MemberList.Destination)
                .ForMember(dest => dest.Timestamp,
                    opt => opt.MapFrom(src => src.Timestamp.ToDateTime()))
                .ForMember(dest => dest.List,
                    opt => opt.MapFrom(src => src.Balance));
        }
    }
    
    class BalanceToListConverter : ITypeConverter<MEBalance, IEnumerable<Balance>>
    {
        public IEnumerable<Balance> Convert(MEBalance source, IEnumerable<Balance> destination, ResolutionContext context)
        {
            var balance = context.Mapper.Map<Balance>(source);

            return new List<Balance> { balance };
        }
    }
}
