namespace Slayer
{
    internal class Game
    {
        public int[] EnemyPosition = new int[2];
        public int[] PlayerPosition = new int[2];
        public string[,] GameBoard = new string[10, 10];
        public bool End = false;
        public bool Player_won;
        public Game()
        {
            for (int i = 0; i < GameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < GameBoard.GetLength(1); j++)
                {
                    GameBoard[i, j] = "o";
                }

            }
        }
        public void PrintGameBoard()
        {
            Console.Clear();
            Console.WriteLine("------------------------------");
            for (int i = 0; i < GameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < GameBoard.GetLength(1); j++)
                {
                    if (i == EnemyPosition[0] && j == EnemyPosition[1])
                    {
                        GameBoard[i, j] = "X";
                    }
                    if (i == PlayerPosition[0] && j == PlayerPosition[1])
                    {
                        GameBoard[i, j] = "O";
                    }
                    if (GameBoard[i, j] == "X" || GameBoard[i, j] == "O")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" " + GameBoard[i, j] + " ");
                        Console.ResetColor();
                    }
                    else
                        Console.Write(" " + GameBoard[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("------------------------------");
        }
        public void Inicialaze()
        {
            Random r = new Random();
            EnemyPosition[0] = 0;
            EnemyPosition[1] = r.Next(0, 10);
            PlayerPosition[0] = 9;
            PlayerPosition[1] = r.Next(0, 10);
        }
        public void EnemyMove()
        {
            GameBoard[EnemyPosition[0], EnemyPosition[1]] = "o";
            EnemyPosition[0] += 1;
        }
        public void PlayerMove()
        {
            bool Moved = false;
            while (!Moved)
            {
                Console.WriteLine("Wybierz gdzie chcesz się ruszyć q w e a d z x c ");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "q":
                        if (PlayerPosition[0] - 1 >= 0 && PlayerPosition[1] - 1 >= 0)
                        {
                            CoverPrints();
                            PlayerPosition[0] -= 1;
                            PlayerPosition[1] -= 1;
                            Moved = true;
                        }
                        break;
                    case "w":
                        if (PlayerPosition[0] - 1 >= 0)
                        {
                            CoverPrints();
                            PlayerPosition[0] -= 1;
                            Moved = true;
                        }
                        break;
                    case "e":
                        if (PlayerPosition[0] - 1 >= 0 && PlayerPosition[1] + 1 <= 9)
                        {
                            CoverPrints();
                            PlayerPosition[0] -= 1;
                            PlayerPosition[1] += 1;
                            Moved = true;
                        }
                        break;
                    case "a":
                        if (PlayerPosition[1] - 1 >= 0)
                        {
                            CoverPrints();
                            PlayerPosition[1] -= 1;
                            Moved = true;
                        }
                        break;
                    case "d":
                        if (PlayerPosition[1] + 1 <= 9)
                        {
                            CoverPrints();
                            PlayerPosition[1] += 1;
                            Moved = true;
                        }
                        break;
                    case "z":
                        if (PlayerPosition[0] + 1 <= 9 && PlayerPosition[1] - 1 >= 0)
                        {
                            CoverPrints();
                            PlayerPosition[0] += 1;
                            PlayerPosition[1] -= 1;
                            Moved = true;
                        }
                        break;
                    case "x":
                        if (PlayerPosition[0] + 1 <= 9)
                        {
                            CoverPrints();
                            PlayerPosition[0] += 1;
                            Moved = true;
                        }
                        break;
                    case "c":
                        if (PlayerPosition[0] + 1 <= 9 && PlayerPosition[1] + 1 <= 9)
                        {
                            CoverPrints();
                            PlayerPosition[0] += 1;
                            PlayerPosition[1] += 1;
                            Moved = true;
                        }
                        break;
                    default:
                        Console.WriteLine("Ufam iż umiesz podać włąściwą literę przyłowywaczu");
                        break;
                }
                if (!Moved)
                {
                    Console.WriteLine("spróbuj ponownie");
                }
            }
        }
        public void WinCheck()
        {
            if (PlayerPosition[0] == 0) 
            {
                Player_won = true;
                End = true;
            }
            if (EnemyPosition[0] == 9)
            {
                End = true;
            }
        }
        public void CoverPrints()
        {
            GameBoard[PlayerPosition[0], PlayerPosition[1]] = "o";
        }
        public void Kill(char o)
        {
            Random r = new Random();
            if (o == 'x')
            {
                if (GameBoard[EnemyPosition[0], EnemyPosition[1]] == GameBoard[PlayerPosition[0], PlayerPosition[1]])
                {
                    GameBoard[EnemyPosition[0], EnemyPosition[1]] = "o";
                    EnemyPosition[0] = 0;
                    EnemyPosition[1] = r.Next(0, 10);
                }
            }
            if (o == 'o')
            {
                if (GameBoard[PlayerPosition[0], PlayerPosition[1]] == "X")
                {
                    PlayerPosition[0] = 9;
                    PlayerPosition[1] = r.Next(0, 10);

                }
            }
        }
    }
}
