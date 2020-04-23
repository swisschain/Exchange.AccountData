using AccountData.Common.Domain.Entities.Enums;

namespace AccountData.Common.Domain.Entities
{
    public class BalanceUpdateDetails
    {
        public string Asset { get; set; }

        public decimal Volume { get; set; }

        public BalanceUpdateType Type { get; set; }

        public string ToWallet { get; set; }

        public string Description { get; set; }
    }
}
