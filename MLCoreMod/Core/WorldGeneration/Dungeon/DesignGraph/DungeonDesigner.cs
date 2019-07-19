using GeneticSharp.Domain;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Domain.Terminations;
using MagicalLifeAPI.Error.InternalExceptions;
using MagicalLifeAPI.Filing.Logging;
using MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic;
using MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic.Crossover;
using MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic.FitnessEvaluators;
using MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic.Mutations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph
{
    /// <summary>
    /// Uses genetic algorithms to generate a dungeon based upon a set of rules.
    /// </summary>
    public class DungeonDesigner
    {
        public DungeonNode DesignDungeon()
        {
            EliteSelection selection = new EliteSelection();
            var crossover = new GeneSwapCrossover();
            var mutation = new CapabilityMutation();  
            ConfigurableEvaluator1 fitness = new ConfigurableEvaluator1();
            DungeonCapabilitiesChromosome chromosome = new DungeonCapabilitiesChromosome(7);
            Population population = new Population(50, 100, chromosome);
            GeneticAlgorithm geneticAlgorithm = new GeneticAlgorithm(population, fitness, selection, crossover, mutation);
            geneticAlgorithm.Termination = new GenerationNumberTermination(100000);
            geneticAlgorithm.MutationProbability = .7F;
            geneticAlgorithm.GenerationRan += this.GeneticAlgorithm_GenerationRan;
            geneticAlgorithm.Start();
            DungeonCapabilitiesChromosome bestChromosome = geneticAlgorithm.BestChromosome as DungeonCapabilitiesChromosome;

            if (bestChromosome == null)
            {
                throw new UnexpectedStateException();
            }
            else
            {
                return bestChromosome.GenerateDungeonDesign();
            }
        }

        private void GeneticAlgorithm_GenerationRan(object sender, EventArgs e)
        {
            GeneticAlgorithm geneticAlgorithm = sender as GeneticAlgorithm;

            if (geneticAlgorithm != null)
            {
                MasterLog.DebugWriteLine("Fittest chromosome: " + geneticAlgorithm.Population.BestChromosome.Fitness.ToString());
            }
        }
    }
}
