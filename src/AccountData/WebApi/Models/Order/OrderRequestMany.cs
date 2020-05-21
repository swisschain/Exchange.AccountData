using AccountData.Common.Domain.Entities.Enums;
using Swisschain.Sdk.Server.WebApi.Pagination;

namespace AccountData.WebApi.Models.Order
{
    public class OrderRequestMany : PaginationRequest<long>
    {
        public long Id { get; set; }

        public string ExternalId { get; set; }

        public long AccountId { get; set; }

        public long WalletId { get; set; }

        public string AssetPairId { get; set; }

        public OrderType? OrderType { get; set; }

        public OrderSide? Side { get; set; }

        public OrderStatus? Status { get; set; }

        public OrderTimeInForce? TimeInForce { get; set; }
    }
}
