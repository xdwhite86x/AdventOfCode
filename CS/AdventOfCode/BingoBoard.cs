using System.Collections.Generic;

namespace AdventOfCode
{
    public class BingoBoard
    {
       public List<List<BingoNumber>> Board { get; set; }

       public BingoBoard()
       {
           Board = new();
       }
       
    }
}