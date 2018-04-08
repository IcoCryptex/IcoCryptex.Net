using System.Collections.Generic;

namespace IcoCryptex.Net.Objects
{
    public class IceAccountBalances
    {
        public Dictionary<string, decimal> Available { get; set; }
        public Dictionary<string, decimal> Escrow { get; set; } 
    }
}