namespace Day04
{
    public class BingoNumber
    {
        public int Value { get; set; }
        public bool Called { get; set; }

        public BingoNumber(int value)
        {
            Value = value;
            Called = false;
        }

        public static bool operator ==(BingoNumber a, int b)
        {
            return a.Value == b;
        }

        public static bool operator !=(BingoNumber a, int b)
        {
            return !(a == b);
        }
        
    }
}