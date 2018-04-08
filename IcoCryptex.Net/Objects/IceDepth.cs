namespace IcoCryptex.Net.Objects
{
    public class IceDepth
    {
        public string SymbolPair { get; set; }
        public IceDepthRow[] BuyDepth { get; set; }
        public decimal BuyTotalPrimary { get; set; }
        public decimal BuyTotalSecondary { get; set; }
        public IceDepthRow[] SellDepth { get; set; }
        public decimal SellTotalPrimary { get; set; }
        public decimal SellTotalSecondary { get; set; }
    }
}