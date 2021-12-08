using System;

namespace AdventOfCode.Day5
{
    public class HydroThermalLine
    {
        public Coordinates Start { get; set; }
        public Coordinates End { get; set; }

        public int DeltaX
        {
            get => End.X - Start.X;
        }
        public int DeltaY
        {
            get => End.Y - Start.Y;
        }

        public int Angle
        {
            get => GetLineAngle();
        }
        public bool isHorizontalOrVertical
        {
            get
            {
                var temp = Math.Abs(Angle);
                if (temp == 0 || temp == 90 || temp == 180)
                    return true;
                else
                    return false;

            }
        }
        public int GetLineAngle()
        {
            return (int)Math.Floor((Math.Atan2(DeltaY, DeltaX)) * 180 / Math.PI);
        }
        public HydroThermalLine(string fileLine)
        {
            var points = fileLine.Split("->");
            Coordinates start = new();
            Coordinates end = new();
            //int x1, x2, y1, y2;    
            start.X = int.Parse(points[0].Split(',')[0]);
            start.Y = int.Parse(points[0].Split(',')[1]);
            end.X = int.Parse(points[1].Split(',')[0]);
            end.Y = int.Parse(points[1].Split(',')[1]);

            // if (start.GetDistanceTo(end) < 0)
            // {
            //     Start = start;
            //     End = end;
            // }
            // else
            // {
            //     Start = end;
            //     End = start;
            // }
            Start = start;
            End = end;
        }
        public override string ToString()
        {
            return $"{Start.ToString()} -> {End.ToString()}";
        }

        public double GetLineLength()
        {
            return Start.GetDistanceTo(End);
        }

        public bool LeftToRight()
        {
            if (Start.X > End.X && Start.Y > End.Y)
                return true;
            else
                return false;
        }

        public Tuple<Coordinates, Coordinates> ScaleLine()
        {
            return null;
        }


    }
}