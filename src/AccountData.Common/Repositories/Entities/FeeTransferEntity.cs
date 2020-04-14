using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountData.Common.Repositories.Entities
{
    [Table("fee_transfers")]
    public class FeeTransferEntity
    {
        [Key]
        [Column("id", TypeName = "int8")]
        public long Id { get; set; }

        [Required]
        [Column("message_id", TypeName = "bigint")]
        public long MessageId { get; set; }

        [Required]
        [Column("broker_id", TypeName = "varchar(255)")]
        public string BrokerId { get; set; }

        [Column("order_id", TypeName = "int8")]
        public long OrderId { get; set; }

        [Required]
        [Column("source_wallet_id", TypeName = "varchar(255)")]
        public string SourceWalletId { get; set; }

        [Required]
        [Column("target_wallet_id", TypeName = "varchar(255)")]
        public string TargetWalletId { get; set; }

        [Column("assets_id", TypeName = "varchar(255)")]
        public string AssetsId { get; set; }

        [Required]
        [Column("volume", TypeName = "varchar(255)")]
        public string Volume { get; set; }

        [Column("fee_coef", TypeName = "varchar(255)")]
        public string FeeCoefficient { get; set; }

        [Column("index", TypeName = "int8")]
        public long Index { get; set; }
    }
}
