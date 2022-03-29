namespace Kuhpik
{
    public enum EGamestate
    {
        // Don't change int values in the middle of development.
        // Otherwise all of your settings in inspector can be messed up.

        Menu = 0,
        Loading = 1,
        Game = 2,
        Pause = 3,
        Lose = 4,
        Shop = 5,
        Clicker = 6,

        CurrencyShared = 100

        // Extend just like that
        //
        // Shop = 20,
        // Settings = 30,
        // Revive = 100
    }
}