using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day10
{
    class Program
    {
        private static List<string> input = new();
        private static Stack<char> charList = new();
        private static readonly char[] open = { '{', '[', '(', '<' };
        private static readonly char[] close = { '}', ']', ')', '>' };
        private static List<UInt64> incompleteScores = new();

        static void Main(string[] args)
        {
            using StreamReader sr = new("./input.txt");
            // using StreamReader sr = new("./input-test.txt");

            while (!(sr.EndOfStream))
            {
                input.Add(sr.ReadLine());
            }

            int score = 0;
            char badChar = '\0';
            foreach (string s in input)
            {
                bool corrupt = false;
                charList = new();
                foreach (char c in s)
                {
                    if (open.Contains(c))
                    {
                        charList.Push(GetClosingChar(c));
                    }else if (close.Contains(c))
                    {
                        if (charList.Peek() != c)
                        {
                            //we have a wrong closing
                            //sequence is corrupt
                            corrupt = true;
                            badChar = c;
                            break;
                            
                        }
                        _ = charList.Pop();
                        
                    }
                }

                if (corrupt)
                {
                    var val = GetCharacterScore(badChar);
                    Console.WriteLine(val);
                    score += val;
                }
                else
                {
                    UInt64 ACscore = 0;
                    while (charList.Count > 0)
                    {
                        ACscore *= 5;
                        ACscore += GetAutoCompleteScore(charList.Pop());
                    }
                    
                    incompleteScores.Add(ACscore);
                }
                
            }
            Console.WriteLine("Total: {0}", score);

            foreach (uint i in incompleteScores.OrderBy(o => o))
            {
                Console.WriteLine(i);
                
            }

            UInt64 median = 0U;
            if (incompleteScores.Count % 2 != 0)
            {
                median = incompleteScores.OrderBy(o => o).ToList()[incompleteScores.Count / 2];
            }

            Console.WriteLine("Median :{0}",median);






        }

        static int GetCharacterScore(char? badChar)
        {
            
            switch (badChar)
            {
                case '}':
                    return 1197;
                case ')':
                    return 3;
                case ']':
                    return 57;
                case '>':
                    return 25137;
                default:
                    return 0;
            }
        }
        static char GetOpeningChar(char input)
        {
            switch (input)
            {
                case '}':
                    return'{';
                case ')':
                    return'(';
                case ']':
                    return'[';
                case '>':
                    return'<';
                default:
                    return '\0';
            }
            
        }
        static char GetClosingChar(char input)
        {
            switch (input)
            {
                case '{':
                    return'}';
                case '(':
                    return')';
                case '[':
                    return']';
                case '<':
                    return'>';
                default:
                    return '\0';
            }
            
        }

        static string[] GetChunks(string input)
        {
            Queue<char> charQueue = new();
            List<string> tokens;
            int i = 0;
            for (i = 0; i < input.Length; i++)
            {
                char c = input[i];

                if (open.Contains(c)) //we have an opening character
                {
                    charQueue.Enqueue(GetClosingChar(c));
                }
                else if (close.Contains(c))
                {
                    var temp = charQueue.Dequeue();
                    if (temp != c)
                    {
                      
                        break;
                    }
                }
            }
            
            
            

            return null;

        }
        static uint GetAutoCompleteScore(char? badChar)
        {
            
            switch (badChar)
            {
                case '}':
                    return 3;
                case ')':
                    return 1;
                case ']':
                    return 2;
                case '>':
                    return 4;
                default:
                    return 0;
            }
        }
    }
}