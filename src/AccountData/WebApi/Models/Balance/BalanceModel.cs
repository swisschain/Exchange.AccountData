using System;

namespace AccountData.WebApi.Models.Balance
{
    /// <summary>
    /// Represents a balance of an asset.
    /// </summary>
    public class BalanceModel
    {
        /// <summary>
        /// The asset symbol.
        /// </summary>
        public string Asset { get; set; }

        /// <summary>
        /// The amount of balance.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// The amount that currently are reserved.
        /// </summary>
        public decimal Reserved { get; set; }

        /// <summary>
        /// Timestamp.
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}
