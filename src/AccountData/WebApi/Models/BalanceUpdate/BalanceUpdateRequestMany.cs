using Swisschain.Sdk.Server.WebApi.Pagination;

namespace AccountData.WebApi.Models.BalanceUpdate
{
    public class BalanceUpdateRequestMany : PaginationRequest<long>
    {
        public long Id { get; set; }

        public string WalletId { get; set; }

        public string AssetId { get; set; }
    }
}
