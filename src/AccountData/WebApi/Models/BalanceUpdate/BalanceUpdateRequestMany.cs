using System.ComponentModel.DataAnnotations;
using AccountData.Common.Domain.Entities.Enums;
using Swisschain.Sdk.Server.WebApi.Pagination;

namespace AccountData.WebApi.Models.BalanceUpdate
{
    public class BalanceUpdateRequestMany : PaginationRequest<long>
    {
        public long Id { get; set; }

        [Required]
        public long AccountId { get; set; }

        public long WalletId { get; set; }

        public string Asset { get; set; }

        public BalanceUpdateEventType? EventType { get; set; }
    }
}
