using Slayer;
Game game = new Game();
game.Inicialaze();

while (!game.End)
{
    game.EnemyMove();
    game.Kill('o');
    game.WinCheck();
    game.PrintGameBoard();
    if (!game.End)
    {
        game.PlayerMove();
        game.Kill('x');
        game.WinCheck();
    }
}
game.PrintGameBoard();
if (game.Player_won)
{
    Console.WriteLine("Gratulacje użytkowniku powietrza");
}
else
{
    Console.WriteLine("wow...");
}
