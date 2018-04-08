namespace IcoCryptex.Net.Objects.Util
{
    public sealed class DecimalCast
    {
        public readonly decimal Value;

        private DecimalCast(decimal value)
        {
            Value = value;
        }

        public static implicit operator DecimalCast(byte value)
        {
            return (decimal)value;
        }
        public static implicit operator DecimalCast(short value)
        {
            return (decimal)value;
        }
        public static implicit operator DecimalCast(int value)
        {
            return (decimal)value;
        }
        public static implicit operator DecimalCast(long value)
        {
            return (decimal)value;
        }
        public static implicit operator DecimalCast(double value)
        {
            return (decimal)value;
        }
        public static implicit operator DecimalCast(decimal value)
        {
            return new DecimalCast(value);
        }
        public static implicit operator decimal(DecimalCast value)
        {
            return value.Value;
        }
    }
}