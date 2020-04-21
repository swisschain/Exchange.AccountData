namespace AccountData.Common.Domain.Entities.Enums
{
    public enum BalanceUpdateEventType
    {
        Unknown = 0,

        CashIn = 1,

        CashOut = 2,

        CashTransfer = 3,

        Order = 4,

        ReservedBalanceUpdate = 5
    }
}
