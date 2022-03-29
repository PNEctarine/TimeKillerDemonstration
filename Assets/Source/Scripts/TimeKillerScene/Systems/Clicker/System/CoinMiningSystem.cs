using Kuhpik;

public class CoinMiningSystem : GameSystemWithScreen<ClickerUI>, IIniting
{
    public void OnInit()
    {
        screen.Score.SetActive(false);
        screen.ShowCoins(player.Coins);

        screen.CoinButton.onClick.AddListener(() =>
        {
            player.Coins++;
            screen.ShowCoins(player.Coins);
        });
    }
}
