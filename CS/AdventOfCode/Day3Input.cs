using System;
using System.Collections;

namespace AdventOfCode
{
    public class Day3Input
    {
        public string StringValue { get; }
        public BitArray BitValues { get; }
        public UInt16 DecimalValue { get; }

        private const int Inputlength = 12; 

        public Day3Input(string fileInput)
        {
            StringValue = fileInput;
            BitValues = new BitArray(Inputlength);
            DecimalValue = Convert(StringValue);


            for (var i = 0; i < StringValue.Length; i++)
            {
                char c = StringValue[i];
                if (c == '1')
                {
                    BitValues[i] = true;
                }
            }
        }
        
        public static UInt16 Convert(string n)
        {
             UInt16 dec = 0;
            
            for (int i = 0; i < n.Length; ++i)
            {
                if (n[i] == '1')
                {
                    dec += (UInt16)(1 << (n.Length - (i + 1)));
                }
            }
            return dec;
        }
    }
}