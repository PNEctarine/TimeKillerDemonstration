using System.Collections.Generic;
using UnityEngine;

namespace Kuhpik
{
    /// <summary>
    /// Used to store game data. Change it the way you want.
    /// </summary>
    public class GameData
    {
        public int Score;

        public AudioSource AudioSource;
        public Transform WatchSpawnPoint;
        public Queue<GameObject> Watches = new Queue<GameObject>();
        public List<WatchMovementComponent> WatchesComponent = new List<WatchMovementComponent>();

        // Example (I use public fields for data, but u free to use properties\methods etc)
        // public float LevelProgress;
        // public Enemy[] Enemies;
    }
}