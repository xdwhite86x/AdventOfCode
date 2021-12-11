using System;
using System.Collections.Generic;
using System.Text;

namespace Day11
{
    public static class ExtensionMethods
    {
        public static List<List<int>> ToSimpleList(this List<List<Octopus>> input)
        {
            
            List<List<int>> lines = new();
            foreach (var l in input)
            {
                List<int> line = new();
                foreach (var i in l)
                {
                    line.Add(i.Energy);
                }
                lines.Add(line);
            }

            return lines;
        }

        public static string ToSimpleString(this List<List<Octopus>> input)
        {
            StringBuilder sb = new();
            foreach (var l in input)
            {
                foreach (var i in l)
                {
                    sb.Append(i.Energy);
                }
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
