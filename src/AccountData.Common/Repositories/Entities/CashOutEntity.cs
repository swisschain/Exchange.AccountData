using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountData.Common.Repositories.Entities
{
    [Table("cash_outs")]
    public class CashOutEntity
    {
        [Key]
        [Column("id", TypeName = "bigint")]
        public long Id { get; set; }

        [Required]
        [Column("message_id", TypeName = "bigint")]
        public long MessageId { get; set; }

        [Required]
        [Column("balance_update_id", TypeName = "bigint")]
        public long BalanceUpdateId { get; set; }

        [Required]
        [Column("broker_id", TypeName = "varchar(255)")]
        public string BrokerId { get; set; }

        [Required]
        [Column("asset_id", TypeName = "varchar(255)")]
        public string AssetId { get; set; }

        [Required]
        [Column("volume", TypeName = "varchar(255)")]
        public string Volume { get; set; }

        [Required]
        [Column("description", TypeName = "varchar")]
        public string Description { get; set; }
    }
}
