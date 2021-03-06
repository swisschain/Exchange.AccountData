﻿using System;
using AccountData.Common.Domain.Entities.Enums;

namespace AccountData.WebApi.Models.Trade
{
    public class TradeModel
    {
        public long Id { get; set; }

        public string BrokerId { get; set; }

        public string ExternalOrderId { get; set; }

        public string TradeId { get; set; }

        public long AccountId { get; set; }

        public long WalletId { get; set; }

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

        public string AbsoluteSpread { get; set; }

        public string RelativeSpread { get; set; }

        public TradeRole Role { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
