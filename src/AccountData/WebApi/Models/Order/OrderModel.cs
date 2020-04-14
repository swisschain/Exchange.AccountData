using System;
using AccountData.Common.Domain.Entities.Enums;

namespace AccountData.WebApi.Models.Order
{
    public class OrderModel
    {
        public long Id { get; set; }

        public string WalletId { get; set; }

        public string AssetPairId { get; set; }

        public OrderType OrderType { get; set; }

        public OrderSide Side { get; set; }

        public string Volume { get; set; }

        public string RemainingVolume { get; set; }

        public string Price { get; set; }

        public OrderStatus Status { get; set; }

        public string RejectReason { get; set; }

        public DateTimeOffset StatusDate { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset RegisteredAt { get; set; }

        public DateTimeOffset LastMatchTime { get; set; }

        public string LowerLimitPrice { get; set; }

        public string LowerPrice { get; set; }

        public string UpperLimitPrice { get; set; }

        public string UpperPrice { get; set; }

        public OrderTimeInForce TimeInForce { get; set; }

        public string ExpiryTime { get; set; }
    }
}
