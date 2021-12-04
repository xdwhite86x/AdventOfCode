using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode
{
    class Program
    {
        
        static void Main(string[] args)
        {
            using StreamReader sr = new("./input3.txt");


            List<Day3Input> inputs = new();
            List<Day3Input> current = new();
            List<Day3Input> last;
            while (!sr.EndOfStream)
            {
                var temp = sr.ReadLine();
                if (!(temp is null))
                {
                    inputs.Add(new (temp));
                }
            }

            
            foreach (var i in inputs)
            {
                Console.WriteLine(i.DecimalValue);
                for (int j = 0; j < i.BitValues.Length; ++j)
                {
                    Console.Write(i.BitValues[j] ? 1 : 0);
                }
                Console.WriteLine();
                
            }

            Console.WriteLine("Total Entries = {0}", inputs.Count);
            last = inputs;

            for (int i = 0; i < 12; ++i)
            {
                List<int> Ones = new();
                List<int> Zeros = new();
                for (var j = 0; j < last.Count; j++)
                {
                    Day3Input d = last[j];
                    if (d.BitValues[i])
                    {
                        Ones.Add(j);
                    }
                    else
                    {
                        Zeros.Add(j);
                    }
                }

                if (Ones.Count != Zeros.Count)
                {
                    last = last.CreateSublistFromIndexes(Ones.Count > Zeros.Count ? Ones : Zeros);
                }

                foreach (var t in last)
                {
                    Console.WriteLine(t.StringValue);
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine(last.Count);

        }
        
        
        public static int Convert(string n)
        {
            int dec = 0;
            
            for (int i = 0; i < n.Length; ++i)
            {
                if (n[i] == '1')
                {
                    dec += 1 << (n.Length - (i + 1));
                }
            }
            return dec;
        }
    }
}
