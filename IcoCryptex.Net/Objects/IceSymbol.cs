using System;

namespace IcoCryptex.Net.Objects
{
    public sealed class IceSymbol
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public DateTime Added { get; set; }
        public DateTime? ScheduledRemoval { get; set; }

        public override string ToString()
        {
            return $"[{Symbol}] {Name}";
        }
    }
}