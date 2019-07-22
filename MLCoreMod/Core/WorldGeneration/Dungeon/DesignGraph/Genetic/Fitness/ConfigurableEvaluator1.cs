using MagicalLifeAPI.Filing.Logging;
using MLAPI.Genetic;
using MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic.Fitness;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic.FitnessEvaluators
{
    public class ConfigurableEvaluator1 : IFitness
    {
        private List<FitnessRule> ScoringRules;

        public ConfigurableEvaluator1()
        {
            this.ScoringRules = new List<FitnessRule>
            {
                new TreasureRoomRequiresBossRoomRule()
            };
        }

        public double CalculateFitness(Chromosome chromosome)
        {
            throw new NotImplementedException();
        }

        public double Evaluate(IChromosome chromosome)
        {
            DungeonCapabilitiesChromosome dungeonCapabilities = chromosome as DungeonCapabilitiesChromosome;

            if (dungeonCapabilities == null)
            {
                return 0;
            }
            else
            {
                double totalPointsAvailible = 0;
                double pointsScored = 0;
                DungeonNode dungeonDesign = dungeonCapabilities.GenerateDungeonDesign();

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
}
