using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Day14
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = GetInput();
            string currentPair;
            string currentString = input.startString;
            StringBuilder newString = new();
            for (int j = 0; j < 40; ++j)
            {
                if (j != 0)
                {
                    currentString = newString.ToString();
                    newString = new StringBuilder();
                }

                for (int i = 0; i < currentString.Length - 1; ++i)
                {
                    newString.Append(currentString[i]);
                    currentPair = $"{currentString[i]}{currentString[i + 1]}";
                    char insertChar = '\0';
                    foreach (var a in input.Map)
                    {
                        if (currentPair.Equals(a.Pair))
                        {
                            insertChar = a.Map;
                            break;
                        }
                    }

                    if (insertChar != '\0')
                    {
                        newString.Append(insertChar);
                    }
                }
                
                newString.Append(currentString[^1]);
                //Console.WriteLine(newString.ToString());
                Console.WriteLine("Step #{0}, string Length = {1}", j, newString.Length);

            }

            string finalString = newString.ToString();

            var minMax = GetMostAndLeastCommon(finalString);
            Console.WriteLine("MAX: ");
            Console.WriteLine("{0} occurred {1} Times", minMax.Item1.Item1, minMax.Item1.Item2);
            Console.WriteLine("MIN: ");
            Console.WriteLine("{0} occurred {1} Times", minMax.Item2.Item1, minMax.Item2.Item2);

            Console.WriteLine("Answer is {0}", minMax.Item1.Item2 - minMax.Item2.Item2);
        }

        private static Tuple<Tuple<char, int>, Tuple<char, int>> GetMostAndLeastCommon(string finalString)
        {
            var minMax = finalString.GroupBy(o => o)
                .Select(g => new {Value = g.Key, Count = g.Count()})
                .OrderByDescending(o => o.Count).ToList();

            var max = minMax[0];
            var min = minMax[^1];


            Tuple<char, int> maxT = new Tuple<char, int>(max.Value, max.Count);
            Tuple<char, int> minT = new Tuple<char, int>(min.Value, min.Count);

            return new Tuple<Tuple<char, int>, Tuple<char, int>>(maxT, minT);
        }

        private static Input GetInput()
        {
            using StreamReader sr = new("./Input-test.txt");
            //var inputRaw = File.ReadAllLines("Input.txt");
            Input input = new();

            input.startString = sr.ReadLine();

            while (!sr.EndOfStream)
            {
                var temp = sr.ReadLine();
                if (!string.IsNullOrEmpty(temp) && !string.IsNullOrWhiteSpace(temp))
                {
                    var temp2 = temp.Split("->");
                    input.Map.Add(new InputMap()
                    {
                        Map = temp2[1].Trim().ToCharArray()[0],
                        Pair = temp2[0].Trim()
                    });
                }
            }
            return input;
        }
    }
}
