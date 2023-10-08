using System.Numerics;

namespace Slayer
{
    internal class Game
    {
        public int[] EnemyPosition = new int[2];
        public int[] Enemy2Position = new int[2];
        public int[] PlayerPosition = new int[2];
        public string[,] GameBoard = new string[10, 10];
        public bool End = false;
        public bool Player_won;
        public int BonusMoves = 0;
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
                    if ((i == EnemyPosition[0] && j == EnemyPosition[1]) || (i == Enemy2Position[0] && j == Enemy2Position[1]))
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
            do Enemy2Position[1] = r.Next(0, 10);
            while (EnemyPosition[1] == Enemy2Position[1]);
            PlayerPosition[0] = 9;
            PlayerPosition[1] = r.Next(0, 10);
        }
        public void EnemyMove()
        {
            GameBoard[EnemyPosition[0], EnemyPosition[1]] = "o";
            GameBoard[Enemy2Position[0], Enemy2Position[1]] = "o";
            Vector2 newEnemyPosition = calculateDirection(PlayerPosition[1], PlayerPosition[0], EnemyPosition[1], EnemyPosition[0]);
            Vector2 newEnemy2Position = calculateDirection(PlayerPosition[1], PlayerPosition[0], Enemy2Position[1], Enemy2Position[0]);
            if (newEnemyPosition.X != Enemy2Position[1] || newEnemyPosition.Y != Enemy2Position[0])
            {
                EnemyPosition[0] = (int)newEnemyPosition.Y;
                EnemyPosition[1] = (int)newEnemyPosition.X;
            }
            if (newEnemy2Position.X != EnemyPosition[1] || newEnemy2Position.Y != EnemyPosition[0])
            {
                Enemy2Position[0] = (int)newEnemy2Position.Y;
                Enemy2Position[1] = (int)newEnemy2Position.X;
            }
            PrintGameBoard();
        }
        public void PlayerMove()
        {
            bool Moved = false;

            while (!Moved)
            {
                Console.WriteLine("Wybierz gdzie chcesz się ruszyć q w e a d z x c ");
                string option = Console.ReadLine();
                if (!End)
                {
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
                            break;
                    }
                }
                else
                    Moved = true;            
            }
            PrintGameBoard();
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
        public bool Kill(char o)
        {
            Random r = new Random();
            if (o == 'x')
            {
                if (!End)
                {
                    if ((PlayerPosition[0] == EnemyPosition[0] && PlayerPosition[1] == EnemyPosition[1]) || (PlayerPosition[0] == Enemy2Position[0] && PlayerPosition[1] == Enemy2Position[1]))
                    {
                        if (PlayerPosition[0] == EnemyPosition[0] && PlayerPosition[1] == EnemyPosition[1])
                        {
                            GameBoard[EnemyPosition[0], EnemyPosition[1]] = "o";
                            EnemyPosition[0] = 0;
                            EnemyPosition[1] = r.Next(0, 10);
                        }
                        if (PlayerPosition[0] == Enemy2Position[0] && PlayerPosition[1] == Enemy2Position[1])
                        {
                            GameBoard[Enemy2Position[0], Enemy2Position[1]] = "o";
                            Enemy2Position[0] = 0;
                            Enemy2Position[1] = r.Next(0, 10);
                        }
                        PrintGameBoard();
                        BonusMoves += 2;
                        return true;
                    }
                }
            }
            if (o == 'o')
            {
                if ((PlayerPosition[0] == EnemyPosition[0] && PlayerPosition[1] == EnemyPosition[1]) || (PlayerPosition[0] == Enemy2Position[0] && PlayerPosition[1] == Enemy2Position[1]))
                {
                    PlayerPosition[0] = -1;
                    PlayerPosition[1] = -1;
                    End = true;
                    PrintGameBoard();
                    return true;
                }
            }
            return false;
        }
        public Vector2 calculateDirection(int PX, int PY, int EX, int EY)
        {
            float dx = EX - PX;
            float dy = EY - PY;
            Vector2 vector2 = new Vector2(EX, EY);
            if (dx > 0)
            {
                vector2.X -= 1;
            }
            if (dx < 0)
            {
                vector2.X += 1;
            }
            if (dy < 0)
            {
                vector2.Y += 1;
            }
            if (dy > 0)
            {
                vector2.Y -= 1;
            }
            return vector2;
        }
    }
}
