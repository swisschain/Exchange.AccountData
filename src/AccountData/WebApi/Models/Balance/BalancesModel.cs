using System;
using System.Collections.Generic;

namespace AccountData.WebApi.Models.Balance
{
    /// <summary>
    /// Represents balances of many assets.
    /// </summary>
    public class BalancesModel
    {
        /// <summary>
        /// Wallet identifier.
        /// </summary>
        public string WalletId { get; set; }

        /// <summary>
        /// Timestamp.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// List of balances.
        /// </summary>
        public IReadOnlyList<BalanceModel> List { get; set; }
    }
}
