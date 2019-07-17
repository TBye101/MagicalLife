using GeneticSharp.Domain;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Domain.Terminations;
using MagicalLifeAPI.Error.InternalExceptions;
using MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic;
using MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic.FitnessEvaluators;
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
            OrderedCrossover crossover = new OrderedCrossover();
            ReverseSequenceMutation mutation = new ReverseSequenceMutation();//Not good
            ConfigurableEvaluator1 fitness = new ConfigurableEvaluator1();
            DungeonCapabilitiesChromosome chromosome = new DungeonCapabilitiesChromosome();
            Population population = new Population(50, 100, chromosome);
            GeneticAlgorithm geneticAlgorithm = new GeneticAlgorithm(population, fitness, selection, crossover, mutation);
            geneticAlgorithm.Termination = new GenerationNumberTermination(100);
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
    }
}
