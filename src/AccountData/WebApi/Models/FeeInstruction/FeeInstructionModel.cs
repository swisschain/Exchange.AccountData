using System;

namespace AccountData.WebApi.Models.FeeInstruction
{
    public class FeeInstructionModel
    {
        public long Id { get; set; }

        public long MessageId { get; set; }

        public string BrokerId { get; set; }

        public long OrderId { get; set; }

        public string SourceWalletId { get; set; }

        public string TargetWalletId { get; set; }

        public string AssetsIds { get; set; }

        public int FeeType { get; set; }

        public string Size { get; set; }

        public int SizeType { get; set; }

        public string MakerSize { get; set; }

        public int MakerSizeType { get; set; }

        public string MakerFeeModificator { get; set; }

        public long Index { get; set; }
    }
}
