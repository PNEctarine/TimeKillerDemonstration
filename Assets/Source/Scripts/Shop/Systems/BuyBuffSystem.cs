using Kuhpik;
using UnityEngine;
using Yodo1.MAS;

public class BuyBuffSystem : GameSystemWithScreen<ShopUI>, IIniting
{
    private AdsManager _adsManager;

    void IIniting.OnInit()
    {
        _adsManager = FindObjectOfType<AdsManager>();
        screen.Score.SetActive(false);

        screen.FirstCoinMiningBuyButton.onClick.AddListener(() => FirstClickBuy());
        screen.SecondCoinMiningBuyButton.onClick.AddListener(() => SecondClickBuy());
        screen.CoinsRewardButton.onClick.AddListener(() => RewardCoins());
        screen.TimeDilationButton.onClick.AddListener(() => TimeDilation(false));
        screen.AdTimeDilationButton.onClick.AddListener(() => TimeDilation(true));

        UpdateUI();
    }

    private void UpdateUI()
    {
        screen.FirstCoinMiningTMP.text = player.FirstCoinMineCost.ToString();
        screen.SecondCoinMiningTMP.text = player.SecondCoinMineCost.ToString();
        screen.TimeDilationCountText.text = player.TimeDilationCounter.ToString();
        screen.TimeDilationText.text = $"{player.AdsCounter}/3";

        screen.ShowCoins(player.Coins);

        Bootstrap.SaveGame();
    }

    private void FirstClickBuy()
    {
        if (player.Coins >= player.FirstCoinMineCost)
        {
            player.Coins -= player.FirstCoinMineCost;
            player.FirstCoinMineCost *= 1.5f;
            player.CoinMine += 0.01f;

            UpdateUI();
        }
    }

    private void SecondClickBuy()
    {
        if (player.Coins >= player.SecondCoinMineCost)
        {
            player.Coins -= player.SecondCoinMineCost;
            player.SecondCoinMineCost *= 1.9f;
            player.CoinMine += 0.5f;

            UpdateUI();
        }
    }

    private void RewardCoins()
    {
        if (Yodo1U3dMas.IsRewardedAdLoaded() && player.IsInternet)
        {
            Debug.Log("Show");
            Yodo1U3dMas.ShowRewardedAd("100Coins");
            player.Coins += 100;
            UpdateUI();
        }

        else
        {
            _adsManager.CheckInternet();
        }
    }

    private void TimeDilation(bool isAd)
    {
        if (isAd)
        {
            if (Yodo1U3dMas.IsRewardedAdLoaded() && player.IsInternet)
            {
                Debug.Log("Show");
                Yodo1U3dMas.ShowRewardedAd("Time dilation");
                player.AdsCounter++;

                if (player.AdsCounter == 3)
                {
                    player.AdsCounter = 0;
                    player.TimeDilationCounter++;
                }

                UpdateUI();
            }

            else
            {
                _adsManager.CheckInternet();
            }
        }

        else if (player.Coins >= player.TimeDilationCost)
        {
            player.Coins -= player.TimeDilationCost;
            UpdateUI();
        }
    }
}
