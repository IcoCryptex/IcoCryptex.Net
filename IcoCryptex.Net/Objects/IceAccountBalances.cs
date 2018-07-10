using System.Collections.Generic;

namespace IcoCryptex.Net.Objects
{
    public class IceAccountBalances
    {
        public List<IceAccountBalance> Available { get; set; }
        public List<IceAccountBalance> Locked { get; set; }
    }
}