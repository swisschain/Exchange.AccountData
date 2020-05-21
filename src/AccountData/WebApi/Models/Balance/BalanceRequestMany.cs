using System.ComponentModel.DataAnnotations;
using Swisschain.Sdk.Server.WebApi.Pagination;

namespace AccountData.WebApi.Models.Balance
{
    public class BalanceRequestMany : PaginationRequest<long>
    {
        [Required]
        public long AccountId { get; set; }

        public long WalletId { get; set; }

        public string Asset { get; set; }
    }
}
