using System;
using Kuhpik;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickerUI : UIScreen
{
    [field: SerializeField] public GameObject Score { get; private set; }

    [field: SerializeField] public Button CoinButton { get; private set; }

    [SerializeField] private TextMeshProUGUI _coinsTMP;
    [SerializeField] private Button _backButton;

    private void Start()
    {
        _backButton.onClick.AddListener(() => Bootstrap.GameRestart(0));
    }

    public void ShowCoins(float coins)
    {
        _coinsTMP.text = Math.Round(coins, 2).ToString();
    }
}
