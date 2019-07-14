using System;
using System.Collections.Generic;
using System.Text;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph
{
    /// <summary>
    /// Defines all the types of dungeon nodes for the dungeon design graph.
    /// </summary>
    public enum DungeonNodeType
    {
        /// <summary>
        /// Contains a powerful creature or dangerous encounter.
        /// </summary>
        BossRoom,

        /// <summary>
        /// The room that contains stairs down, a link to the next level of the dungeon.
        /// </summary>
        DescentRoom,

        /// <summary>
        /// The entrance/first room of the dungeon.
        /// </summary>
        EntranceRoom,

        /// <summary>
        /// Connects rooms.
        /// </summary>
        Hallway,

        /// <summary>
        /// A room that contains minions.
        /// </summary>
        MinionRoom,

        /// <summary>
        /// Any room that doesn't fall into any other catagory.
        /// </summary>
        StandardRoom,

        /// <summary>
        /// Contains mostly loot/treasure rewards, normally connected to a boss room.
        /// </summary>
        TreasureRoom,
    }
}