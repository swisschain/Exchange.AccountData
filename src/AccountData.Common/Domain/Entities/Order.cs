﻿using System;
using AccountData.Common.Domain.Entities.Enums;

namespace AccountData.Common.Domain.Entities
{
    public class Order
    {
        public long Id { get; set; }

        public string BrokerId { get; set; }

        public string ExternalId { get; set; }

        public string WalletId { get; set; }

        public string AssetPairId { get; set; }

        public OrderType OrderType { get; set; }

        public OrderSide Side { get; set; }

        public string Volume { get; set; }

        public string RemainingVolume { get; set; }

        public string Price { get; set; }

        public OrderStatus Status { get; set; }

        public string RejectReason { get; set; }

        public DateTime StatusDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime RegisteredAt { get; set; }

        public DateTime? LastMatchTime { get; set; }

        public string LowerLimitPrice { get; set; }

        public string LowerPrice { get; set; }

        public string UpperLimitPrice { get; set; }

        public string UpperPrice { get; set; }

        public OrderTimeInForce TimeInForce { get; set; }

        public string ExpiryTime { get; set; }
    }
}
