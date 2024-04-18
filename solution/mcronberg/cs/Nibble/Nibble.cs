namespace NibbleNS
{
    public struct Nibble(int value) : IEquatable<Nibble>
    {
        private byte value = ValidateValue(value);

        public int Value
        {
            readonly get { return value; }
            set { this.value = ValidateValue(value); }
        }

        private static byte ValidateValue(int value)
        {
            if (value < 0 || value > 15)
                throw new ArgumentOutOfRangeException(nameof(value), "Nibble value must be between 0 and 15.");

            return (byte)(value & 0xF); 
        }

        public static implicit operator Nibble(int value) => new(value);

        public static implicit operator int(Nibble nibble) => nibble.value;

        public static Nibble operator +(Nibble a, Nibble b) => new(a.value + b.value);

        public static Nibble operator -(Nibble a, Nibble b) => new(a.value - b.value);

        public static Nibble operator *(Nibble a, Nibble b) => new(a.value * b.value);

        public static Nibble operator /(Nibble a, Nibble b)
        {
            if (b.value == 0)
                throw new DivideByZeroException("Cannot divide by zero.");
            return new Nibble(a.value / b.value);
        }

        public static bool operator <(Nibble a, Nibble b) => a.value < b.value;

        public static bool operator >(Nibble a, Nibble b) => a.value > b.value;

        public static bool operator <=(Nibble a, Nibble b) => a.value <= b.value;

        public static bool operator >=(Nibble a, Nibble b) => a.value >= b.value;

        public static bool operator ==(Nibble a, Nibble b) => a.value == b.value;

        public static bool operator !=(Nibble a, Nibble b) => a.value != b.value;

        public override readonly bool Equals(object? obj) => obj is Nibble nibble && Equals(nibble);

        public readonly bool Equals(Nibble other) => value == other.value;

        public override readonly int GetHashCode() => value.GetHashCode();

        public override readonly string ToString() => this.value.ToString();
    }
}
