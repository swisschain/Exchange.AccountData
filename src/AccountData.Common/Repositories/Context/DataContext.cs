using System;
using AccountData.Common.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountData.Common.Repositories.Context
{
    public class DataContext : DbContext
    {
        private const string Schema = "public";

        private string _connectionString;

        internal DbSet<BalanceUpdateEntity> BalanceUpdates { get; set; }

        internal DbSet<FeeInstructionEntity> FeeInstructions { get; set; }

        internal DbSet<FeeTransferEntity> FeeTransfers { get; set; }

        internal DbSet<OrderEntity> Orders { get; set; }

        internal DbSet<TradeEntity> Trades { get; set; }

        public DataContext()
        {
        }

        public DataContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_connectionString == null)
            {
                Console.Write("Enter connection string: ");
                _connectionString = Console.ReadLine();
            }

            optionsBuilder.UseNpgsql(_connectionString,
                o => o.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schema));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schema);

            modelBuilder.Entity<BalanceUpdateEntity>();
            modelBuilder.Entity<FeeInstructionEntity>();
            modelBuilder.Entity<FeeTransferEntity>();
            modelBuilder.Entity<OrderEntity>();
            modelBuilder.Entity<TradeEntity>();
        }
    }
}
