using System;

namespace AccountData.Common.Domain.Entities
{
    public class Balance
    {
        public string Asset { get; set; }

        public decimal Amount { get; set; }

        public decimal Reserved { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
