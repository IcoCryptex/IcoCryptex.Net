using System.Collections.Generic;
using System.Linq;

namespace IcoCryptex.Net.Objects.Raw
{
    internal sealed class IceDepthRaw
    {
        public List<decimal[]> BuyDepth { get; set; }
        public decimal BuyTotalPrimary { get; set; }
        public decimal BuyTotalSecondary { get; set; }
        public List<decimal[]> SellDepth { get; set; }
        public decimal SellTotalPrimary { get; set; }
        public decimal SellTotalSecondary { get; set; }

        public static implicit operator IceDepth(IceDepthRaw raw)
        {
            return new IceDepth
            {
                BuyDepth = raw.BuyDepth.Select(array => new IceDepthRow(array[0], array[1])).ToArray(),
                BuyTotalPrimary = raw.BuyTotalPrimary,
                BuyTotalSecondary= raw.BuyTotalSecondary,
                SellDepth = raw.SellDepth.Select(array => new IceDepthRow(array[0], array[1])).ToArray(),
                SellTotalPrimary = raw.SellTotalPrimary,
                SellTotalSecondary = raw.SellTotalSecondary
            };
        }
    }
}