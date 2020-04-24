namespace AccountData.Common.Domain.Entities
{
    public class CashIn
    {
        public long Id { get; set; }

        public long MessageId { get; set; }

        public long BalanceUpdateId { get; set; }

        public string BrokerId { get; set; }

        public string AssetId { get; set; }

        public string Volume { get; set; }

        public string Description { get; set; }
    }
}
