using Kuhpik;
using Lean.Localization;
using UnityEngine;

public class LanguageSwitchSystem : GameSystemWithScreen<MenuUI>, IIniting
{
    private LeanLocalization _leanLocalization;

    void IIniting.OnInit()
    {
        _leanLocalization = FindObjectOfType<LeanLocalization>();

        screen.LanguageSwitchButton.onClick.AddListener(() =>
        {
            player.LanguageKey++;
            SwitchLanguage();
        });

        SwitchLanguage();
    }

    private void SwitchLanguage()
    {
        if (player.LanguageKey > 2)
        {
            player.LanguageKey = 0;
        }

        if (player.IsFirstLaunch)
        {
            switch (Application.systemLanguage)
            {
                case (SystemLanguage.English):
                    player.LanguageKey = 0;
                    break;

                case (SystemLanguage.German):
                    player.LanguageKey = 1;
                    break;

                case (SystemLanguage.Russian):
                    player.LanguageKey = 2;
                    break;

                default:
                    player.LanguageKey = 1;
                    break;
            }

            player.IsFirstLaunch = false;
        }

        switch (player.LanguageKey)
        {
            case (0):
                _leanLocalization.SetCurrentLanguage("English");
                screen.SetLanguageUI(0);
                break;

            case (1):
                _leanLocalization.SetCurrentLanguage("German");
                screen.SetLanguageUI(1);
                break;

            case (2):
                _leanLocalization.SetCurrentLanguage("Russian");
                screen.SetLanguageUI(2);
                break;
        }

        Bootstrap.SaveGame();
    }
}
