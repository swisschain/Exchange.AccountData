using Swisschain.Exchange.AccountData.ApiContract;

namespace Swisschain.Exchange.AccountData.ApiClient
{
    public interface IAccountDataClient
    {
        Monitoring.MonitoringClient Monitoring { get; }
    }
}
