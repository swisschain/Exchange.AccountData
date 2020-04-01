using System;
using System.Collections.Generic;

namespace AccountData.Common.Domain.Entities
{
    /// <summary>
    /// Represents balances of many assets.
    /// </summary>
    public class Balances
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
