using System;
using System.Collections.Generic;
using System.Text;

namespace MLAPI.Genetic
{
    public static class GeneticUtil
    {
        public static List<Chromosome> GenerateChromosomes(int count, IGeneFactory factory)
        {
            List<Chromosome> chromosomes = new List<Chromosome>();

            for (int i = 0; i < count; i++)
            {
                Chromosome newChromosome = new Chromosome(factory.GenerateGenes(10));
                chromosomes.Add(newChromosome);
            }

            return chromosomes;
        }
    }
}
