using System;

namespace AccountData.WebApi.Models.FeeTransfer
{
    public class FeeTransferModel
    {
        public long Id { get; set; }

        public string BrokerId { get; set; }

        public long OrderId { get; set; }

        public long FromAccountId { get; set; }

        public long ToAccountId { get; set; }

        public long FromWalletId { get; set; }

        public long ToWalletId { get; set; }

        public string AssetId { get; set; }

        public string Volume { get; set; }

        public string FeeCoefficient { get; set; }
    }
}
