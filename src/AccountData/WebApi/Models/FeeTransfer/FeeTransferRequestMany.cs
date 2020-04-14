using Swisschain.Sdk.Server.WebApi.Pagination;

namespace AccountData.WebApi.Models.FeeTransfer
{
    public class FeeTransferRequestMany : PaginationRequest<long>
    {
        public long Id { get; set; }


        public string SourceWalletId { get; set; }


        public string TargetWalletId { get; set; }


        public int OrderId { get; set; }


        public string AssetId { get; set; }
    }
}
