using Swisschain.Exchange.AccountData.ApiClient.Common;
using Swisschain.Exchange.AccountData.ApiContract;

namespace Swisschain.Exchange.AccountData.ApiClient
{
    public class AccountDataClient : BaseGrpcClient, IAccountDataClient
    {
        public AccountDataClient(string serverGrpcUrl) : base(serverGrpcUrl)
        {
            Monitoring = new Monitoring.MonitoringClient(Channel);
        }

        public Monitoring.MonitoringClient Monitoring { get; }
    }
}
