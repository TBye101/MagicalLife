using System;
using System.Collections.Generic;
using System.Text;

namespace MLAPI.Genetic.Reinsertions
{
    /// <summary>
    /// Reinserts all offspring.
    /// If there is room for the parents, they will be added as well.
    /// Any remaining population slots are created with new random chromosomes.
    /// </summary>
    public class ReplaceThenGenerate : IReinsertion
    {
        private IGeneFactory GeneFactory { get; set; }

        public ReplaceThenGenerate(IGeneFactory factory)
        {
            this.GeneFactory = factory;
        }

        public void Reinsert(List<Chromosome> parents, List<Chromosome> offspring, Population population)
        {
            population.Chromosomes.Clear();
            population.Chromosomes.AddRange(offspring);

            int numberOfParentsToTake = population.FullSize - population.Chromosomes.Count;
            if (numberOfParentsToTake > 0)
            {
                population.Chromosomes.AddRange(parents.GetRange(0, numberOfParentsToTake));
            }

            int numberToGenerate = population.FullSize - population.Chromosomes.Count;

            Chromosome generatorChromosome = offspring[0];

            for (int i = 0; i < numberToGenerate; i++)
            {
                Chromosome newChromosome = generatorChromosome.NewChromosome(this.GeneFactory);
                population.Chromosomes.Add(newChromosome);
            }
        }
    }
}
