namespace AccountData.Common.Configuration
{
    public class AppConfig
    {
        public AccountDataServiceSettings AccountDataService { get; set; }

        public JwtConfig Jwt { get; set; }
    }
}
