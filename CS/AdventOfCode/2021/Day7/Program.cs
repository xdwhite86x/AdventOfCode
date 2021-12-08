using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("./input7.txt");
            List<short> crabs = new();
            
            foreach (var s in input.Split(','))
            {
                crabs.Add(short.Parse(s));    
            }

            Console.WriteLine(crabs.Count);
            int newPos = 0;
            int leastFuel = int.MaxValue;
            for (short i = 0; i < crabs.Max(); ++i)
            {
                int totalFuel = 0;
                foreach (var s in crabs)
                {
                    totalFuel += CalculateFuelUsage(i, s);
                }

                if (totalFuel < leastFuel)
                {
                    leastFuel = totalFuel;
                    newPos = i;
                }
            }

            Console.WriteLine("New Position is {0} using {1} Fuel", newPos, leastFuel);
        }

        private static int CalculateFuelUsage(short dest, short start)
        {
            int fuelCost = 1;
            int totalCost = 0;
            for (int i = Math.Min(dest, start); i < Math.Max(dest, start); ++i)
            {
                totalCost += fuelCost;
                ++fuelCost;
            }

            return totalCost;
        }
    }
}