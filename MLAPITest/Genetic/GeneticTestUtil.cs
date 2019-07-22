using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLAPI.Genetic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLAPITest.Genetic
{
    public static class GeneticTestUtil
    {
        public static List<Chromosome> GenerateChromosomes(int count)
        {
            TestGeneFactory factory = new TestGeneFactory();
            List<Chromosome> chromosomes = new List<Chromosome>();

            for (int i = 0; i < count; i++)
            {
                Chromosome newChromosome = new Chromosome(factory.GenerateGenes(10));
                chromosomes.Add(newChromosome);
            }

            return chromosomes;
        }

        public static void CalculateFitnesses(List<Chromosome> chromosomes, IFitness fitness)
        {
            foreach (Chromosome item in chromosomes)
            {
                item.Fitness = fitness.CalculateFitness(item);
            }
        }

        public static void ValidateChromosomes(List<Chromosome> chromosomes)
        {
            foreach (Chromosome item in chromosomes)
            {
                Assert.IsNotNull(item);
                Assert.IsNotNull(item.Genes);
                Assert.IsTrue(item.Fitness.HasValue);
                Assert.IsTrue(item.Length == item.Genes.Length);
                ValidateGenes(item.Genes);
            }
        }

        public static void ValidateGenes(Gene[] genes)
        {
            foreach (Gene item in genes)
            {
                Assert.IsNotNull(item);
                Assert.IsNotNull(item.Value);
            }
        }
    }
}
