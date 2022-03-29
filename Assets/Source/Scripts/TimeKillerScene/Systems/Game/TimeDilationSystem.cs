using System.Collections;
using Kuhpik;
using UnityEngine;

public class TimeDilationSystem : GameSystemWithScreen<GameScreen>, IIniting
{
    void IIniting.OnInit()
    {
        screen.TimeDilationButton.onClick.AddListener(TimeSlow);
        CheckBuffCount();
    }

    private void CheckBuffCount()
    {
        if (player.TimeDilationCounter > 0)
        {
            screen.TimeDilationButton.gameObject.SetActive(true);
        }

        else
        {
            screen.TimeDilationButton.gameObject.SetActive(false);
        }
    }

    private void TimeSlow()
    {
        screen.TimeDilationButton.gameObject.SetActive(false);

        Time.timeScale = 0.5f;
        player.TimeDilationCounter--;

        StartCoroutine(CullDown());
    }

    private IEnumerator CullDown()
    {
        yield return new WaitForSeconds(5f);
        Time.timeScale = 1f;
        CheckBuffCount();
    }
}
