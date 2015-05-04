using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FyraIrad
{
    class GameBoard
    {
        static Dictionary<int,int> AvaiablePositions = new Dictionary<int,int>();
        static int heigth = 6;
        static int width = 7;

        public Player FirstPlayer;
        public Player SecondPlayer;
        public static Random rnd = new Random();
        private bool GameOver = false;

        public GameBoard(Player player1, Player player2)
        {
            FirstPlayer = player1;
            SecondPlayer = player2;
            AvaiablePositions = new Dictionary<int,int>();
            DrawGrid();

            for (var i = 1; i <= width; i++)
            {

                for (var q = 1; q <= heigth; q++)
                {
                    AvaiablePositions.Add(Convert.ToInt32(string.Format("{0}{1}", i, q)),0);

                }




            }


            

            var WhosTurn = rnd.Next(0, 2);
            while (GameOver == false) {
                var whereToPutCoin = MoveCursor();
               
                if (GameOver == true)
                {
                    Console.WriteLine("aaa");
                    break;
                }
   
                    while (MakeMove(FirstPlayer, whereToPutCoin) == false)
                    {
                        whereToPutCoin = MoveCursor();
                        MakeMove(FirstPlayer, whereToPutCoin);
                    }
                    Console.WriteLine("Player1 done");
              
                if (GameOver == true)
                {
                    break;
                }
                    whereToPutCoin = MoveCursor();
                    while (MakeMove(SecondPlayer, whereToPutCoin) == false)
                    {
                        whereToPutCoin = MoveCursor();
                        MakeMove(SecondPlayer, whereToPutCoin);

                    }
                    Console.WriteLine("Player2 done");
                
               

                
            }


             
                
  

     

            


            
            



        }

        private void DrawGrid()
        {

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.White;
            for (var heightCounter = 0; heightCounter <= heigth * 5; heightCounter++)
            {
                for (var widthCounter = 0; widthCounter <= width * 7; widthCounter++)
                {
                    Console.SetCursorPosition(width + widthCounter, heigth + heightCounter);
                    if (widthCounter % 7 == 0 || heightCounter % 5 == 0)
                    {
                        Console.Write("x");
                    }
                    else
                    {
                        Console.Write("");
                    }

                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(Environment.NewLine);

        }
        private int MoveCursor()
        {

            DrawCursor(1);

            var y = 1;
            while (true)
            {

                switch (Console.ReadKey(true).Key)
                {

                    case ConsoleKey.RightArrow:
                        DrawCursor(y, true);
                        if (y >= 7)
                        {
                            y = 0;
                        }
                        DrawCursor(++y);

                        break;
                    case ConsoleKey.LeftArrow:
                        DrawCursor(y, true);
                        if (y <= 1)
                        {
                            y = 8;
                        }
                        DrawCursor(--y);
                        break;

                    case ConsoleKey.Enter:
                        return y;

                }

            }
        }

        private void DrawCursor(int where, bool erase = false)
        {
            if (erase == false)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            for (var i = 0; i <= 5; i++)
            {
                Console.SetCursorPosition((where * 7) + 1 + i, 1);
                Console.Write("x");

            }
            Console.BackgroundColor = ConsoleColor.Black;


        }
        private bool MakeMove(Player player, int Location)
        {
            
            for (var i = 1; i < 7; i++) {
               var number = Convert.ToInt32(string.Format("{0}{1}", Location, i));
               Console.SetCursorPosition(0, 0);
   
                if(AvaiablePositions[number] == 0){
                AvaiablePositions[number] = player.Id;
                var Winning = CheckForWinningMove(player.Id,number);
                if (Winning == true) {
                    GameOver = true;
                }
                return true;
            
            }
            }
            return false;
            
        }
        public bool CheckForWinningMove(int Id,int Number) {
                var Counter = 1;
                while (AvaiablePositions.ContainsKey(Number))
                {
                    if (Counter == 4)
                    {

                        return true;
                    }

                    if (AvaiablePositions[Number] == Id)
                    {
                        
                        Counter++;
                        Console.WriteLine(Counter);
                    }
    

                    Number = Number  - 1;
                }
                
                    return false;
            }
            
        }
    }