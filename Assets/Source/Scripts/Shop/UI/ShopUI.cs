using System;
using Kuhpik;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : UIScreen
{
    [field: SerializeField] public GameObject Score { get; private set; }

    [Space]
    [SerializeField] private Button _backButton;

    [field: SerializeField] public Button FirstCoinMiningBuyButton { get; private set; }
    [field: SerializeField] public Button SecondCoinMiningBuyButton { get; private set; }
    [field: SerializeField] public Button CoinsRewardButton { get; private set; }
    [field: SerializeField] public Button TimeDilationButton { get; private set; }
    [field: SerializeField] public Button AdTimeDilationButton { get; private set; }

    [Space]
    [SerializeField] private TextMeshProUGUI _coinsTMP;

    [field: SerializeField] public TextMeshProUGUI FirstCoinMiningTMP { get; private set; }
    [field: SerializeField] public TextMeshProUGUI SecondCoinMiningTMP { get; private set; }

    [field: SerializeField] public Text TimeDilationText { get; private set; }
    [field: SerializeField] public Text TimeDilationCountText { get; private set; }

    public override void Subscribe()
    {
        _backButton.onClick.AddListener(() => Bootstrap.GameRestart(0));
    }

    public void ShowCoins(float coins)
    {
        _coinsTMP.text = Math.Round(coins, 2).ToString();
    }
}
