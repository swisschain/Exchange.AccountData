namespace AccountData.Common.Domain.Entities.Enums
{
    public enum OrderTimeInForce
    {
        Unknown = 0,

        GoodTilCancelled = 1,

        GoodTilDate = 2,

        ImmediateOrCancel = 3,
        
        FillOrKill = 4
    }
}
