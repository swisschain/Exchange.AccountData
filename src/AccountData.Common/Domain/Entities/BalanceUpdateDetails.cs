using AccountData.Common.Domain.Entities.Enums;

namespace AccountData.Common.Domain.Entities
{
    public class BalanceUpdateDetails
    {
        public string Asset { get; set; }

        public decimal Volume { get; set; }

        public BalanceUpdateType Type { get; set; }

        public long FromWalletId { get; set; }

        public long ToWalletId { get; set; }

        public string Description { get; set; }
    }
}
