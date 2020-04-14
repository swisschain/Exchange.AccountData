using Swisschain.Sdk.Server.WebApi.Pagination;

namespace AccountData.WebApi.Models.Trade
{
    public class TradeRequestMany : PaginationRequest<long>
    {
        public long Id { get; set; }


        public string TradeId { get; set; }


        public string WalletId { get; set; }


        public string OppositeWalletId { get; set; }


        public long OrderId { get; set; }


        public string OppositeOrderId { get; set; }


        public string OppositeExternalOrderId { get; set; }


        public long OrderHistoryId { get; set; }


        public string BaseAssetId { get; set; }


        public string QuotingAssetId { get; set; }
    }
}
