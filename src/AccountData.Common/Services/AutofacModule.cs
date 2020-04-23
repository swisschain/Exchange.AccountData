using AccountData.Common.Configuration;
using AccountData.Common.Domain.Services;
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
