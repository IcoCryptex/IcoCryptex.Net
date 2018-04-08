namespace IcoCryptex.Net.Objects
{
    public class IceWalletTransaction
    {
        public long Id { get; set; }
        public string Symbol { get; set; }
        public int RequiredConfirmations { get; set; }
        public int CurrentConfirmations { get; set; }
        public string TransactionHash { get; set; }
        public decimal Amount { get; set; }
        public string SymbolName { get; set; }
        public long UnixTimestamp { get; set; }
        public bool Orphaned { get; set; }
    }
}