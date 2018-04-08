namespace IcoCryptex.Net.Objects
{
    public class IceApiSetDetails
    {
        public long Limit { get; set; }
        public long Remaining { get; set; }

        public bool CanListBalances { get; set; }
        public bool CanListWithdrawals { get; set; }
        public bool CanCreateWithdrawal { get; set; }
        public bool CanListDeposits { get; set; }
        public bool CanCreateDeposit { get; set; }
        public bool CanListOrders { get; set; }
        public bool CanEditOrders { get; set; }
        public bool CanListOrderHistory { get; set; }
        public bool CanListAccountDetails { get; set; }
        public bool CanListSecurityDetails { get; set; }
    }
}