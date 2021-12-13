using System;
using System.Net.Sockets;

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
            if (a is null)
            {
                return false;
            }
            return a.Value == b;
        }

        public static bool operator !=(BingoNumber a, int b)
        {
            if (a is null)
            {
                return false;
            }
            return (a.Value != b);
        }

        public override bool Equals(object? obj)
        {
            return ReferenceEquals((BingoNumber)obj, this);
        }

        protected bool Equals(BingoNumber other)
        {
            return Value == other.Value && Called == other.Called;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Called);
        }
    }
}