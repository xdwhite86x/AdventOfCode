using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Day01
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();

        }
        private static void Part1()
        {
            
            List<int> list = ReadInpuFile();
            int increased = Increased(list);
            Console.WriteLine(increased);   
        }

        private static void Part2()
        {
            var list = ReadInpuFile();
            int increased = IncreasedAverage(list);
            Console.WriteLine(increased);
        }

        private static int IncreasedAverage(List<int> list)
        {
            int increased = 0;
            for (int i = 0; i < list.Count - 3; ++i)
            {
                //just make sure we dont run off the end!
                if ((i + 3) > 2000)
                    break;
                //sum1 is the current and next 2 values
                int sum1 = (list[i] + list[i + 1] + list[i + 2]);
                // sum2 is the next 3 numbers
                int sum2 = (list[i + 1] + list[i + 2] + list[i + 3]);

                if (sum2 > sum1)
                    ++increased;
            }

            return increased;
        }



        private static List<int> ReadInpuFile()
        {
            List<int> list = new();
            using StreamReader sr = new("./Input.txt");
            
            while (!(sr.EndOfStream))
            {
                list.Add(int.Parse(sr.ReadLine()));
            }
            return list;
        }

        private static int Increased(List<int> list)
        {
            int Last = 0;
            int increased = 0;
            int decreased = 0;
            foreach (var i in list)
            {
                if (Last != 0)
                {
                    if (i > Last)
                        increased++;
                    else
                        decreased++;
                }

                Last = i;
            }

            return increased;
        }
    }
}