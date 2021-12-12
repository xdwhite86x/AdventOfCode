using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Win32.SafeHandles;

namespace Day03
{
    unsafe class Program
    {
        static void Main(string[] args)
        {
            DiagReport diagReport = ReadInput();
            Part1(diagReport);
            Part2(diagReport);
        }
        private static void Part2(DiagReport diagReport)
        {
            BinStr oxyRating = GetOxyRating(diagReport);
            BinStr CoRating = GetCoRating(diagReport);
            
            Console.WriteLine(oxyRating.DecValue);
            Console.WriteLine(CoRating.DecValue);
            Console.WriteLine(oxyRating * CoRating);
        }

        private static void Part1(DiagReport diagReport)
        {
            List<int> mcList = new();
            List<int> lcList = new();
            foreach (List<int> column in diagReport.Columns)
            {
                int one = 0;
                int zero = 0;
                foreach (int i in column)
                {
                    if (i == 1)
                        ++one;
                    else
                        ++zero;
                }
                mcList.Add(one > zero ? 1 : 0);
                lcList.Add(one > zero ? 0 : 1);
            }

            BinStr mostCommon = new(mcList);
            BinStr leastCommon = new(lcList);
            Console.WriteLine(mostCommon.DecValue);
            Console.WriteLine(leastCommon.DecValue);
            Console.WriteLine(mostCommon.DecValue * leastCommon.DecValue);


        }

        private static DiagReport ReadInput()
        {
            var lines = File.ReadAllLines("./Input.txt");

            int rows = lines.Length;
            int cols = lines[0].Length;
            List<List<int>> input = new();
            for (int r = 0; r < rows; ++r)
            {
                List<int> line = new();
                for (int c = 0; c < cols; ++c)
                {
                    line.Add(lines[r][c] - 48);
                }
                input.Add(line);
            }

            return new(input);
        }
        private static BinStr GetOxyRating(DiagReport diagReport)
        {
            var report = diagReport;   
            for (var index = 0; index < report.Columns.Count; index++)
            {
                var r = report.Columns[index];
                int mc = report.GetColumnMostCommon(index);
                report = report.GetWithBitSetInIndex(index, mc);

                if (report.Rows.Count == 1)
                {
                    break;
                }
            }

            return new BinStr(report[0]);
        }

        private static BinStr GetCoRating(DiagReport diagReport)
        {
            var report = diagReport;
            for (var index = 0; index < report.Columns.Count; index++)
            {
                var r = report.Columns[index];
                int lc = report.GetColumnMostCommon(index) == 1 ? 0 : 1;
                report = report.GetWithBitSetInIndex(index, lc);
                if (report.Rows.Count == 1)
                {
                    break;
                }
            }

            return new BinStr(report[0]);
        }

    }
}