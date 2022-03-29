using System;

namespace Kuhpik
{
    /// <summary>
    /// Used to store player's data. Change it the way you want.
    /// </summary>
    [Serializable]
    public class PlayerData
    {
        public bool IsFirstLaunch = true;
        public bool IsInternet;

        public int HighScore;
        public int LanguageKey;
        public int AdsCounter;
        public int TimeDilationCounter;

        public float Coins;
        public float CoinMine = 1f;

        public float FirstCoinMineCost = 10;
        public float SecondCoinMineCost = 100;
        public float TimeDilationCost = 1000;


        // Example (I use public fields for data, but u free to use properties\methods etc)
        // [BoxGroup("level")] public int level;
        // [BoxGroup("currency")] public int money;
    }
}