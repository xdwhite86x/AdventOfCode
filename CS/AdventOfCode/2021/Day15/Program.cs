using System;
using System.Collections.Generic;
using System.IO;

namespace Day15
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = ReadInput();
            
        }

        private static List<List<int>> ReadInput()
        {
            List<int>          row   = new();
            List<List<int>>    board = new();
            using StreamReader sr    = new StreamReader("./Input.txt");//-test.txt");
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                foreach (var c in line)
                {
                    row.Add(c - '0');
                }

                board.Add(row);
                row = new();
            }

            return board;
        }
    }
}
