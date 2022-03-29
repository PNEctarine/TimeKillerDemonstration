using InternetCheck;
using Kuhpik;
using UnityEngine;
using Yodo1.MAS;

public class AdsManager : GameSystem, IIniting
{
    [SerializeField] private InternetAccessComponent InternetAccess;

    private static bool _isInitialized;

    void IIniting.OnInit()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Yodo1AdBuildConfig config = new Yodo1AdBuildConfig().enableUserPrivacyDialog(true);
        Yodo1U3dMas.SetAdBuildConfig(config);

        if (_isInitialized == false)
        {
            player.IsInternet = false;
        }

        CheckInternet();
    }

    private void MASInit()
    {
        Yodo1U3dMas.InitializeSdk();
    }

    public void CheckInternet()
    {
        StartCoroutine(InternetAccess.TestConnection(result =>
        {
            Debug.Log("Result: " + result);
            if (result && _isInitialized == false)
            {
                player.IsInternet = true;
                _isInitialized = true;
                Bootstrap.SaveGame();
                MASInit();
            }
        }));
    }
}
