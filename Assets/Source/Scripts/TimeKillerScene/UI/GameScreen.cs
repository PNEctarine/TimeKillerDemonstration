using System;
using Kuhpik;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : UIScreen
{
    [field: SerializeField] public Button TimeDilationButton { get; private set; }
    [SerializeField] private Button _pauseButton;

    [SerializeField] private TextMeshProUGUI _coinsTMP;
    [SerializeField] private TextMeshProUGUI _scoreTMP;

    public override void Subscribe()
    {
        _pauseButton.onClick.AddListener(() => Bootstrap.ChangeGameState(EGamestate.Pause));
    }

    public void ShowScore(int score)
    {
        _scoreTMP.text = score.ToString();
    }

    public void ShowCoins(float coins)
    {
        _coinsTMP.text = Math.Round(coins, 2).ToString();
    }
}
