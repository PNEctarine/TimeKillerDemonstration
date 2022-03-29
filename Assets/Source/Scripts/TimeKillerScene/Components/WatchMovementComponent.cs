using Kuhpik;
using Supyrb;
using UnityEngine;

public class WatchMovementComponent : MonoBehaviour
{
    public float Speed = 1f;
    private float _screenEndY;

    private void Start()
    {
        Vector2 screenEnd = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        _screenEndY = screenEnd.y - transform.localScale.y;
    }

    private void Update()
    {
        if (Bootstrap.GetCurrentGamestate() != EGamestate.Lose && Bootstrap.GetCurrentGamestate() != EGamestate.Pause)
        {
            transform.position += Speed * Time.deltaTime * Vector3.down;

            if (transform.position.y < _screenEndY)
            {
                Bootstrap.ChangeGameState(EGamestate.Lose);
            }
        }
    }

    public void OnMouseDown()
    {
        if (Bootstrap.GetCurrentGamestate() != EGamestate.Lose && Bootstrap.GetCurrentGamestate() != EGamestate.Pause)
        {
            Signals.Get<OnWatchReturnQueue>().Dispatch(gameObject);
        }
    }
}
