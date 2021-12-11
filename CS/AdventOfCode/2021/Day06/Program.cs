using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<byte> lfish = new();
            UInt64[] lf = new UInt64[]{0,0,0,0,0,0,0,0,0}; 
            using StreamReader sr = new("input6.txt");
            foreach (var l in sr.ReadLine().Split(','))
            {
                lfish.Add(byte.Parse(l));
            }

            foreach (var l in lfish)
            {
                lf[l]++;
            }

            foreach (var kp in lf)
            {
                Console.WriteLine("{0:N}", kp);
            }
            for (int i = 0; i < 256; ++i)
            {
                var num0 = lf[0];
                lf[0] = lf[1];
                lf[1] = lf[2];
                lf[2] = lf[3];
                lf[3] = lf[4];
                lf[4] = lf[5];
                lf[5] = lf[6];
                lf[6] = lf[7];
                lf[7] = lf[8];
                lf[8] = num0;
                lf[6] += num0;

            }

            UInt64 total = 0;
            UInt64 last = 0;
            foreach (var kp in lf)
            {
                Console.WriteLine("{0:N}", kp);
                total += kp;
            }

            Console.WriteLine(total);


        }
        private static void Message(object msg)
        {
            #if VERBOSE
            Console.WriteLine(msg);
            #endif
            
        }
        private static void Message()
        {
#if VERBOSE
            Console.WriteLine(msg);
#endif
            
        }
        private static void MessagePart(string msg)
        {
#if VERBOSE
            Console.Write(msg);
#endif
            
        }
    }
    
    
}