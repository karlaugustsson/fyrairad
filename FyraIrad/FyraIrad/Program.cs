using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FyraIrad
{
    class Program
    {
        static void Main(string[] args)
        {
            var GameBoard = new GameBoard(new Player("karl", "Blue"), new Player("Erik", "Blue"));
        }
    }
}
