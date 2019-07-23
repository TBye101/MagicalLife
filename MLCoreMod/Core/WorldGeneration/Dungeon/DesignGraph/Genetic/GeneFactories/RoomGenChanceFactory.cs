using MagicalLifeMod.Core.Settings;
using MLAPI.Genetic;
using MLCoreMod.Core.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic
{
    public class RoomGenChanceFactory : IGeneFactory
    {
        private Random RNG { get; set; }

        /// <summary>
        /// A list of gene presets to pull from, and then randomize the stats.
        /// </summary>
        private List<Gene> AllGenes { get; set; }

        private DungeonGenConfig DungeonConfig { get; set; }

        public RoomGenChanceFactory()
        {
            this.DungeonConfig = CoreSettingsHandler.DungeonGenerationConfig.Settings;
            this.RNG = new Random();
            this.AllGenes = new List<Gene>();
            this.GenerateAllGeneTypes();
        }

        private void GenerateAllGeneTypes()
        {
            this.GenerateBossRoomGenes();
            this.GenerateDescentRoomGenes();
            this.GenerateHallwayGenes();
            this.GenerateMinionRoomGenes();
            this.GenerateStandardRoomGenes();
            this.GenerateTreasureRoomGenes();
        }

        private void GenerateBossRoomGenes()
        {
            this.AddGeneIf(this.DungeonConfig.CanBossRoomBeAdjacentToBossRoom, DungeonNodeType.BossRoom, DungeonNodeType.BossRoom);
            this.AddGeneIf(this.DungeonConfig.CanBossRoomBeAdjacentToDescentRoom, DungeonNodeType.BossRoom, DungeonNodeType.DescentRoom);
            this.AddGeneIf(this.DungeonConfig.CanBossRoomBeAdjacentToEntranceRoom, DungeonNodeType.BossRoom, DungeonNodeType.EntranceRoom);
            this.AddGeneIf(this.DungeonConfig.CanBossRoomBeAdjacentToHallway, DungeonNodeType.BossRoom, DungeonNodeType.Hallway);
            this.AddGeneIf(this.DungeonConfig.CanBossRoomBeAdjacentToMinionRoom, DungeonNodeType.BossRoom, DungeonNodeType.MinionRoom);
            this.AddGeneIf(this.DungeonConfig.CanBossRoomBeAdjacentToStandardRoom, DungeonNodeType.BossRoom, DungeonNodeType.StandardRoom);
            this.AddGeneIf(this.DungeonConfig.CanBossRoomBeAdjacentToTreasureRoom, DungeonNodeType.BossRoom, DungeonNodeType.TreasureRoom);
        }

        private void GenerateDescentRoomGenes()
        {
            this.AddGeneIf(this.DungeonConfig.CanBossRoomBeAdjacentToDescentRoom, DungeonNodeType.DescentRoom, DungeonNodeType.BossRoom);
            this.AddGeneIf(this.DungeonConfig.CanDescentRoomBeAdjacentToDescentRoom, DungeonNodeType.DescentRoom, DungeonNodeType.DescentRoom);
            this.AddGeneIf(this.DungeonConfig.CanDescentRoomBeAdjacentToEntranceRoom, DungeonNodeType.DescentRoom, DungeonNodeType.EntranceRoom);
            this.AddGeneIf(this.DungeonConfig.CanDescentRoomBeAdjacentToHallway, DungeonNodeType.DescentRoom, DungeonNodeType.Hallway);
            this.AddGeneIf(this.DungeonConfig.CanDescentRoomBeAdjacentToMinionRoom, DungeonNodeType.DescentRoom, DungeonNodeType.MinionRoom);
            this.AddGeneIf(this.DungeonConfig.CanDescentRoomBeAdjacentToStandardRoom, DungeonNodeType.DescentRoom, DungeonNodeType.StandardRoom);
            this.AddGeneIf(this.DungeonConfig.CanDescentRoomBeAdjacentToTreasureRoom, DungeonNodeType.DescentRoom, DungeonNodeType.TreasureRoom);
        }

        private void GenerateHallwayGenes()
        {
            this.AddGeneIf(this.DungeonConfig.CanBossRoomBeAdjacentToHallway, DungeonNodeType.Hallway, DungeonNodeType.BossRoom);
            this.AddGeneIf(this.DungeonConfig.CanDescentRoomBeAdjacentToHallway, DungeonNodeType.Hallway, DungeonNodeType.DescentRoom);
            this.AddGeneIf(this.DungeonConfig.CanHallwayBeAdjacentToEntranceRoom, DungeonNodeType.Hallway, DungeonNodeType.EntranceRoom);
            this.AddGeneIf(this.DungeonConfig.CanHallwayBeAdjacentToHallway, DungeonNodeType.Hallway, DungeonNodeType.Hallway);
            this.AddGeneIf(this.DungeonConfig.CanHallwayRoomBeAdjacentToMinionRoom, DungeonNodeType.Hallway, DungeonNodeType.MinionRoom);
            this.AddGeneIf(this.DungeonConfig.CanHallwayRoomBeAdjacentToStandardRoom, DungeonNodeType.Hallway, DungeonNodeType.StandardRoom);
            this.AddGeneIf(this.DungeonConfig.CanHallwayRoomBeAdjacentToTreasureRoom, DungeonNodeType.Hallway, DungeonNodeType.TreasureRoom);
        }

        private void GenerateMinionRoomGenes()
        {
            this.AddGeneIf(this.DungeonConfig.CanBossRoomBeAdjacentToMinionRoom, DungeonNodeType.MinionRoom, DungeonNodeType.BossRoom);
            this.AddGeneIf(this.DungeonConfig.CanDescentRoomBeAdjacentToMinionRoom, DungeonNodeType.MinionRoom, DungeonNodeType.DescentRoom);
            this.AddGeneIf(this.DungeonConfig.CanMinionRoomBeAdjacentToEntranceRoom, DungeonNodeType.MinionRoom, DungeonNodeType.EntranceRoom);
            this.AddGeneIf(this.DungeonConfig.CanHallwayRoomBeAdjacentToMinionRoom, DungeonNodeType.MinionRoom, DungeonNodeType.Hallway);
            this.AddGeneIf(this.DungeonConfig.CanMinionRoomBeAdjacentToMinionRoom, DungeonNodeType.MinionRoom, DungeonNodeType.MinionRoom);
            this.AddGeneIf(this.DungeonConfig.CanMinionRoomBeAdjacentToStandardRoom, DungeonNodeType.MinionRoom, DungeonNodeType.StandardRoom);
            this.AddGeneIf(this.DungeonConfig.CanMinionRoomBeAdjacentToTreasureRoom, DungeonNodeType.MinionRoom, DungeonNodeType.TreasureRoom);
        }

        private void GenerateStandardRoomGenes()
        {
            this.AddGeneIf(this.DungeonConfig.CanBossRoomBeAdjacentToStandardRoom, DungeonNodeType.StandardRoom, DungeonNodeType.BossRoom);
            this.AddGeneIf(this.DungeonConfig.CanDescentRoomBeAdjacentToStandardRoom, DungeonNodeType.StandardRoom, DungeonNodeType.DescentRoom);
            this.AddGeneIf(this.DungeonConfig.CanStandardRoomBeAdjacentToEntranceRoom, DungeonNodeType.StandardRoom, DungeonNodeType.EntranceRoom);
            this.AddGeneIf(this.DungeonConfig.CanHallwayRoomBeAdjacentToStandardRoom, DungeonNodeType.StandardRoom, DungeonNodeType.Hallway);
            this.AddGeneIf(this.DungeonConfig.CanMinionRoomBeAdjacentToStandardRoom, DungeonNodeType.StandardRoom, DungeonNodeType.MinionRoom);
            this.AddGeneIf(this.DungeonConfig.CanStandardRoomBeAdjacentToStandardRoom, DungeonNodeType.StandardRoom, DungeonNodeType.StandardRoom);
            this.AddGeneIf(this.DungeonConfig.CanStandardRoomBeAdjacentToTreasureRoom, DungeonNodeType.StandardRoom, DungeonNodeType.TreasureRoom);
        }

        private void GenerateTreasureRoomGenes()
        {
            this.AddGeneIf(this.DungeonConfig.CanBossRoomBeAdjacentToTreasureRoom, DungeonNodeType.TreasureRoom, DungeonNodeType.BossRoom);
            this.AddGeneIf(this.DungeonConfig.CanDescentRoomBeAdjacentToTreasureRoom, DungeonNodeType.TreasureRoom, DungeonNodeType.DescentRoom);
            this.AddGeneIf(this.DungeonConfig.CanTreasureRoomBeAdjacentToEntranceRoom, DungeonNodeType.TreasureRoom, DungeonNodeType.EntranceRoom);
            this.AddGeneIf(this.DungeonConfig.CanHallwayRoomBeAdjacentToTreasureRoom, DungeonNodeType.TreasureRoom, DungeonNodeType.Hallway);
            this.AddGeneIf(this.DungeonConfig.CanMinionRoomBeAdjacentToTreasureRoom, DungeonNodeType.TreasureRoom, DungeonNodeType.MinionRoom);
            this.AddGeneIf(this.DungeonConfig.CanStandardRoomBeAdjacentToTreasureRoom, DungeonNodeType.TreasureRoom, DungeonNodeType.StandardRoom);
            this.AddGeneIf(this.DungeonConfig.CanTreasureRoomBeAdjacentToTreasureRoom, DungeonNodeType.TreasureRoom, DungeonNodeType.TreasureRoom);
        }

        public Gene[] GenerateGenes(int length)
        {
            Gene[] genes = new Gene[length];

            for (int i = 0; i < length; i++)
            {
                int templateGeneIndex = i % this.AllGenes.Count;
                Gene templateGene = this.AllGenes[templateGeneIndex];
                genes[i] = this.Randomize(templateGene);
            }

            return genes;
        }

        private Gene Randomize(Gene gene)
        {
            RoomGenChance value = (RoomGenChance)gene.Value;
            value.ChanceToGenerate = this.RNG.NextDouble();
            gene.Value = value;
            return gene;
        }

        public Gene[] GenerateGenes()
        {
            return this.GenerateGenes(this.AllGenes.Count);
        }

        private void AddGeneIf(bool shouldAdd, DungeonNodeType typeToGenerate, DungeonNodeType typeToGenerateOn)
        {
            if (shouldAdd)
            {
                Gene gene = this.GenerateSingleGene(typeToGenerate, typeToGenerateOn);
                this.AllGenes.Add(gene);
            }
        }

        private Gene GenerateSingleGene(DungeonNodeType typeToGenerate, DungeonNodeType typeToGenerateOn)
        {
            RoomGenChance roomGenGene = new RoomGenChance(typeToGenerate, typeToGenerateOn, this.RNG.NextDouble());
            Gene gene = new Gene(roomGenGene);
            return gene;
        }
    }
}
