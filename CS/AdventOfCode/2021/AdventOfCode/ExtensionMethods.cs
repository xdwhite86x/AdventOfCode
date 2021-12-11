using System.Collections.Generic;
using AdventOfCode.Day3;

namespace AdventOfCode
{
    public static class ExtensionMethods
    {
        public static List<Day3Input> CreateSublistFromIndexes(this List<Day3Input> input, List<int> indexes)
        {
            var retval = new List<Day3Input>();
            foreach (int index in indexes)
            {
                retval.Add(input[index]);
            }

            return retval;
        }
        
        
    }
}