namespace MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic.DesignRules
{
    public struct RoomGenChance
    {
        /// <summary>
        /// The type of room that this gives a chance to generate.
        /// </summary>
        public DungeonNodeType RoomTypeToGenerate { get; set; }

        /// <summary>
        /// The type of room that this might generate something adjacent/connected to.
        /// </summary>
        public DungeonNodeType RoomTypeToGenerateOn { get; set; }

        public double ChanceToGenerate { get; set; }

        public RoomGenChance(DungeonNodeType roomTypeToGenerate, DungeonNodeType roomTypeToGenerateOn, double chanceToGenerate)
        {
            this.RoomTypeToGenerate = roomTypeToGenerate;
            this.RoomTypeToGenerateOn = roomTypeToGenerateOn;
            this.ChanceToGenerate = chanceToGenerate;
        }
    }
}
