using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AccountData.Common.Domain.Entities.Enums;

namespace AccountData.Common.Repositories.Entities
{
    [Table("fee_instructions")]
    public class FeeInstructionEntity
    {
        [Key]
        [Column("id", TypeName = "int8")]
        public long Id { get; set; }

        [Required]
        [Column("broker_id", TypeName = "varchar(255)")]
        public string BrokerId { get; set; }

        [Column("order_id", TypeName = "int8")]
        public long OrderId { get; set; }

        [Column("source_wallet_id", TypeName = "varchar(255)")]
        public string SourceWalletId { get; set; }

        [Column("target_wallet_id", TypeName = "varchar(255)")]
        public string TargetWalletId { get; set; }

        [Column("assets_ids", TypeName = "varchar(255)")]
        public string AssetsIds { get; set; }

        [Required]
        [Column("fee_type", TypeName = "int2")]
        public FeeType FeeType { get; set; }

        [Column("size", TypeName = "varchar(255)")]
        public string Size { get; set; }

        [Column("size_type", TypeName = "int2")]
        public FeeSizeType SizeType { get; set; }

        [Column("maker_size", TypeName = "varchar(255)")]
        public string MakerSize { get; set; }

        [Column("maker_size_type", TypeName = "int2")]
        public int MakerSizeType { get; set; }

        [Column("maker_fee_modificator", TypeName = "varchar(255)")]
        public string MakerFeeModificator { get; set; }
    }
}
