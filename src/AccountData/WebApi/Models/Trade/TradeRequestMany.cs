using Swisschain.Sdk.Server.WebApi.Pagination;

namespace AccountData.WebApi.Models.Trade
{
    public class TradeRequestMany : PaginationRequest<string>
    {
        public string ExternalOrderId { get; set; }


        public string WalletId { get; set; }


        public string BaseAsset { get; set; }


        public string QuotingAsset { get; set; }
    }
}
