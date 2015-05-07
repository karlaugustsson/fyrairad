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

                Console.WindowHeight = 40;
                Player player1 = new Player("karl", ConsoleColor.Blue);
                Player player2 = new Player("Erik", ConsoleColor.Red);
                while (true)
	{
	    var GameBoard = new GameBoard(player1,player2);     
	}
                
            }
            
           
            
        }
    }
