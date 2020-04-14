using System;

namespace AccountData.WebApi.Models.Trade
{
    public class TradeModel
    {
        public long Id { get; set; }

        public long MessageId { get; set; }

        public string BrokerId { get; set; }

        public string TradeId { get; set; }

        public string WalletId { get; set; }

        public string OppositeWalletId { get; set; }

        public long OrderId { get; set; }

        public string OppositeOrderId { get; set; }

        public string OppositeExternalOrderId { get; set; }

        public long OrderHistoryId { get; set; }

        public string BaseAssetId { get; set; }

        public string QuotingAssetId { get; set; }

        public string Price { get; set; }

        public string BaseVolume { get; set; }

        public string QuotingVolume { get; set; }

        public long Index { get; set; }

        public string AbsoluteSpread { get; set; }

        public string RelativeSpread { get; set; }

        public int Role { get; set; }

        public DateTimeOffset Timestamp { get; set; }
    }
}
