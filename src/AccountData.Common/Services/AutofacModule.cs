using AccountData.Common.Domain.Services;
using Autofac;

namespace AccountData.Common.Services
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BalancesService>()
                .As<IBalancesService>()
                .SingleInstance();
        }
    }
}
