using Swisschain.Sdk.Server.WebApi.Pagination;

namespace AccountData.WebApi.Models.Order
{
    public class OrderRequestMany : PaginationRequest<long>
    {
        public long Id { get; set; }

        public string WalletId { get; set; }

        public string AssetPairId { get; set; }
    }
}
