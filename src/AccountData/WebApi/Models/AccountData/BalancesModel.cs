using System;
using System.Collections.Generic;
using AccountData.Common.Domain.Entities;

namespace AccountData.WebApi.Models.AccountData
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
        public IReadOnlyList<Balance> List { get; set; }
    }
}
