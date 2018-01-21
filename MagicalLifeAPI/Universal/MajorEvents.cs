namespace MagicalLifeAPI.Universal
{
    /// <summary>
    /// This class holds major events that are often used by many components of the game.
    /// </summary>
    public static class MajorEvents
    {
        //https://www.codeproject.com/Articles/11541/The-Simplest-C-Events-Example-Imaginable

        /// <summary>
        /// Raised at the start of each turn.
        /// </summary>
        public static event WorldChanging TurnStart;

        public delegate void WorldChanging(World.World world);

        /// <summary>
        /// Raised at the end of each turn.
        /// </summary>
        public static event WorldChanging TurnEnd;
    }
}