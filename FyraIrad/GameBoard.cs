using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FyraIrad
{
    class GameBoard
    {
        static Dictionary<int, int> AvaiablePositions = new Dictionary<int, int>();
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
            AvaiablePositions = new Dictionary<int, int>();
            Console.Clear();
            DrawGrid();
            DrawScoreBoard();

            for (var i = 1; i <= width; i++)
            {

                for (var q = 1; q <= heigth; q++)
                {
                    AvaiablePositions.Add(Convert.ToInt32(string.Format("{0}{1}", i, q)), 0);

                }




            }




            var WhosTurn = rnd.Next(0, 2);
            while (GameOver == false)
            {
                var whereToPutCoin = MoveCursor();

                if (GameOver == true)
                {
                    break;
                }

                while (MakeMove(FirstPlayer, whereToPutCoin) == false)
                {
                    whereToPutCoin = MoveCursor();

                }


                if (GameOver == true)
                {
                    break;
                }
                whereToPutCoin = MoveCursor();
                while (MakeMove(SecondPlayer, whereToPutCoin) == false)
                {
                    whereToPutCoin = MoveCursor();


                }

            }
            Console.Clear();
            DrawScoreBoard();
            
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(1, 30);
            Console.WriteLine("Game over!");
            Console.Read();





        }
        private void DrawScoreBoard(){

            Console.SetCursorPosition(70, 2);
            Console.WriteLine("{0}:{1}\r\n", FirstPlayer.Name, FirstPlayer.TotalWins);
            Console.SetCursorPosition(70, 4);
            Console.WriteLine("{0}:{1}\r\n", SecondPlayer.Name, SecondPlayer.TotalWins);
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
                        DrawCursor(y, true);
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
        private void ShowData()
        {
            Console.Clear();
            foreach (var item in AvaiablePositions)
            {
                Console.WriteLine("{0} : {1}", item.Key, item.Value);

            }

        }
        private void DrawBlock(ConsoleColor Color, int x, int y)
        {
            var ypos = (heigth * heigth + 1) - (y * 5);
            var xpos = (width * x + 1);
            for (int q = ypos; q < ypos + 4; q++)
            {
                for (int i = xpos; i < xpos + 6; i++)
                {
                    Console.SetCursorPosition(i, q);
                    Console.BackgroundColor = Color;
                    Console.ForegroundColor = Color;
                    Console.Write("x");
                }
                Console.WriteLine("\r");
            }






        }
        private bool MakeMove(Player player, int Location)
        {

            for (var i = 1; i < 7; i++)
            {
                var number = Convert.ToInt32(string.Format("{0}{1}", Location, i));
                Console.SetCursorPosition(0, 0);

                if (AvaiablePositions[number] == 0)
                {
                    AvaiablePositions[number] = player.Id;
                    DrawBlock(player.Color, Location, i);
                    var Winning = CheckForWinningMove(player.Id, number);

                    if (Winning == true)
                    {
                        GameOver = true;
                        player.TotalWins += 1;



                    }

                    return true;

                }
            }
            return false;

        }
        public bool CheckForWinningMove(int Id, int Number)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            var TempNumber = Number;

            while (AvaiablePositions.ContainsKey(TempNumber))
            {
                TempNumber++;
            }
            TempNumber -= 1;

            var Victory = FinderLoop(TempNumber, Id, 1, false);
            if (Victory == true)
            {
                return true;
            }




            TempNumber = Number;

            while (AvaiablePositions.ContainsKey(TempNumber))
            {
                TempNumber += 10;
            }
            TempNumber -= 10;

            Victory = FinderLoop(TempNumber, Id, 10, false);
            if (Victory == true)
            {
                return true;
            }

            TempNumber = 16;

            while (TempNumber >= 11)
            {
                Victory = FinderLoop(TempNumber, Id, 11, true);

                if (Victory == true)
                {
                    return true;
                }
                TempNumber -= 1;
            }
            TempNumber = 11;


            while (TempNumber <= 71)
            {
                Victory = FinderLoop(TempNumber, Id,11, true);

                if (Victory == true)
                {
                    return true;
                }
                TempNumber += 10;
            }
            
            TempNumber = 76;


            while (TempNumber >= 71)
            {
                Victory = FinderLoop(TempNumber, Id, 9, false);

                if (Victory == true)
                {
                    return true;
                }
                TempNumber -= 1;
            }
           
            TempNumber = 61;
            
            while (TempNumber >= 11)
            {
                Victory = FinderLoop(TempNumber, Id, 9, false);

                if (Victory == true)
                {
                    return true;
                }
                TempNumber -= 10;
            }


            return false;
        }

  
        

        

        public bool FinderLoop(int value, int Id, int ActionValue, bool Action)
        {

            var Counter = 0;
            while (AvaiablePositions.ContainsKey(value))
            {
                
                if (AvaiablePositions[value] == Id)
                {
                    
                    
                    if (Counter == 3)
                    {
                        return true;

                    }
                    Counter++;
                }
                else
                {

                    Counter = 0;
                }
                if (Action == true)
                {

                    value += ActionValue;
                }
                else
                {
                    value -= ActionValue;
                }
            }
            return false;

        }
    }
}
