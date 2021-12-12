using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Day03
{
    public class BinStr
    {
        public string StrVal { get; set; }
        public int DecValue { get; }
        public BitArray BinaryBits { get; }

        public BinStr(List<int> binList)
        {
            BinaryBits = new(binList.Count);
            BinaryBits.SetAll(false);
            StringBuilder sb = new();
            
            for (var index = 0; index < binList.Count; index++)
            {
                var val = binList[index];
                BinaryBits.Set(index, val >= 1);
                sb.Append(val >= 1 ? "1" : "0");
            }

            DecValue = sb.ToString().ConvertStrBinToDec();
            StrVal = sb.ToString();
        }

        public static int operator *(BinStr a, BinStr b)
        {
            return a.DecValue * b.DecValue;
        }
    }
}