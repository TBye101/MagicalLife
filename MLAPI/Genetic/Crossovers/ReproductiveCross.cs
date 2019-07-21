using MagicalLifeAPI.Error.InternalExceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLAPI.Genetic.Crossovers
{
    /// <summary>
    /// Generates offspring by reproducing genes in the same array position in both chromosomes. 
    /// </summary>
    public class ReproductiveCross : ICrossover
    {
        public List<Chromosome> CrossParents(List<Chromosome> parents)
        {
            List<Chromosome> offspring = new List<Chromosome>();

            for (int i = parents.Count - 1; i > 0; i -= 2)
            {
                Chromosome parent1 = parents[i];
                Chromosome parent2 = parents[i - 1];
                Chromosome child = this.Reproduce(parent1, parent2);
                offspring.Add(child);
            }

            return offspring;
        }

        private Chromosome Reproduce(Chromosome a, Chromosome b)
        {
            int chromosomeLength = Math.Max(a.Length, b.Length);
            Gene[] childGenes = new Gene[chromosomeLength];

            for (int i = 0; i < chromosomeLength; i++)
            {
                if (i < a.Length && i < b.Length)
                {
                    Gene aGene = a.Genes[i];
                    Gene bGene = b.Genes[i];

                    if (aGene.CanReproduce(bGene))
                    {
                        childGenes[i] = aGene.Reproduce(aGene, bGene);
                    }
                    else
                    {
                        throw new UnexpectedStateException("An attempt was made to cross two incompatible genes");
                    }
                }
                else
                {
                    //Chromosomes have a different gene length.
                    throw new UnexpectedStateException("An attempt was made to cross two chromosomes of differing lengths in a reproductive cross that depends upon gene position.");
                }
            }

            return new Chromosome(childGenes);
        }
    }
}
