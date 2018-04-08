using System;

namespace IcoCryptex.Net.Objects
{
    public class IceCreateWithdrawalRequest
    {
        public string Address { get; set; }
        public decimal Amount { get; set; }
        public Guid? FeeQuoteId { get; set; }
    }
}