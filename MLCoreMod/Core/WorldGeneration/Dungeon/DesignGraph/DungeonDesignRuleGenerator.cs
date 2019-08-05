using MLAPI.Genetic;
using MLAPI.Genetic.Algorithms;
using MLAPI.Genetic.Crossovers;
using MLAPI.Genetic.Reinsertions;
using MLAPI.Genetic.Selections;
using MLAPI.Genetic.Terminations;
using MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic;
using MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic.DesignGenerators;
using MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic.Fitness;
using MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic.Mutations;
using System;
using System.Collections.Generic;
using System.Text;
using MLAPI.Filing.Logging;
using MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic.GeneFactories;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph
{
    /// <summary>
    /// Uses genetic algorithms to select the best set of rules for generating a dungeon design graph that is bounded by set constraints.
    /// </summary>
    public class DungeonDesignRuleGenerator
    {
        private static readonly int PopulationSize = 100;
        private static readonly float SelectTopPercent = .1F;
        private static readonly int CrossoverPoints = 2;
        private static readonly float MutationChance = .2F;
        private static readonly int TerminationGeneration = 10;

        /// <summary>
        /// Gets a chromosome containing rules utilized to generate a dungeon design as bounded by specified constraints.
        /// </summary>
        /// <returns></returns>
        public Chromosome AdaptDungeonDesignRules()
        {
            IGeneFactory geneFactory = new RoomGenChanceFactory();
            Chromosome initialPopulation = new Chromosome(geneFactory.GenerateGenes());

            ISelection selection = new PercentSelection(SelectTopPercent);
            ICrossover crossover = new KPointCrossover(CrossoverPoints, initialPopulation.Genes.Length);
            IMutation mutation = new RoomGenChanceMutator(MutationChance);
            DungeonDesigner dungeonDesigner = new RoomGenChanceDesignGenerator();
            IFitness fitness = new ConfigurableEvaluator1(dungeonDesigner);
            IReinsertion reinsertion = new ReplaceThenGenerate(geneFactory);
            ITermination termination = new GenerationCountTermination(TerminationGeneration);

            GeneticAlgorithm algorithm =
                new GenericGeneticAlgorithm(fitness, crossover, selection, termination, mutation, reinsertion, PopulationSize,
                initialPopulation, geneFactory);
            algorithm.GenerationEvolved += this.Algorithm_GenerationChange;

            algorithm.Start();

            return algorithm.BestChromosome;
        }

        private void Algorithm_GenerationChange(object sender, GeneticAlgorithm e)
        {
            if (e != null)
            {
                MasterLog.DebugWriteLine("Fittest chromosome: " + e.BestChromosome.Fitness.ToString());
            }
        }
    }
}
