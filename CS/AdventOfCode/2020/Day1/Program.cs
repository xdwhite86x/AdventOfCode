using System;
using System.Collections.Generic;
using System.IO;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        static int Day1Part1()
        {
            using StreamReader sr = new("./input.txt");
            List<int> list = new(); 
            while (!(sr.EndOfStream))
            {
                list.Add(int.Parse(sr.ReadLine()));
            }

            for (var i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; ++j)
                {
                    for (int k = 0; k < list.Count; ++k)
                    {
                        if (i != k && i != j && j != k)
                            if (list[i] + list[j] + list[k] == 2020)
                                return list[i] * list[j] * list[k];
                    }
                }
            }

            return -1;
        }
    }
    
    
}