using System;

namespace AdventOfCode.Day5
{
    public class Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return $"{X,3},{Y,3}";
        }

        public double GetDistanceTo(Coordinates pt2)
        {
            var deltaX = X - pt2.X;
            var deltaY = Y - pt2.Y;
            return Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
        }
    }
}