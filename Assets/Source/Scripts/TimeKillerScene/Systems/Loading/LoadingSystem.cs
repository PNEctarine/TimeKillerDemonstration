using Kuhpik;
using UnityEngine;

public class LoadingSystem : GameSystem, IIniting
{
    [SerializeField] private AudioSource _audioSource;

    void IIniting.OnInit()
    {
        Time.timeScale = 1f;
        game.AudioSource = _audioSource;
    }
}
