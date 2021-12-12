using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;


namespace Day04 
{

    class Program
    {
        static void Main(string[] args)
        {
            var bingo = GetInput();
            Part1(bingo);
            Part2(bingo);
        }

        private static void Part2(Bingo bingo)
        {
            Part1(bingo, true);
        }

        private static void Part1(Bingo bingo, bool getLast = false)
        {
            int? winningBoard = null;
            int? winningNumber = null;
            
            foreach (var i in bingo.CalledNumbers)
            {
                //go through the boards that haven't won yet
                foreach (BingoBoard board in bingo.BingoBoards.Where(o => !o.isWinner()))
                {
                    foreach (var line in board.Board)
                    {
                        foreach (var val in line)
                        {
                            if (val == i)
                            {
                                val.Called = true;
                            }
                        }
                    }
                
                    if (board.isWinner())
                    {
                        winningBoard = board.BoardNumber;
                        winningNumber = i;
                    }
                }
                //if we want the last one dont abort
                //loop will automatically stop when all boards have won
                if (!getLast)
                {
                    if (winningBoard != null && winningNumber != null)
                    {
                        break;
                    }
                }
            }
            
            Console.WriteLine(winningBoard);
            Console.WriteLine(winningNumber);
            Console.WriteLine("winning sum is {0} and winning number is {1}",bingo.BingoBoards[(int)winningBoard].GetUncalledNumberSum(), (int)winningNumber );
            Console.WriteLine(bingo.BingoBoards[(int)winningBoard].GetUncalledNumberSum() * (int)winningNumber);
            
            
        }

        private static Bingo GetInput()
        {
            return new("./Input.txt");
        }
    }
}