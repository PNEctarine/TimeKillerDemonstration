using Kuhpik;
using UnityEngine;

public class WatchLoadingSystem : GameSystem, IIniting
{
    [SerializeField] private int _watchesCounter;
    [SerializeField] private GameObject _enemy;

    void IIniting.OnInit()
    {
        for (int i = 0; i < _watchesCounter; i++)
        {
            GameObject spawnedEnemy = Instantiate(_enemy);
            spawnedEnemy.SetActive(false);

            game.WatchesComponent.Add(spawnedEnemy.GetComponent<WatchMovementComponent>());
            game.Watches.Enqueue(spawnedEnemy);
        }
    }
}
