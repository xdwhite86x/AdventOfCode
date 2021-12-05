namespace AdventOfCode
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
        
    }
}