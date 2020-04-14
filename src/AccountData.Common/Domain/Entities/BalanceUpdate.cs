using System;

namespace AccountData.Common.Domain.Entities
{
    public class BalanceUpdate
    {
        public long Id { get; set; }

        public string BrokerId { get; set; }

        public string WalletId { get; set; }

        public string AssetId { get; set; }

        public string Balance { get; set; }

        public string OldBalance { get; set; }

        public string Reserved { get; set; }

        public string OldReserved { get; set; }

        public DateTimeOffset Timestamp { get; set; }
    }
}
