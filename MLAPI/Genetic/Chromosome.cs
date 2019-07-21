using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLAPI.Genetic
{
    /// <summary>
    /// Holds a group of genes.
    /// </summary>
    public class Chromosome
    {
        public int Length { get; private set; }

        public double? Fitness {get; set;}

        public Gene[] Genes { get; set; }

        public Chromosome(Gene[] genes)
        {
            this.Length = genes.Length;
            this.Genes = genes;
        }

        protected Chromosome()
        {
        }

        public Chromosome NewChromosome(IGeneFactory factory)
        {
            return new Chromosome(factory.GenerateGenes(this.Length));
        }
    }
}
