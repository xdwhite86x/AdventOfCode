using System.Collections.Generic;

namespace Day14
{
    public class Input
    {
        public string startString { get; set; }
        public List<InputMap> Map { get; set; } = new();

    }

    public class InputMap
    {
        public string Pair { get; set; }
        public char Map { get; set; }
    }
}