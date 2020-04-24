using AccountData.Common.Domain.Entities.Enums;

namespace AccountData.WebApi.Models.BalanceUpdate
{
    public class BalanceUpdateDetailsModel
    {
        public string Asset { get; set; }

        public decimal Volume { get; set; }

        public BalanceUpdateType Type { get; set; }

        public string FromWallet { get; set; }

        public string ToWallet { get; set; }

        public string Description { get; set; }
    }
}
