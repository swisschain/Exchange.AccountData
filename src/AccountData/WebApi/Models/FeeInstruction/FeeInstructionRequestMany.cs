using System.ComponentModel.DataAnnotations;
using Swisschain.Sdk.Server.WebApi.Pagination;

namespace AccountData.WebApi.Models.FeeInstruction
{
    public class FeeInstructionRequestMany : PaginationRequest<long>
    {
        public long Id { get; set; }

        [Required]
        public long AccountId { get; set; }

        public long FromWalletId { get; set; }

        public long ToWalletId { get; set; }

        public int OrderId { get; set; }

        public string AssetId { get; set; }
    }
}
