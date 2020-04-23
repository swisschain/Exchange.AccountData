namespace AccountData.Common.Domain.Entities
{
    public class CashTransfer
    {
        public long Id { get; set; }

        public long BalanceUpdateId { get; set; }

        public string BrokerId { get; set; }

        public string AssetId { get; set; }

        public string ToWallet { get; set; }

        public string Volume { get; set; }

        public string Description { get; set; }
    }
}
