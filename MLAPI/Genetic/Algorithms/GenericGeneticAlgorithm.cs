using System;
using System.Collections.Generic;
using System.Text;

namespace MLAPI.Genetic.Algorithms
{
    public class GenericGeneticAlgorithm : GeneticAlgorithm
    {
        public GenericGeneticAlgorithm(IFitness fitness, ICrossover crossover, ISelection selection, ITermination termination, 
            IMutation mutation, IReinsertion reinsertion, int populationSize, float crossoverProbability, float mutationProbability,
            Chromosome chromosome, IGeneFactory geneFactory)
            : base(fitness, crossover, selection, termination, mutation, reinsertion, geneFactory, GeneratePopulation(chromosome, populationSize, geneFactory), crossoverProbability, mutationProbability)
        {
        }

        private static Population GeneratePopulation(Chromosome chromosome, int populationSize, IGeneFactory factory)
        {
            List<Chromosome> initialPopulation = new List<Chromosome>();

            for (int i = 0; i < populationSize; i++)
            {
                initialPopulation.Add(chromosome.NewChromosome(factory));
            }

            return new Population(initialPopulation, populationSize);
        }

        public override void Start()
        {
            while (!this.Termination.ShouldStopEvolving(this))
            {
                this.RunGeneration();
                this.Pop.Generation++;
            }
        }

        private void RunGeneration()
        {
            this.CalculateFitness();
            List<Chromosome> selectedParents = this.Selection.SelectParents(this.Pop);
            List<Chromosome> offSpring = this.Crossover.CrossParents(selectedParents);
            this.Mutation.MutateChromosomes(offSpring);
            this.Reinsertion.Reinsert(selectedParents, offSpring, this.Pop);
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
