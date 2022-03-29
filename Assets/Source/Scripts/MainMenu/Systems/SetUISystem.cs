using Kuhpik;

public class SetUISystem : GameSystemWithScreen<MenuUI>, IIniting
{
    void IIniting.OnInit()
    {
        screen.ShowScore(player.HighScore);
        screen.ShowCoins(player.Coins);
    }
}
