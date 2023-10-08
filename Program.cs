using Slayer;
using System.Timers;

Game game = new Game();
game.Inicialaze();
CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
System.Timers.Timer timer = new System.Timers.Timer(2000);
timer.Elapsed += TimerElapsed;
timer.AutoReset = true;
timer.Start();

while (!game.End)
{
    if (!game.End)
    {
        game.PlayerMove();
        if (game.Kill('x'))
        {
            cancellationTokenSource.Cancel();
            while (game.BonusMoves != 0)
            {
                game.BonusMoves--;
                game.PlayerMove();
                game.Kill('x');
                game.WinCheck();
            }
            cancellationTokenSource = new CancellationTokenSource();
        }
        game.WinCheck();
    }
}
if (game.Player_won)
{
    Console.WriteLine("Gratulacje użytkowniku powietrza");
}
else
{
    game.PrintGameBoard();
    Console.WriteLine("wow...");
}
void TimerElapsed(object sender, ElapsedEventArgs e)
{
    if (!cancellationTokenSource.Token.IsCancellationRequested)
    {
        game.EnemyMove();
        if (game.Kill('o') || game.End == true)
        {
            timer.Stop();
            game.PrintGameBoard();
            Console.WriteLine("wow...");
        }
    }
} 