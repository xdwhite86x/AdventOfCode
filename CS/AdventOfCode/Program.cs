using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode
{
    class Program
    {
        private static Bingo bingo;
        static void Main(string[] args)
        {
            day4_part1();
        }

        private static void day4_part1()
        {
            ParseBingoFile();

            foreach (var num in bingo.CalledNumbers)
            {
                foreach (var board in bingo.BingoBoards)
                {
                    foreach(var line in board.Board)
                    {
                        foreach (var val in line)
                        {
                            if (val.Value == num)
                                val.Called = true;
                        }
                    }
                }
            }
            
        }

        private static void ParseBingoFile()
        {
            bingo = new("./inputDay4.txt");
        }

        private static void day3_part2()
        {
            using StreamReader sr = new("./input32.txt");


            List<Day3Input> inputs = new();
            List<Day3Input> oxyList;
            List<Day3Input> C02List;
            while (!sr.EndOfStream)
            {
                var temp = sr.ReadLine();
                if (!(temp is null))
                {
                    inputs.Add(new(temp));
                }
            }


            // foreach (var i in inputs)
            // {
            // Console.WriteLine(i.DecimalValue);
            // for (int j = 0; j < i.BitValues.Length; ++j)
            // {
            // Console.Write(i.BitValues[j] ? 1 : 0);
            // }
            // Console.WriteLine();

            // }

            Console.WriteLine("Total Entries = {0}", inputs.Count);
            oxyList = inputs;


            for (int i = 0; i < 12; ++i)
            {
                List<int> Ones = new();
                List<int> Zeros = new();
                for (var j = 0; j < oxyList.Count; j++)
                {
                    Day3Input d = oxyList[j];

                    if (d.BitValues[i])
                        Ones.Add(j);
                    else
                        Zeros.Add(j);
                }

                if (Ones.Count != Zeros.Count)
                {
                    oxyList = oxyList.CreateSublistFromIndexes(Ones.Count > Zeros.Count ? Ones : Zeros);
                    // C02List = C02List.CreateSublistFromIndexes(Ones.Count > Zeros.Count ? Zeros : Ones);
                }
                else
                {
                    oxyList = oxyList.CreateSublistFromIndexes(Ones);
                    // C02List = C02List.CreateSublistFromIndexes(Zeros);
                }

                // foreach (var t in oxyList)
                // Console.WriteLine("{0}, {1}", t.StringValue, t.DecimalValue);
                if (oxyList.Count == 1)
                    Console.WriteLine("{0}, {1}", oxyList[0].StringValue, oxyList[0].DecimalValue);


                // Console.WriteLine();
                // Console.WriteLine();
                // Console.WriteLine("Bit #{0} {1} Candidates Left, bit chosen {2}", i + 1, oxyList.Count, Ones.Count > Zeros.Count ? '1' :'0');
            }

            C02List = inputs;

            for (int i = 0; i < 12; ++i)
            {
                List<int> Ones = new();
                List<int> Zeros = new();
                for (var j = 0; j < C02List.Count; j++)
                {
                    Day3Input d = C02List[j];

                    if (d.BitValues[i])
                        Ones.Add(j);
                    else
                        Zeros.Add(j);
                }

                if (Ones.Count != Zeros.Count)
                {
                    // oxyList = oxyList.CreateSublistFromIndexes(Ones.Count > Zeros.Count ? Ones : Zeros);
                    C02List = C02List.CreateSublistFromIndexes(Ones.Count > Zeros.Count ? Zeros : Ones);
                }
                else
                {
                    // oxyList = oxyList.CreateSublistFromIndexes(Ones);
                    C02List = C02List.CreateSublistFromIndexes(Zeros);
                }

                if (C02List.Count == 1)
                    Console.WriteLine("{0}, {1}", C02List[0].StringValue, C02List[0].DecimalValue);


                // Console.WriteLine();
                // Console.WriteLine();
                // Console.WriteLine("Bit #{0} {1} Candidates Left, bit chosen {2}", i + 1, C02List.Count, Ones.Count > Zeros.Count ? '1' :'0');
            }

            // Console.WriteLine(oxyList.Count);
            Console.WriteLine("C02 list count is {0}", C02List.Count);
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
