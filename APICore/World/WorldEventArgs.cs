using System;

namespace MagicalLifeAPI.World
{
    /// <summary>
    /// Event arguments for any event involving the world.
    /// </summary>
    public class WorldEventArgs : EventArgs
    {
        /// <summary>
        /// The current state of the world.
        /// </summary>
        public World.Data.World World { get; protected set; }

        public WorldEventArgs(World.Data.World world)
        {
            this.World = world;
        }
    }
}