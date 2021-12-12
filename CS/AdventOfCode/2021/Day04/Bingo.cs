using System;
using System.Collections.Generic;
using System.IO;

namespace Day04
{
    public class Bingo
    {
        public List<int> CalledNumbers { get; set; }
        public List<BingoBoard> BingoBoards { get; set; }

        public Bingo(string filename)
        {
            StreamReader sr = new(filename);

            CalledNumbers = new();
            BingoBoards = new();
            
                
            string calledNums = sr.ReadLine() ?? String.Empty;
            foreach (string s in calledNums.Split(','))
            {
                CalledNumbers.Add(Int32.Parse(s));
            }

            int boardCount = 0;
            Console.WriteLine("Read Called Numbers");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                BingoBoard bingoBoard = new(boardCount);
                ++boardCount;
                for (int i = 0; i < 5; ++i)
                {
                    List<BingoNumber> boardLine = new();
                    //Console.WriteLine("Reading Board Line {0} of board {1}", i, boardCount);
                    var temp = sr.ReadLine();
                    foreach (string s in temp.Split(new [] { ' '}, StringSplitOptions.RemoveEmptyEntries))
                    {
                        boardLine.Add( new(Int32.Parse(s)));
                    }
                    bingoBoard.Board.Add(boardLine);
                }
                
                sr.ReadLine();
                BingoBoards.Add(bingoBoard);
            }
            
            
        }
    }
}