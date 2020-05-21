namespace AccountData.Common.Domain.Entities
{
    public class FeeTransfer
    {
        public long Id { get; set; }

        public string BrokerId { get; set; }

        public long OrderId { get; set; }

        public string FromWalletId { get; set; }

        public string ToWalletId { get; set; }

        public string AssetId { get; set; }

        public string Volume { get; set; }

        public string FeeCoefficient { get; set; }
    }
}
