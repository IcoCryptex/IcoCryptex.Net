using System;

namespace IcoCryptex.Net.Objects
{
    public sealed class IceSymbolPair
    {
        public string Name { get; set; }
        public string PrimarySymbol { get; set; }
        public string SecondarySymbol { get; set; }
        public DateTime Added { get; set; }

        public override string ToString()
        {
            return $"[{Name}] {PrimarySymbol} vs {SecondarySymbol}";
        }
    }
}