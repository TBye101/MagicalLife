using MagicalLifeAPI.Filing.Logging;
using MLAPI.Genetic;
using MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic.Fitness;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic.Fitness
{
    public class ConfigurableEvaluator1 : IFitness
    {
        private List<FitnessRule> ScoringRules { get; set; }

        private DungeonDesigner Designer { get; set; }

        public ConfigurableEvaluator1(DungeonDesigner designer)
        {
            this.ScoringRules = new List<FitnessRule>
            {
                new TreasureRoomRequiresBossRoomRule()
            };
            this.Designer = designer;
        }

        public double CalculateFitness(Chromosome chromosome)
        {
            double totalPointsAvailible = 0;
            double pointsScored = 0;
            DungeonNode dungeonDesign = this.Designer.GetDungeonDesign(chromosome);

            for (int i = 0; i < this.ScoringRules.Count; i++)
            {
                FitnessRule rule = this.ScoringRules[i];
                totalPointsAvailible += rule.GetTotalPoints(dungeonDesign);
                pointsScored += rule.GetCurrentPoints(dungeonDesign);
            }

            return pointsScored / totalPointsAvailible;
        }
    }
}
