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
        public IReinsertion Reinsertion { get; set; }

        public Population Pop { get; set; }
        public Chromosome BestChromosome { get; set; }

        /// <summary>
        /// Should be raised whenever a genetic cycle has been completed.
        /// </summary>
        public event EventHandler<GeneticAlgorithm> GenerationEvolved;

        public GeneticAlgorithm(
            IFitness fitness, ICrossover crossover, ISelection selection, ITermination termination,
            IMutation mutation, IReinsertion reinsertion, Population population)
        {
            this.Fitness = fitness;
            this.Crossover = crossover;
            this.Selection = selection;
            this.Termination = termination;
            this.Pop = population;
            this.Mutation = mutation;
            this.Reinsertion = reinsertion;
        }

        public abstract void Start();

        public void RaiseGenerationChange(GeneticAlgorithm algorithm)
        {
            this.GenerationEvolved?.Invoke(algorithm, algorithm);
        }
    }
}
