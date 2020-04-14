using Swisschain.Sdk.Server.WebApi.Pagination;

namespace AccountData.WebApi.Models.Trade
{
    public class TradeRequestMany : PaginationRequest<long>
    {
        public long Id { get; set; }


        public string ExternalId { get; set; }


        public string WalletId { get; set; }


        public string BaseAssetId { get; set; }


        public string QuotingAssetId { get; set; }
    }
}
