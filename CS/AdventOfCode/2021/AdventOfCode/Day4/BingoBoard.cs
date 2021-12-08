using System.Collections.Generic;

namespace AdventOfCode.Day4
{
    public class BingoBoard
    { 
        public List<List<BingoNumber>> Board { get; set; }
        public int BoardNumber { get; private set; }
        public BingoBoard( int boardNumber)
       {
           Board = new();
           BoardNumber = boardNumber;
       }

       public bool isWinner()
       {
           return (Board[0][0].Called && Board[0][1].Called && Board[0][2].Called && Board[0][3].Called && Board[0][4].Called ||
                   Board[1][0].Called && Board[1][1].Called && Board[1][2].Called && Board[1][3].Called && Board[1][4].Called ||
                   Board[2][0].Called && Board[2][1].Called && Board[2][2].Called && Board[2][3].Called && Board[2][4].Called ||
                   Board[3][0].Called && Board[3][1].Called && Board[3][2].Called && Board[3][3].Called && Board[3][4].Called ||
                   Board[4][0].Called && Board[4][1].Called && Board[4][2].Called && Board[4][3].Called && Board[4][4].Called ||
                   Board[0][0].Called && Board[1][0].Called && Board[2][0].Called && Board[3][0].Called && Board[4][0].Called ||
                   Board[0][1].Called && Board[1][1].Called && Board[2][1].Called && Board[3][1].Called && Board[4][1].Called ||
                   Board[0][2].Called && Board[1][2].Called && Board[2][2].Called && Board[3][2].Called && Board[4][2].Called ||
                   Board[0][3].Called && Board[1][3].Called && Board[2][3].Called && Board[3][3].Called && Board[4][3].Called ||
                   Board[0][4].Called && Board[1][4].Called && Board[2][4].Called && Board[3][4].Called && Board[4][4].Called);
       }

       public int GetUncalledNumberSum()
       {
           var sum = 0;
           foreach (var line in Board)
           {
               foreach (var val in line)
               {
                   if (!(val.Called))
                       sum += val.Value;

               }
           }

           return sum;
       }
       
       
       
    }
}