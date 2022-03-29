using Kuhpik;
using Supyrb;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : UIScreen
{
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _homeButton;

    [Space]
    [SerializeField] private Button _soundButton;

    [Space]
    [SerializeField] private Sprite[] _soundSprites;

    private int _soundSwitch;

    private void Start()
    {

        _soundSwitch = PlayerPrefs.GetInt("Sound", 1);
        SoundSwitcher();
    }

    public override void Subscribe()
    {
        _resumeButton.onClick.AddListener(() =>
        {
            PlaySound();
            Bootstrap.ChangeGameState(EGamestate.Game);
        });


        _homeButton.onClick.AddListener(() =>
        {
            Signals.Clear();
            Bootstrap.GameRestart(0);
        });

        _soundButton.onClick.AddListener(() =>
        {
            _soundSwitch = _soundSwitch == 1 ? 0 : 1;
            SoundSwitcher();
        });
    }

    private void SoundSwitcher()
    {
        _soundButton.GetComponent<Image>().sprite = _soundSprites[_soundSwitch];
        AudioListener.volume = _soundSwitch;
        PlayerPrefs.SetInt("Sound", _soundSwitch);
    }

    private void PlaySound()
    {
        if (_soundSwitch == 1)
        {
            Signals.Get<OnSoundPause>().Dispatch();
        }
    }
}
