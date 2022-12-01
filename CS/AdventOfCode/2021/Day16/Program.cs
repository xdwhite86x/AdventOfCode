using System;
using System.IO;

namespace Day16
{
    class Program
    {
        static void Main(string[] args)
        {
            var        input  = ReadInput();
            BitsPacket packet = new BitsPacket(input);
            
        }

        private static string ReadInput()
        {
            return File.ReadAllText("./input.txt");
        }
    }
}
