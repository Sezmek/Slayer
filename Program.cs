using Slayer;
using System.Timers;

Game game = new Game();
game.Inicialaze();
System.Timers.Timer timer = new System.Timers.Timer(2000);
timer.Elapsed += TimerElapsed;
timer.AutoReset = true;
timer.Start();

while (!game.End)
{
    if (!game.End)
    {
        game.PlayerMove();
        game.Kill('x');
        game.WinCheck();
    }
}
if (game.Player_won)
{
    Console.WriteLine("Gratulacje użytkowniku powietrza");
}
else
{
    Console.WriteLine("wow...");
    game.PrintGameBoard();
}
void TimerElapsed(object sender, ElapsedEventArgs e)
{
    game.EnemyMove();
    if (game.Kill('o') || game.End == true)
    timer.Stop();
} 