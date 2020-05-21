using AccountData.Common.Configuration;
using AccountData.Common.Domain.Repositories;
using AccountData.Common.Repositories.Context;
using Autofac;

namespace AccountData.Common.Repositories
{
    public class AutofacModule : Module
    {
        private readonly AppConfig _config;

        public AutofacModule(AppConfig config)
        {
            _config = config;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConnectionFactory>()
                .AsSelf()
                .WithParameter(TypedParameter.From(_config.AccountDataService.Db.ConnectionString))
                .SingleInstance();

            builder.RegisterType<BalanceRepository>()
                .As<IBalanceRepository>()
                .SingleInstance();

            builder.RegisterType<BalanceUpdateRepository>()
                .As<IBalanceUpdateRepository>()
                .SingleInstance();

            builder.RegisterType<FeeInstructionRepository>()
                .As<IFeeInstructionRepository>()
                .SingleInstance();

            builder.RegisterType<FeeTransferRepository>()
                .As<IFeeTransferRepository>()
                .SingleInstance();

            builder.RegisterType<OrderRepository>()
                .As<IOrderRepository>()
                .SingleInstance();

            builder.RegisterType<OrderHistoryRepository>()
                .As<IOrderHistoryRepository>()
                .SingleInstance();

            builder.RegisterType<TradeRepository>()
                .As<ITradeRepository>()
                .SingleInstance();

            builder.RegisterType<CashInRepository>()
                .As<ICashInRepository>()
                .SingleInstance();

            builder.RegisterType<CashOutRepository>()
                .As<ICashOutRepository>()
                .SingleInstance();

            builder.RegisterType<CashTransferRepository>()
                .As<ICashTransferRepository>()
                .SingleInstance();
        }
    }
}
