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
            Console.WindowHeight = 60;
            var GameBoard = new GameBoard(new Player("karl", ConsoleColor.Blue), new Player("Erik", ConsoleColor.Red));
        }
    }
}
