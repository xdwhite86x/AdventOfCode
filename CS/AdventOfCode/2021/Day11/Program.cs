
//#define TEST
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace Day11
{
    class Program
    {
        private static List<List<Octopus>> octopusGrid = new();
        private static int flashCounter = 0;
        private static int TotalOctopuses;
        static Program()
        {
            using StreamReader sr = new("./input.txt");
            int x = 0, y = 0, count = 0;
            while (!(sr.EndOfStream))
            {
                List<Octopus> line = new();
                x = 0;
                var temp = sr.ReadLine();
                foreach (char c in temp)
                {
                    line.Add(new((c - 48), y, x));
                    ++x;
                    ++count;
                }

                ++y;
                octopusGrid.Add(line);
            }

            TotalOctopuses = count;

        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("After step 0");
            //Queue<Tuple<int, int>> flashers = new();
            PrintGrid();
            int lastFlashCounter = 0;
            int j = 0;
            bool synchronized = false;
            while (!synchronized)
            {
                //check for flashers
                if (j != 0)
                {
                    while (HasNines())
                    {
                        for (int line = 0; line < octopusGrid.Count; ++line)
                        {
                            for (int index = 0; index < octopusGrid[line].Count; ++index)
                            {
                                if (octopusGrid[line][index].Energy >= 9 && !octopusGrid[line][index].Flashed )
                                {
                                    Flash(octopusGrid[line][index]);
                                }
                            }
                        }
                    }
                }
                IncrementEnergy();


                if (j < 10 || (j + 1) % 10 == 0)
                {
                    Console.WriteLine("After Step {0}", j + 1 );
                    PrintGrid();
                }
                if (flashCounter - lastFlashCounter >= TotalOctopuses)
                {
                    var temp = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SYNCHRONIZED on step {0}", j + 1);
                    Console.ForegroundColor = temp;
                    synchronized = true;
                }

                lastFlashCounter = flashCounter;
                ++j;
                

            }
            

            Console.WriteLine(flashCounter);

        }

        private static void IncrementEnergy()
        {
            //increment the octopuses
            for (var line = 0; line < octopusGrid.Count; line++)
            {
                for (var index = 0; index < octopusGrid[line].Count; index++)
                {
                    if (!octopusGrid[line][index].Flashed)
                        octopusGrid[line][index].Energy++;
                    
                    octopusGrid[line][index].Flashed = false;
                    
                }
            }
        }

        private static bool HasNines()
        {
            foreach (var l in octopusGrid)
            {
                foreach (var i in l)
                {
                    if (i.Energy >= 9 && !i.Flashed)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static void Flash(Octopus octopus)
        {
            octopus.Flashed = true;
            
            var adjacent = GetAdjacent(octopus);
            foreach (var a in adjacent)
            {
                if (!a.Flashed)
                {
                    a.Energy++;
                }
                
            }

            foreach (var oct in adjacent.Where(o => o.Energy >= 9 && !o.Flashed))
            {
                Flash(oct);
            }
            octopus.Energy = 0;
            ++flashCounter;
        }

        private static List<Octopus> GetAdjacent(Octopus octopus)
        {
            List<Octopus> adjacent = new();
            int x = octopus.Index;
            int y = octopus.Line;
            if (x > 0)
            {
                adjacent.Add(octopusGrid[y][x - 1]);
            }

            if (y > 0)
            {
                adjacent.Add(octopusGrid[y - 1][x]);
            }

            if (x > 0 && y > 0)
            {
                adjacent.Add(octopusGrid[y - 1][x - 1]);
            }

            if (x < octopusGrid[y].Count - 1 && y > 0)
            {
                adjacent.Add(octopusGrid[y - 1][x + 1]);
            }
            
            if (y < octopusGrid.Count - 1 && x > 0)
            {
                adjacent.Add(octopusGrid[y + 1][x - 1]);
            }

            if (x < octopusGrid[y].Count - 1 && y < octopusGrid.Count - 1)
            {
                adjacent.Add(octopusGrid[y + 1][x + 1]);
            }

            if (x < octopusGrid[y].Count - 1)
            {
                adjacent.Add(octopusGrid[y][x + 1]);
            }

            if (y < octopusGrid.Count - 1)
            {
                adjacent.Add(octopusGrid[y + 1][x]);
            }
            
            return adjacent;
        }
        private static void Flash(int line, int index)
        {
            int x = index;
            int y = line;

            if (x > 0)
            {
                
                octopusGrid[y][x - 1].Energy++;
                var a = octopusGrid[y][x - 1];
                
            }

            if (y > 0)
            {
                octopusGrid[y - 1][x].Energy++;
            }

            if (x > 0 && y > 0)
            {
                octopusGrid[y - 1][x - 1].Energy++;
            }

            if (x < octopusGrid[y].Count - 1 && y > 0)
            {
                octopusGrid[y - 1][x + 1].Energy++;
            }
            
            if (y < octopusGrid.Count - 1 && x > 0)
            {
                octopusGrid[y + 1][x - 1].Energy++;
            }

            if (x < octopusGrid[y].Count - 1 && y < octopusGrid.Count - 1)
            {
                octopusGrid[y + 1][x + 1].Energy++;
            }

            if (x < octopusGrid[y].Count - 1)
            {
                octopusGrid[y][x + 1].Energy++;
            }

            if (y < octopusGrid.Count - 1)
            {
                octopusGrid[y + 1][x].Energy++;
            }

            octopusGrid[y][x].Energy = 0;
            octopusGrid[y][x].Flashed = true;
            
            
            ++flashCounter;
        }

        public static void PrintGrid()
        {

            Console.WriteLine("--------------------------------------------------------------");

            if (octopusGrid.Count > 0)
            {
                int gridHeight = octopusGrid.Count;
                
                for (var i = 0; i < gridHeight; i++)
                {
                    int gridWidth = octopusGrid[i].Count;
                    for (var j = 0; j < gridWidth; j++)
                    {
                        if (j != 0)
                            Console.Write(",");
                        Console.Write(octopusGrid[i][j].Energy);
                        
                    }

                    Console.WriteLine();
                }
            }
            Console.WriteLine("--------------------------------------------------------------");

        }
    }
}