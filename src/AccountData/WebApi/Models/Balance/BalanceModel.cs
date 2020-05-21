using System;

namespace AccountData.WebApi.Models.Balance
{
    public class BalanceModel
    {
        public string Asset { get; set; }

        public decimal Amount { get; set; }

        public decimal Reserved { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
