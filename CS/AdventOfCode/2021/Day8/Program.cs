using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;

namespace Day8
{

    class Input
    {
        public List<string> ControlSignals;
        public List<string> OutputSignals;
        public List<int> OutputValues;
        public int output;
        public Input()
        {
            ControlSignals = new();
            OutputSignals = new();
            OutputValues = new();
            output = 0;
        }
    }
    class Program
    {
        private const int one = 2;
        private const int four = 4;
        private const int seven = 3;
        private const int eight = 7;

        static void Main(string[] args)
        {
            List<Input> inputs = new();
            using StreamReader sr = new("./input-test.txt");

            while (!(sr.EndOfStream))
            {
                var temp = sr.ReadLine().Split('|');
                Input input = new();
                input.ControlSignals = temp[0].Split(' ').ToList();
                input.OutputSignals = temp[1].Split(' ').ToList();
                inputs.Add(input);
            }

            Console.WriteLine(inputs.Count);
            int count = 0;
            foreach (var f in inputs)
            {
                for (var i = 0; i < f.OutputSignals.Count; i++)
                {
                    switch (f.OutputSignals[i])
                    {
                        default:
                            Console.WriteLine("UNREACHABLE");
                            break;
                    }
                }
            }

            foreach (var f in inputs)
            {
                for (var i = 1; i <= f.OutputValues.Count; i++)
                {
                    f.output += f.OutputValues[i] * (int)Math.Pow(10, i);
                }

                Console.WriteLine(f.output);
            }

            Console.WriteLine(count);
        }
    }
}