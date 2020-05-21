namespace AccountData.Common.Domain.Entities
{
    public class CashTransfer
    {
        public long Id { get; set; }

        public long MessageId { get; set; }

        public long BalanceUpdateId { get; set; }

        public string BrokerId { get; set; }

        public string AssetId { get; set; }

        public long AccountId { get; set; }

        public long FromWalletId { get; set; }

        public long ToWalletId { get; set; }

        public string Volume { get; set; }

        public string Description { get; set; }
    }
}
