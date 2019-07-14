using MagicalLifeAPI.Error.InternalExceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic.Capabilities
{
    public class ChanceBasedCapability : Capability
    {
        private double GenerationChanceOnBossRoom;
        private double GenerationChanceOnDescentRoom;
        private double GenerationChanceOnEntranceRoom;
        private double GenerationChanceOnHallway;
        private double GenerationChanceOnMinionRoom;
        private double GenerationChanceOnStandardRoom;
        private double GenerationChanceOnTreasureRoom;

        private DungeonNodeType NodeTypeToCreate;

        private Random Rand = new Random();

        public ChanceBasedCapability(DungeonNodeType nodeTypeToCreate)
        {
            this.NodeTypeToCreate = nodeTypeToCreate;
        }

        public override void Activate(DungeonNode node)
        {
            switch (node.NodeType)
            {
                case DungeonNodeType.BossRoom:
                    this.MaybeAddToDesign(node, this.GenerationChanceOnBossRoom);
                    break;
                case DungeonNodeType.DescentRoom:
                    this.MaybeAddToDesign(node, this.GenerationChanceOnDescentRoom);
                    break;
                case DungeonNodeType.EntranceRoom:
                    this.MaybeAddToDesign(node, this.GenerationChanceOnEntranceRoom);
                    break;
                case DungeonNodeType.Hallway:
                    this.MaybeAddToDesign(node, this.GenerationChanceOnHallway);
                    break;
                case DungeonNodeType.MinionRoom:
                    this.MaybeAddToDesign(node, this.GenerationChanceOnMinionRoom);
                    break;
                case DungeonNodeType.StandardRoom:
                    this.MaybeAddToDesign(node, this.GenerationChanceOnStandardRoom);
                    break;
                case DungeonNodeType.TreasureRoom:
                    this.MaybeAddToDesign(node, this.GenerationChanceOnTreasureRoom);
                    break;
                default:
                    throw new UnexpectedStateException();
            }
        }

        private void MaybeAddToDesign(DungeonNode node, double chance)
        {
            double rn = this.Rand.NextDouble();
            bool addNode = rn < chance;

            if (addNode)
            {
                node.Connections.Add(new DungeonNode(this.NodeTypeToCreate, node.NodeDistance));
            }
        }

        public override void SetRandomStats()
        {
            this.GenerationChanceOnBossRoom = this.Rand.NextDouble();
            this.GenerationChanceOnDescentRoom = this.Rand.NextDouble();
            this.GenerationChanceOnEntranceRoom = this.Rand.NextDouble();
            this.GenerationChanceOnHallway = this.Rand.NextDouble();
            this.GenerationChanceOnMinionRoom = this.Rand.NextDouble();
            this.GenerationChanceOnStandardRoom = this.Rand.NextDouble();
            this.GenerationChanceOnTreasureRoom = this.Rand.NextDouble();
        }
    }
}
