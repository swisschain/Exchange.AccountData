﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountData.Common.Repositories.Entities
{
    [Table("fee_transfers")]
    public class FeeTransferEntity
    {
        [Key]
        [Column("id", TypeName = "bigint")]
        public long Id { get; set; }

        [Required]
        [Column("broker_id", TypeName = "varchar(255)")]
        public string BrokerId { get; set; }

        [Column("order_id", TypeName = "int8")]
        public long OrderId { get; set; }

        [Required]
        [Column("source_account_id", TypeName = "bigint")]
        public long FromAccountId { get; set; }

        [Required]
        [Column("target_account_id", TypeName = "bigint")]
        public long ToAccountId { get; set; }

        [Required]
        [Column("source_wallet_id", TypeName = "bigint")]
        public long FromWalletId { get; set; }

        [Required]
        [Column("target_wallet_id", TypeName = "bigint")]
        public long ToWalletId { get; set; }

        [Column("asset_id", TypeName = "varchar(255)")]
        public string AssetId { get; set; }

        [Required]
        [Column("volume", TypeName = "varchar(255)")]
        public string Volume { get; set; }

        [Column("fee_coef", TypeName = "varchar(255)")]
        public string FeeCoefficient { get; set; }
    }
}
