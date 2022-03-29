using Kuhpik;
using Yodo1.MAS;

public class LoseSystem : GameSystemWithScreen<LoseScreen>, IIniting
{
    private AdsManager _adsManager;

    void IIniting.OnInit()
    {
        _adsManager = FindObjectOfType<AdsManager>();

        screen.SecondChanceButton.onClick.AddListener(() => SecondChance());
        player.HighScore = game.Score > player.HighScore ? game.Score : player.HighScore;
        screen.SetHighScore(player.HighScore);
        game.AudioSource.Stop();

        Bootstrap.SaveGame();
    }

    private void SecondChance()
    {
        if (Yodo1U3dMas.IsRewardedAdLoaded() && player.IsInternet)
        {
            screen.SecondChanceButton.interactable = false;
            WatchMovementComponent[] watches = FindObjectsOfType<WatchMovementComponent>();

            for (int i = 0; i < watches.Length; i++)
            {
                watches[i].gameObject.SetActive(false);
                game.Watches.Enqueue(watches[i].gameObject);
            }

            Yodo1U3dMas.ShowRewardedAd("SecondChance");
            Bootstrap.ChangeGameState(EGamestate.Pause);
        }

        else
        {
            _adsManager.CheckInternet();
        }
    }

    private void Update()
    {
        print("ASDASDDA " + player.IsInternet);
    }
}
