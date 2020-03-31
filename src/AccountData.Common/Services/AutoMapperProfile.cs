using AccountData.Common.Domain.Entities;
using AutoMapper;
using MatchingEngine.Client.Models.Balances;

namespace AccountData.Common.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BalanceModel, Balance>(MemberList.Source);
        }
    }
}
