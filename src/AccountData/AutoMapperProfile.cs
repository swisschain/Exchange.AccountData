using AccountData.Common.Domain.Entities;
using AccountData.WebApi.Models.AccountData;
using AutoMapper;

namespace AccountData
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Balance, BalanceModel>(MemberList.Source);
        }
    }
}
