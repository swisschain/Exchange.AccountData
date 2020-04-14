using AccountData.Common.Domain.Entities.Enums;

namespace AccountData.WebApi.Models.FeeInstruction
{
    public class FeeInstructionModel
    {
        public long Id { get; set; }

        public string BrokerId { get; set; }

        public long OrderId { get; set; }

        public string SourceWalletId { get; set; }

        public string TargetWalletId { get; set; }

        public string AssetsIds { get; set; }

        public FeeType FeeType { get; set; }

        public string Size { get; set; }

        public FeeSizeType SizeType { get; set; }

        public string MakerSize { get; set; }

        public int MakerSizeType { get; set; }

        public string MakerFeeModificator { get; set; }
    }
}
