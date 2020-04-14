using Swisschain.Sdk.Server.WebApi.Pagination;

namespace AccountData.WebApi.Models.OrderHistory
{
    public class OrderHistoryRequestMany : PaginationRequest<long>
    {
        public long Id { get; set; }

        public string WalletId { get; set; }

        public string AssetPairId { get; set; }
    }
}
