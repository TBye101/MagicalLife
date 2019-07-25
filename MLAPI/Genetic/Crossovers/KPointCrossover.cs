using MagicalLifeAPI.Error.InternalExceptions;
using MagicalLifeAPI.Util;
using MLAPI.Util.RandomUtils;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLAPI.Genetic.Crossovers
{
    /// <summary>
    /// Crosses genes between two chromosomes k times when producing offspring.
    /// </summary>
    public class KPointCrossover : ICrossover
    {
        private int K { get; set; }

        private NonDuplicateElementSelector<int> NonDuplicateRNG { get; set; }

        public KPointCrossover(int k, int genesCount)
        {
            this.K = k;
            this.NonDuplicateRNG = new NonDuplicateElementSelector<int>(ArrayUtil.FillNumericalRange(0, genesCount));
        }

        public List<Chromosome> CrossParents(List<Chromosome> parents)
        {
            List<Chromosome> offspring = new List<Chromosome>();

            for (int i = parents.Count - 1; i > 0; i -= 2)
            {
                Chromosome parent1 = parents[i];
                Chromosome parent2 = parents[i - 1];
                List<Chromosome> children = this.CrossTwoParents(parent1, parent2);

                offspring.AddRange(children);
            }

            return offspring;
        }

        private List<Chromosome> CrossTwoParents(Chromosome parent1, Chromosome parent2)
        {
            if (parent1.Genes.Length != parent2.Genes.Length)
            {
                throw new UnexpectedStateException("Unequal parent gene lengths detected in a crossover operation");
            }
            if (parent1.Genes.Length < this.K)
            {
                throw new UnexpectedStateException("More crossover points were requested for a crossover operation than there were genes");
            }

            List<int> crossPoints = this.GetCrossPoints();
            crossPoints.Sort((x, y) => x.CompareTo(y));

            Gene[] offspring1Genes = new Gene[parent1.Genes.Length];
            Gene[] offspring2Genes = new Gene[parent2.Genes.Length];

            Array.Copy(parent1.Genes, offspring1Genes, parent1.Genes.Length);
            Array.Copy(parent2.Genes, offspring2Genes, parent2.Genes.Length);

            while (crossPoints.Count > 0)
            {
                int location1 = crossPoints[0];

                if (crossPoints.Count > 1)
                {
                    int location2 = crossPoints[1];
                    crossPoints.RemoveAt(1);
                    ArrayUtil.SwapBetweenArrays(offspring1Genes, offspring2Genes, location1, location2);
                }
                else
                {
                    ArrayUtil.SwapBetweenArrays(offspring1Genes, offspring2Genes, location1, offspring1Genes.Length);
                }

                crossPoints.RemoveAt(0);
            }

            return new List<Chromosome>
            {
                new Chromosome(offspring1Genes),
                new Chromosome(offspring2Genes)
            };
        }

        private List<int> GetCrossPoints()
        {
            List<int> crossPoints = new List<int>();
            this.NonDuplicateRNG.Reset();

            for (int i = 0; i < this.K; i++)
            {
                crossPoints.Add(this.NonDuplicateRNG.GetRandomElement());
            }

            return crossPoints;
        }
    }
}
