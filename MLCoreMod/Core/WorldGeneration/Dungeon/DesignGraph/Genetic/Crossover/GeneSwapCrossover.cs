using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Crossovers;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic.Crossover
{
    /// <summary>
    /// Constructs children by randomly picking between both parents genes at the same position.
    /// </summary>
    public class GeneSwapCrossover : CrossoverBase
    {
        public GeneSwapCrossover() 
            : base(2, 2)
        {
        }

        protected override IList<IChromosome> PerformCross(IList<IChromosome> parents)
        {
            List<IChromosome> chromosomes = new List<IChromosome>();

            for (int i = parents.Count - 1; i > 0; i -= 2)
            {
                IChromosome parent1 = parents[i];
                IChromosome parent2 = parents[i - 1];
                IChromosome child1 = parent1.Clone();
                IChromosome child2 = parent2.Clone();

                Gene[] parent1Genes = parent1.GetGenes();
                Gene[] parent2Genes = parent2.GetGenes();
                Gene[] child1Genes = this.RandomPick<Gene>(parent1Genes, parent2Genes);
                Gene[] child2Genes = this.RandomPick<Gene>(parent1Genes, parent2Genes);

                this.SetGenes(child1, child1Genes);
                this.SetGenes(child2, child2Genes);

                chromosomes.Add(child1);
                chromosomes.Add(child2);
            }

            return chromosomes;
        }

        private void SetGenes(IChromosome chromosome, Gene[] genes)
        {
            if (chromosome.Length != genes.Length)
            {
                chromosome.Resize(genes.Length);
            }
            chromosome.ReplaceGenes(0, genes);
        }

        /// <summary>
        /// At each index this function picks randomly between the two arrays.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private T[] RandomPick<T>(T[] a, T[] b)
        {
            int length = Math.Max(a.Length, b.Length);
            T[] ret = new T[length];
            Random r = new Random();

            for (int i = 0; i < length; i++)
            {
                if (a.Length >= length && b.Length >= length)
                {
                    //Pick random
                    int randomNumber = r.Next(2);

                    if (randomNumber == 1)
                    {
                        ret[i] = a[i];
                    }
                    else
                    {
                        ret[i] = b[i];
                    }
                }
                else
                {
                    //Take from whichever parent has the gene at the index.
                    if (a.Length >= length)
                    {
                        ret[i] = a[i];
                    }
                    else
                    {
                        ret[i] = b[i];
                    }
                }
            }

            return ret;
        }
    }
}
