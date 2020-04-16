using AccountData.Common.Configuration;
using AccountData.Common.Domain.Repositories;
using AccountData.Common.Domain.Services;
using AccountData.Common.Repositories;
using AccountData.Common.Repositories.Context;
using Autofac;

namespace AccountData.Common.Services
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
            builder.RegisterType<BalancesService>()
                .As<IBalancesService>()
                .SingleInstance();

            LoadRepositories(builder);

            LoadServices(builder);
        }

        protected void LoadRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<ConnectionFactory>()
                .AsSelf()
                .WithParameter(TypedParameter.From(_config.AccountDataService.Db.ConnectionString))
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
        }

        protected void LoadServices(ContainerBuilder builder)
        {
            builder.RegisterType<BalanceUpdateService>()
                .As<IBalanceUpdateService>()
                .SingleInstance();

            builder.RegisterType<FeeInstructionService>()
                .As<IFeeInstructionService>()
                .SingleInstance();

            builder.RegisterType<FeeTransferService>()
                .As<IFeeTransferService>()
                .SingleInstance();

            builder.RegisterType<OrderService>()
                .As<IOrderService>()
                .SingleInstance();

            builder.RegisterType<OrderHistoryService>()
                .As<IOrderHistoryService>()
                .SingleInstance();

            builder.RegisterType<TradeService>()
                .As<ITradeService>()
                .SingleInstance();
        }
    }
}
