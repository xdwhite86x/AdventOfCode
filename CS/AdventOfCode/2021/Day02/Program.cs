using System;
using System.Collections.Generic;
using System.IO;

namespace Day02
{
    internal record Instruction(Directions Direction, int Magnitude);

    internal enum Directions
    {
        Up,
        Down,
        Forward,
        Invalid,
    }
    class Program
    {
        static void Main(string[] args)
        {
            var list = ReadInputFile();
            Part1(list);
            Part2(list);
        }

        private static void Part2(List<Instruction> list)
        {
            int xPos = 0;
            int yPos = 0;
            int aim = 0;

            
            // down   X increases your aim by X units.
            //   up   X decreases your aim by X units.
            //forward X does two things:
            //          It increases your horizontal position by X units.
            //          It increases your depth by your aim multiplied by X.

            foreach (Instruction i in list)
            {
                switch (i.Direction)
                {
                    case Directions.Down:
                        aim += i.Magnitude;
                        break;
                    case Directions.Up:
                        aim -= i.Magnitude;
                        break;
                    case Directions.Forward:
                        xPos += i.Magnitude;
                        yPos += i.Magnitude * aim;
                        break;
                }
            }

            Console.WriteLine("X:{0}, Y:{1} == {2}", xPos, yPos, xPos * yPos);
        }

        private static void Part1(List<Instruction> list)
        {
            int xPos = 0;
            int yPos = 0;

            foreach (Instruction i in list)
            {
                switch (i.Direction)
                {
                    case Directions.Forward:
                        xPos += i.Magnitude;
                        break;
                    case Directions.Down:
                        yPos += i.Magnitude;
                        break;
                    case Directions.Up:
                        yPos -= i.Magnitude;
                        break;
                }
            }

            Console.WriteLine("X:{0}, Y:{1} == {2}", xPos, yPos, xPos * yPos);
        }

        private static List<Instruction> ReadInputFile()
        {
            List<Instruction> instructions = new();
            using StreamReader sr = new("./Input.txt");
            while (!(sr.EndOfStream))
            {
                var temp = sr.ReadLine().Split(" ");
                if (temp is not null && temp.Length > 1)
                {
                    int magnitude = 0;
                    int.TryParse(temp[1], out magnitude);
                    
                    Directions d = Directions.Invalid;
                    switch (temp[0])
                    {
                        case "forward":
                            d = Directions.Forward;
                            break;
                        case "down":
                            d = Directions.Down;
                            break;
                        case "up":
                            d = Directions.Up;
                            break;
                    }
                    instructions.Add(new(d,magnitude));
                }
            }

            return instructions;
        }
    }


}
