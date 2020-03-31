using Autofac;
using MatchingEngine.Client;
using MatchingEngine.Client.Extensions;

namespace AccountData
{
    public class AutofacModule : Module
    {
        private readonly string _balancesServiceAddress;

        public AutofacModule(string balancesServiceAddress)
        {
            _balancesServiceAddress = balancesServiceAddress;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterMatchingEngineClient(new MatchingEngineClientSettings
            {
                BalancesServiceAddress = _balancesServiceAddress
            });
        }
    }
}
