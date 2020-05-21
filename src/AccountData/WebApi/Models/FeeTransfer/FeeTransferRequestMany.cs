using Swisschain.Sdk.Server.WebApi.Pagination;

namespace AccountData.WebApi.Models.FeeTransfer
{
    public class FeeTransferRequestMany : PaginationRequest<long>
    {
        public long Id { get; set; }

        public long FromWalletId { get; set; }

        public long ToWalletId { get; set; }

        public int OrderId { get; set; }

        public string AssetId { get; set; }
    }
}
