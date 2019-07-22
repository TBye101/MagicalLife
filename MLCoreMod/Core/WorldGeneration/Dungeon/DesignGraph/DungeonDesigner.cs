using MagicalLifeAPI.Error.InternalExceptions;
using MagicalLifeAPI.Filing.Logging;
using MLAPI.Genetic;
using MLAPI.Genetic.Algorithms;
using MLAPI.Genetic.Crossovers;
using MLAPI.Genetic.Reinsertions;
using MLAPI.Genetic.Selections;
using MLAPI.Genetic.Terminations;
using MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic;
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
        private static readonly int populationSize = 100;
        private static readonly float selectTopPercent = .1F;
        private static readonly int crossoverPoints = 2;
        private static readonly float mutationChance = .2F;
        private static readonly int terminationGeneration = 10;

        public DungeonNode DesignDungeon()
        {
            IGeneFactory geneFactory = null;
            Chromosome initialPopulation = new Chromosome(geneFactory.GenerateGenes());

            ISelection selection = new PercentSelection(selectTopPercent);
            ICrossover crossover = new KPointCrossover(crossoverPoints, initialPopulation.Genes.Length);
            IMutation mutation = new RoomGenChanceMutator(mutationChance);
            IFitness fitness = new ConfigurableEvaluator1();
            IReinsertion reinsertion = new ReplaceThenGenerate(geneFactory);
            ITermination termination = new GenerationCountTermination(terminationGeneration);

            GeneticAlgorithm algorithm =
                new GenericGeneticAlgorithm(fitness, crossover, selection, termination, mutation, reinsertion, populationSize,
                initialPopulation, geneFactory);

            algorithm.Start();

            //GeneticAlgorithm geneticAlgorithm = new GeneticAlgorithm(population, fitness, selection, crossover, mutation);
            //geneticAlgorithm.Termination = new GenerationNumberTermination(1000);
            //geneticAlgorithm.MutationProbability = .7F;
            //geneticAlgorithm.GenerationRan += this.GeneticAlgorithm_GenerationRan;
            //geneticAlgorithm.Start();
            //DungeonCapabilitiesChromosome bestChromosome = geneticAlgorithm.BestChromosome as DungeonCapabilitiesChromosome;

            if (algorithm.BestChromosome == null)
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
