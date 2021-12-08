using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day2
{
    struct passwd
    {
        public char requiredChar;
        public int p1;
        public int p2;
        public string password;

        public override string ToString()
        {
            return $"{p1}-{p2} {requiredChar}: {password}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Day2_part1();
        }

        
        static void Day2_part1()
        {
            using StreamReader sr = new("./input.txt");
            List<passwd> list = new(); 
            while (!(sr.EndOfStream))
            {
                var temp = sr.ReadLine().Split(' ');
                var temp2 = temp[0].Split('-');
                passwd password = new passwd()
                {
                    p1 = int.Parse(temp2[0]) - 1, 
                    p2 = int.Parse(temp2[1]) - 1,
                    requiredChar = temp[1].ToCharArray()[0],
                    password = temp[2],
                    
                };
                list.Add(password);
            }

            List<passwd> valid = new ();
            foreach (var pas in list)
            {
                if ((pas.password[pas.p1] == pas.requiredChar ||
                    pas.password[pas.p2] == pas.requiredChar) &&
                    pas.password[pas.p1] != pas.password[pas.p2])
                {
                    valid.Add(pas);
                }
            }

            foreach (var f in valid)
            {
                Console.WriteLine(f);
            }
            
            Console.WriteLine(valid.Count);
            
        }
        
    }
}