using System.Collections;
using Kuhpik;
using Supyrb;
using UnityEngine;

public class WatchSpawnSystem : GameSystemWithScreen<GameScreen>, IIniting
{
    [SerializeField] private Camera _mainCamera;

    [SerializeField] private float _spawnSpeed = 1;

    private Vector3 _leftTop;
    private Vector3 _rightTop;

    void IIniting.OnInit()
    {
        Signals.Get<OnWatchReturnQueue>().AddListener(ReturnToPool);

        Vector3 cameraToObject = transform.position - _mainCamera.transform.position;
        float distance = -Vector3.Project(cameraToObject, Camera.main.transform.forward).y;

        _leftTop = _mainCamera.ViewportToWorldPoint(new Vector3(0, 1, distance));
        _rightTop = _mainCamera.ViewportToWorldPoint(new Vector3(1, 1, distance));

        screen.ShowCoins(player.Coins);
        StartCoroutine(WatchesSpawn());
    }

    private IEnumerator WatchesSpawn()
    {
        yield return new WaitForSeconds(_spawnSpeed);

        if (Bootstrap.GetCurrentGamestate() != EGamestate.Lose && Bootstrap.GetCurrentGamestate() != EGamestate.Pause)
        {
            GameObject spawnedWatch = game.Watches.Dequeue();

            spawnedWatch.SetActive(true);
            spawnedWatch.transform.position = new Vector3(Random.Range(_leftTop.x + 0.5f, _rightTop.x - 0.5f), 5.5f, 0);

            if (_spawnSpeed > 0.2f)
            {
                _spawnSpeed -= 0.005f;
            }

            else
            {
                _spawnSpeed = 0.2f;
            }
        }

        StartCoroutine(WatchesSpawn());
    }

    private void ReturnToPool(GameObject enemy)
    {
        player.Coins += player.CoinMine;
        game.Score++;

        screen.ShowCoins(player.Coins);
        screen.ShowScore(game.Score);

        enemy.SetActive(false);
        game.Watches.Enqueue(enemy);
    }
}
