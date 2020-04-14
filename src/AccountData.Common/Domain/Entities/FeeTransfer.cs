namespace AccountData.Common.Domain.Entities
{
    public class FeeTransfer
    {
        public long Id { get; set; }

        public string BrokerId { get; set; }

        public long OrderId { get; set; }

        public string SourceWalletId { get; set; }

        public string TargetWalletId { get; set; }

        public string AssetsId { get; set; }

        public string Volume { get; set; }

        public string FeeCoefficient { get; set; }
    }
}
