using System.Collections.Generic;
using System.Linq;

namespace Day04
{
    public class BingoBoard
    { 
        public List<List<BingoNumber>> Board { get; set; }
     
        public List<List<BingoNumber>> Columns
        {
            
            get
            {
                List<List<BingoNumber>> retval = new();
                for (int c = 0; c < Board[0].Count; ++c)
                {
                    List<BingoNumber> col = new();
                    for (int r = 0; r < Board.Count; ++r)
                    {
                        col.Add(Board[r][c]);
                    }
                    retval.Add(col);
                }
                return retval;
            }
        }
        public int BoardNumber { get; private set; }
        public BingoBoard( int boardNumber)
       {
           Board = new();
           BoardNumber = boardNumber;
       }

       public bool isWinner()
       {
           foreach (var row in Board)
           {
               int count = 0;
               for (int y = 0; y < Board[0].Count; ++y)
               {
                   if (row[y].Called)
                       ++count;
               }
               if (count == Board.Count) 
                   return true;
           }

           foreach (var col in this.Columns)
           {
               int count = 0;
               
               for (int row = 0; row < col.Count; ++row)
               {
                   if (col[row].Called)
                       ++count;
               }
               if (count == Board.Count) 
                   return true;
           }


           return false;
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