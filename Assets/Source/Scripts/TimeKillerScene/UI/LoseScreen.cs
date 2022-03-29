using Kuhpik;
using Lean.Localization;
using Supyrb;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoseScreen : UIScreen
{
    [field: SerializeField] public Button SecondChanceButton { get; private set; }
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _menuButton;

    [SerializeField] private TextMeshProUGUI _HighScoreTMP;

    public override void Subscribe()
    {
        _restartButton.onClick.AddListener(() =>
        {
            Signals.Clear();
            Bootstrap.GameRestart(1);
        });

        _menuButton.onClick.AddListener(() =>
        {
            Signals.Clear();
            Bootstrap.GameRestart(0);
        });
    }

    public void SetHighScore(int score)
    {
         string highScoreText = LeanLocalization.GetTranslationText("HighScore");
        _HighScoreTMP.text = $"{highScoreText}: {score}";
    }
}
