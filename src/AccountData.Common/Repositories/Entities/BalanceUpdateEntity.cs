using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AccountData.Common.Domain.Entities.Enums;

namespace AccountData.Common.Repositories.Entities
{
    [Table("balance_updates")]
    public class BalanceUpdateEntity
    {
        [Key]
        [Column("id", TypeName = "bigint")]
        public long Id { get; set; }

        [Required]
        [Column("message_id", TypeName = "bigint")]
        public long MessageId { get; set; }

        [Required]
        [Column("broker_id", TypeName = "varchar(255)")]
        public string BrokerId { get; set; }

        [Required]
        [Column("account_id", TypeName = "bigint")]
        public long AccountId { get; set; }

        [Required]
        [Column("wallet_id", TypeName = "bigint")]
        public long WalletId { get; set; }

        [Required]
        [Column("asset_id", TypeName = "varchar(255)")]
        public string Asset { get; set; }

        [Required]
        [Column("balance", TypeName = "varchar(255)")]
        public string Balance { get; set; }

        [Required]
        [Column("old_balance", TypeName = "varchar(255)")]
        public string OldBalance { get; set; }

        [Required]
        [Column("reserved", TypeName = "varchar(255)")]
        public string Reserved { get; set; }

        [Required]
        [Column("old_reserved", TypeName = "varchar(255)")]
        public string OldReserved { get; set; }

        [Required]
        [Column("event_type", TypeName = "int2")]
        public BalanceUpdateEventType EventType { get; set; }

        [Required]
        [Column("timestamp", TypeName = "timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
