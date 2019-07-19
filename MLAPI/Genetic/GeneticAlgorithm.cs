using System;
using System.Collections.Generic;
using System.Text;

namespace MLAPI.Genetic
{
    /// <summary>
    /// A common interface for all genetic algorithms to implement.
    /// </summary>
    public abstract class GeneticAlgorithm
    {
        public IFitness Fitness { get; set; }
        public ICrossover Crossover { get; set; }
        public ISelection Selection { get; set; }
        public ITermination Termination { get; set; }
        public IMutation Mutation { get; set; }

        public float CrossoverProbability { get; set; }
        public float MutationProbability { get; set; }


        public Population Pop { get; set; }
        public Chromosome BestChromosome { get; set; }

        public GeneticAlgorithm(
            IFitness fitness, ICrossover crossover, ISelection selection, ITermination termination,
            IMutation mutation, Population population, float crossoverProbability, float mutationProbability)
        {
            this.Fitness = fitness;
            this.Crossover = crossover;
            this.Selection = selection;
            this.Termination = termination;
            this.Pop = population;
            this.Mutation = mutation;
            this.CrossoverProbability = crossoverProbability;
            this.MutationProbability = mutationProbability;
        }

        public abstract void Start();
    }
}
