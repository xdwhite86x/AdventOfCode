//#define TEST
#if TEST
#define VERBOSE
#endif


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using AdventOfCode.Day3;
using AdventOfCode.Day4;
using AdventOfCode.Day5;
using Microsoft.VisualBasic.FileIO;




namespace AdventOfCode
{
    class Program
    {
        
        #if TEST
        private const string file = "./Day5/inputDay5-test.txt";
        private const int gridSize = 10;
        #else
        private const string file = "./Day5/inputDay5.txt";
        private const int gridSize = 1000;
        #endif
        private static Bingo bingo;
        private static List<HydroThermalLine> pointsList = new();
        public static int[,] grid = new int[gridSize, gridSize];
        static void Main(string[] args)
        {

        }

        private static void day6_part1()
        {
            
        }

        private static void day5_part1()
        {
            for (int i = 0; i < gridSize; ++i)
            {
                for (int j = 0; j < gridSize; ++j)
                {
                    grid[i, j] = 0;
                }
            }
            ParseLineDataFile();
            foreach (var line in pointsList)
            {
                //Console.WriteLine(line.Angle);
                
                
                if (line.isHorizontalOrVertical)
                {
                    if (line.Start.Y == line.End.Y) //horizontal line start is left of end
                    {
                        for (int i = Math.Min(line.Start.X, line.End.X); i <= Math.Max(line.Start.X, line.End.X); ++i)
                        {
                            grid[i, line.End.Y]++;
                        }
                    }
                    if (line.Start.X == line.End.X)// vertical line start is above end
                    {
                        for (int i = Math.Min(line.Start.Y, line.End.Y); i <= Math.Max(line.Start.Y, line.End.Y); ++i)
                        {
                            grid[line.End.X, i]++;
                        }
                    }
                }
                else //line is diagonal
                {
                    if (Math.Abs(line.DeltaX) == Math.Abs(line.DeltaY))
                    {
                        Console.WriteLine("Diagonal Line Coordinates = {0}", line.ToString());
                        Console.WriteLine("Diagonal Line angle= {0}", line.Angle);
                        Console.WriteLine("diagonal line length = {0}", line.GetLineLength());
                        int x = 0, y = 0;
                        
                        switch (line.Angle)
                        {
                            case 45:
                                for (int i = 0; i <= Math.Abs(line.DeltaX); ++i)
                                {
                                    x = line.Start.X + i;
                                    y = line.Start.Y + i;
                                    grid[x, y]++;
                                }
                                break;
                            case 135:
                                for (int i = 0; i <= Math.Abs(line.DeltaX); ++i)
                                {
                                    x = line.Start.X - i;
                                    y = line.Start.Y + i;
                                    grid[x, y]++;
                                }
                                break;
                            case -45:
                                for (int i = 0; i <= Math.Abs(line.DeltaX); ++i)
                                {
                                    x = line.Start.X + i;
                                    y = line.Start.Y - i;
                                    grid[x, y]++;
                                }
                                break;
                            case -135:
                                for (int i = 0; i <= Math.Abs(line.DeltaX); ++i)
                                {
                                    x = line.Start.X - i;
                                    y = line.Start.Y - i;
                                    grid[x, y]++;
                                }
                                break;

                        }
                    }
                }
            }
            
            
            var multiPoints = 0;
            for (int i = 0; i < gridSize; ++i)
            {
                for (int j = 0; j < gridSize; ++j)
                {
                    if (grid[i, j] > 1)
                        ++multiPoints;
                    #if VERBOSE
                    Console.Write("{0:D1}",grid[i,j]);
                    #endif
                }
                #if VERBOSE
                Console.WriteLine();
                #endif
            }

            Console.WriteLine(multiPoints);
        }
        private static void ParseLineDataFile()
        {
            using StreamReader sr = new(file);
            while (!(sr.EndOfStream))
            {
                var hl = new HydroThermalLine(sr.ReadLine());
                pointsList.Add(hl);
                Console.WriteLine(hl.ToString());
                Console.WriteLine(hl.Angle);
            }
          
        }

        private static void day4_part1()
        {
            ParseBingoFile();
            int? winningBoard = null;
            int? winningNumber = null;
            foreach (var num in bingo.CalledNumbers)
            {
                Console.WriteLine("Checking Number {0}", num);
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

                    if (board.isWinner())
                    {
                        winningBoard = board.BoardNumber;
                        winningNumber = num;
                    }
                }
                
                if (!(winningBoard is null))
                {
                    
                    break;
                }
                
                
            }

            foreach (var board in bingo.BingoBoards)
            {
                if (board.isWinner())
                {
                    var temp = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("WINNER");
                    Console.ForegroundColor = temp;

                    foreach (var line in board.Board)
                    {
                        foreach (var val in line)
                        {
                            var color = Console.ForegroundColor;
                            if (val.Called)
                            {

                                Console.ForegroundColor = ConsoleColor.Red;
                            }

                            Console.Write(" {0:D2} ", val.Value);
                            Console.ForegroundColor = color;
                        }

                        Console.WriteLine();
                    }

                    Console.WriteLine();
                }
            }
            Console.WriteLine(winningBoard);
            Console.WriteLine(winningNumber);
            Console.WriteLine("winning sum is {0} and winning number is {1}",bingo.BingoBoards[(int)winningBoard].GetUncalledNumberSum(), (int)winningNumber );
            Console.WriteLine(bingo.BingoBoards[(int)winningBoard].GetUncalledNumberSum() * (int)winningNumber);
            
        }
        
        private static void day4_part2()
        {
            ParseBingoFile();
            int? winningBoard = null;
            int? winningNumber = null;
            foreach (var num in bingo.CalledNumbers)
            {
                Console.WriteLine("Checking Number {0}", num);
                foreach (var board in bingo.BingoBoards.Where(o => !o.isWinner()))
                {
                    foreach(var line in board.Board)
                    {
                        foreach (var val in line)
                        {
                            if (val.Value == num)
                                val.Called = true;
                        }
                    }

                    if (board.isWinner())
                    {
                        winningBoard = board.BoardNumber;
                        winningNumber = num;
                    }
                }
                
                // if (!(winningBoard is null))
                // {
                //     
                //     break;
                // }
                
                
            }

            foreach (var board in bingo.BingoBoards)
            {
                if (board.isWinner())
                {
                    var temp = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("WINNER");
                    Console.ForegroundColor = temp;

                    foreach (var line in board.Board)
                    {
                        foreach (var val in line)
                        {
                            var color = Console.ForegroundColor;
                            if (val.Called)
                            {

                                Console.ForegroundColor = ConsoleColor.Red;
                            }

                            Console.Write(" {0:D2} ", val.Value);
                            Console.ForegroundColor = color;
                        }

                        Console.WriteLine();
                    }

                    Console.WriteLine();
                }
            }
            Console.WriteLine(winningBoard);
            Console.WriteLine(winningNumber);
            Console.WriteLine("winning sum is {0} and winning number is {1}",bingo.BingoBoards[(int)winningBoard].GetUncalledNumberSum(), (int)winningNumber );
            Console.WriteLine(bingo.BingoBoards[(int)winningBoard].GetUncalledNumberSum() * (int)winningNumber);
            
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
