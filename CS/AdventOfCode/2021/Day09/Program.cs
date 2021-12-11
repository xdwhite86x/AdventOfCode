using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Day9
{
    class Program
    {
        static List<List<byte>> smokeMap = new();
        static void Main(string[] args)
        {
            
            List<List<Tuple<byte, byte>>> basins = new();

            using StreamReader sr = new("./input.txt");

            while (!(sr.EndOfStream))
            {
                var temp = sr.ReadLine();
                List<byte> line = new();
                foreach (var c in temp)
                {
                    line.Add((byte)((byte)c - 48));
                }
                smokeMap.Add(line);
                
            }

            int count = 0;
            for (int y = 0; y < smokeMap.Count; ++y)
            {
                for (int x = 0; x < smokeMap[y].Count; ++x)
                {
                    byte val = smokeMap[y][x];
                    byte north = 10;
                    byte south = 10;
                    byte east = 10;
                    byte west = 10;

                    if (x > 0)
                        west = smokeMap[y][x - 1];
                    if (y > 0)
                        north = smokeMap[y - 1][x];
                    if (x < smokeMap[y].Count - 1)
                        east = smokeMap[y][x + 1];
                    if (y < smokeMap.Count - 1)
                        south = smokeMap[y + 1][x];
                    if (val < north && val < south && val < west && val < east)
                    {
                        count += val + 1;
                        var temp = GetBasinFromLowPoint((byte)x, (byte)y);
                        basins.Add(temp);
                    }

                }
            }

            Console.WriteLine(count);
            var sortedList = basins.OrderByDescending(o => o.Count).ToList();
            Console.WriteLine(sortedList[0].Count * sortedList[1].Count * sortedList[2].Count );



        }
        /// <summary>
        /// implements a flood fill to find basin
        /// example implementation here https://en.wikipedia.org/wiki/Flood_fill
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static List<Tuple<byte, byte>> GetBasinFromLowPoint(byte x, byte y)
        {
            //nodes in the basin also used as a "visited" list
            List<Tuple<byte, byte>> basin = new();
            // Queue to hold nodes still needed to visit
            Queue<Tuple<byte, byte>> nodes = new();
            
            //add the low point as the starting node
            nodes.Enqueue(new(x,y));
            //while we still have nodes to visit
            while (nodes.Count > 0)
            {
                //dequeue next node
                var curr = nodes.Dequeue();
                //check if we have visited this node already;
                if (basin.Contains(curr))
                    continue;
                // if the current node is not a 9 (highest point) cannot be part of a basin
                if (smokeMap[curr.Item2][curr.Item1] != 9)
                {
                    //west is eligible? were not at the left edge and its not a 9
                    if (curr.Item1 > 0 && smokeMap[curr.Item2][curr.Item1 - 1] != 9)
                    {
                        nodes.Enqueue(new ((byte)(curr.Item1 - 1), curr.Item2));                    
                    }
                    //east is eligible? were not at the right edge and its not a 9
                    if (curr.Item1 < smokeMap[curr.Item2].Count - 1 && smokeMap[curr.Item2][curr.Item1 + 1] != 9)
                    {
                        nodes.Enqueue(new ((byte)(curr.Item1 + 1), curr.Item2));                    
                    }
                    //north is eligible? were not at the top edge and its not a 9
                    if (curr.Item2 > 0 && smokeMap[curr.Item2 - 1][curr.Item1] != 9)
                    {
                        nodes.Enqueue(new (curr.Item1, (byte)(curr.Item2 - 1)));                    
                    }
                    //south is eligible? were not at the south edge and its not a 9
                    if (curr.Item2 < smokeMap.Count - 1 && smokeMap[curr.Item2 + 1][curr.Item1] != 9)
                    {
                        nodes.Enqueue(new (curr.Item1, (byte)(curr.Item2 + 1)));                    
                    }
                    //add the node the visited list;
                    basin.Add(curr);
                }
            }
            //return the list of coordinates that make up the basin
            return basin;
        }
    }
}