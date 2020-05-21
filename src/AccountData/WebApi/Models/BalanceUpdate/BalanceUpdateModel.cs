using System;
using AccountData.Common.Domain.Entities.Enums;

namespace AccountData.WebApi.Models.BalanceUpdate
{
    public class BalanceUpdateModel
    {
        public long Id { get; set; }

        public long AccountId { get; set; }

        public long WalletId { get; set; }

        public string Asset { get; set; }

        public string Balance { get; set; }

        public string OldBalance { get; set; }

        public string Reserved { get; set; }

        public string OldReserved { get; set; }

        public BalanceUpdateEventType EventType { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
