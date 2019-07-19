using System;
using System.Collections.Generic;
using System.Text;

namespace MLAPI.Genetic.Algorithms
{
    public class GenericGeneticAlgorithm : GeneticAlgorithm
    {
        public GenericGeneticAlgorithm(IFitness fitness, ICrossover crossover, ISelection selection, ITermination termination, IMutation mutation, Population population, float crossoverProbability, float mutationProbability)
            : base(fitness, crossover, selection, termination, mutation, population, crossoverProbability, mutationProbability)
        {
        }

        public override void Start()
        {
            this.GenerateInitialPopulation();

            while (!this.Termination.ShouldStopEvolving(this))
            {
                this.RunGeneration();
            }
        }

        private void RunGeneration()
        {
            this.CalculateFitness();
            List<Chromosome> selectedParents = this.Selection.SelectParents(this.Pop);
            List<Chromosome> offSpring = this.Crossover.CrossParents(selectedParents);
            this.Mutation.MutateChromosomes(offSpring);
        }

        private void GenerateInitialPopulation()
        {

        }

        /// <summary>
        /// Calculates the fitness of the population.
        /// </summary>
        private void CalculateFitness()
        {
            for (int i = 0; i < this.Pop.Chromosomes.Count; i++)
            {
                Chromosome chromosome = this.Pop.Chromosomes[i];

                if (!chromosome.Fitness.HasValue)
                {
                    chromosome.Fitness = this.Fitness.CalculateFitness(chromosome);
                }

                if (this.BestChromosome == null || this.BestChromosome.Fitness < chromosome.Fitness)
                {
                    this.BestChromosome = chromosome;
                }
            }
        }
    }
}
