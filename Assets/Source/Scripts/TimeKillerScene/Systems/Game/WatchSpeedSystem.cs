using System.Collections;
using Kuhpik;
using UnityEngine;

public class WatchSpeedSystem : GameSystem, IIniting
{
    [SerializeField] private float _wanchesAcceleration;
    private float _speed = 1;

    void IIniting.OnInit()
    {
        StartCoroutine(SpeedUp());
    }

    private IEnumerator SpeedUp()
    {
        yield return new WaitForSeconds(1f);

        if (Bootstrap.GetCurrentGamestate() != EGamestate.Lose && Bootstrap.GetCurrentGamestate() != EGamestate.Pause)
        {
            _speed += _wanchesAcceleration;

            if (_speed < 10)
            {
                _speed += 0.005f;

                for (int i = 0; i < game.WatchesComponent.Count; i++)
                {
                    game.WatchesComponent[i].Speed = _speed;
                }
            }

            else
            {
                _speed = 10f;
                yield break;
            }
        }

        StartCoroutine(SpeedUp());
    }
}
