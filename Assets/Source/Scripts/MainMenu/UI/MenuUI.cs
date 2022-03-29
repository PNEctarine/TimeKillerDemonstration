using System;
using Kuhpik;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : UIScreen
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _clickerButton;

    [field: SerializeField] public Button LanguageSwitchButton { get; private set; }

    [Space]
    [SerializeField] private Image _languageField;
    [SerializeField] private Sprite[] _countriesFlags;

    [Space]
    [SerializeField] private TextMeshProUGUI _coinsTMP;
    [SerializeField] private TextMeshProUGUI _scoreTMP;

    public override void Subscribe()
    {
        _playButton.onClick.AddListener(() => Bootstrap.GameRestart(1));
        _shopButton.onClick.AddListener(() => Bootstrap.GameRestart(2));
        _clickerButton.onClick.AddListener(()=> Bootstrap.GameRestart(3));
    }

    public void ShowScore(int score)
    {
        _scoreTMP.text = score.ToString();
    }

    public void ShowCoins(float coins)
    {
        _coinsTMP.text = Math.Round(coins, 2).ToString();
    }

    public void SetLanguageUI(int key)
    {
        _languageField.sprite = _countriesFlags[key];
    }
}
