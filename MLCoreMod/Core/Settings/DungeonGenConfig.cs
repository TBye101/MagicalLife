using System;
using System.Collections.Generic;
using System.Text;

namespace MLCoreMod.Core.Settings
{
    /// <summary>
    /// Holds some settings for dungeon generation.
    /// </summary>
    public class DungeonGenConfig
    {
        #region CircularHallwayGeneration

        /// <summary>
        /// The minimum number of circular hallways to Be.
        /// </summary>
        public int MinCircleHallways { get; set; } = 8;

        /// <summary>
        /// The maximum number of circular hallways to Be.
        /// </summary>
        public int MaxCircleHallways { get; set; } = 16;

        /// <summary>
        /// The minimum size of the circular hallway to Be.
        /// </summary>
        public int MinCircleThickness { get; set; } = 2;

        /// <summary>
        /// The maximum size of the circular hallway to Be. 
        /// </summary>
        public int MaxCircleThickness { get; set; } = 4;

        #endregion

        #region DungeonDesignGraph

        #region Fitness

        public bool TreasureRoomRequiresBossRoomRuleEnabled { get; set; } = true;
        public bool NoConnectedBossRoomsRuleEnabled { get; set; } = true;

        #endregion

        #region Genes

        public bool CanBossRoomBeAdjacentToBossRoom { get; set; } = true;
        public bool CanBossRoomBeAdjacentToDescentRoom { get; set; } = true;
        public bool CanBossRoomBeAdjacentToEntranceRoom { get; set; } = true;
        public bool CanBossRoomBeAdjacentToHallway { get; set; } = true;
        public bool CanBossRoomBeAdjacentToMinionRoom { get; set; } = true;
        public bool CanBossRoomBeAdjacentToStandardRoom { get; set; } = true;
        public bool CanBossRoomBeAdjacentToTreasureRoom { get; set; } = true;



        public bool CanDescentRoomBeAdjacentToDescentRoom { get; set; } = true;
        public bool CanDescentRoomBeAdjacentToEntranceRoom { get; set; } = true;
        public bool CanDescentRoomBeAdjacentToHallway { get; set; } = true;
        public bool CanDescentRoomBeAdjacentToMinionRoom { get; set; } = true;
        public bool CanDescentRoomBeAdjacentToStandardRoom { get; set; } = true;
        public bool CanDescentRoomBeAdjacentToTreasureRoom { get; set; } = true;



        public bool CanHallwayBeAdjacentToEntranceRoom { get; set; } = true;
        public bool CanHallwayBeAdjacentToHallway { get; set; } = true;
        public bool CanHallwayRoomBeAdjacentToMinionRoom { get; set; } = true;
        public bool CanHallwayRoomBeAdjacentToStandardRoom { get; set; } = true;
        public bool CanHallwayRoomBeAdjacentToTreasureRoom { get; set; } = true;



        public bool CanMinionRoomBeAdjacentToEntranceRoom { get; set; } = true;
        public bool CanMinionRoomBeAdjacentToMinionRoom { get; set; } = true;
        public bool CanMinionRoomBeAdjacentToStandardRoom { get; set; } = true;
        public bool CanMinionRoomBeAdjacentToTreasureRoom { get; set; } = true;



        public bool CanStandardRoomBeAdjacentToEntranceRoom { get; set; } = true;
        public bool CanStandardRoomBeAdjacentToStandardRoom { get; set; } = true;
        public bool CanStandardRoomBeAdjacentToTreasureRoom { get; set; } = true;



        public bool CanTreasureRoomBeAdjacentToEntranceRoom { get; set; } = true;
        public bool CanTreasureRoomBeAdjacentToTreasureRoom { get; set; } = true;

        #endregion

        #region Design

        public int MaxRoomsAdjacentToNode { get; set; } = 10;
        public int MinRoomsAdjacentToNode { get; set; } = 0;
        public int MaxRoomsInDungeon { get; set; } = 50;

        #endregion

        #endregion
    }
}
