using System;
using System.Collections.Generic;

namespace AccountData.Common.Domain.Entities
{
    public class Balances
    {
        public long AccountId { get; set; }

        public long WalletId { get; set; }

        public DateTime Timestamp { get; set; }

        public List<Balance> List { get; set; } = new List<Balance>();
    }
}
