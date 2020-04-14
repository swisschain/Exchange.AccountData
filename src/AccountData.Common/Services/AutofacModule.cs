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
        }
    }
}
