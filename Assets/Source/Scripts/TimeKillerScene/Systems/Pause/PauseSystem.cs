using Kuhpik;
using Supyrb;

public class PauseSystem : GameSystem, IIniting
{
    void IIniting.OnInit()
    {
        Signals.Get<OnSoundPause>().AddListener(PlaySound);
        game.AudioSource.Pause();
    }

    private void PlaySound()
    {
        Signals.Get<OnSoundPause>().Clear();
        game.AudioSource.Play();
    }
}
