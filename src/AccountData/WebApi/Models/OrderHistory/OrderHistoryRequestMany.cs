using System.ComponentModel.DataAnnotations;
using Swisschain.Sdk.Server.WebApi.Pagination;

namespace AccountData.WebApi.Models.OrderHistory
{
    public class OrderHistoryRequestMany : PaginationRequest<long>
    {
        public long Id { get; set; }

        [Required]
        public long AccountId { get; set; }

        public long WalletId { get; set; }

        public string AssetPairId { get; set; }
    }
}
