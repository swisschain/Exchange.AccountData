using System;
using System.Collections.Generic;

namespace AccountData.WebApi.Models.Balance
{
    public class BalancesModel
    {
        public long AccountId { get; set; }

        public long WalletId { get; set; }

        public DateTime Timestamp { get; set; }

        public IReadOnlyList<BalanceModel> List { get; set; }
    }
}
