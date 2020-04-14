namespace AccountData.Common.Configuration
{
    public class AccountDataServiceSettings
    {
        public string BalancesServiceAddress { get; set; }

        public DbConfig Db { get; set; }
    }
}
