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

        private IGeneFactory GeneFactory { get; set; }

        public Gene[] Genes { get; set; }

        public Chromosome(int length, IGeneFactory geneFactory)
        {
            this.Length = length;
            this.GeneFactory = geneFactory;
            this.GenerateGenes(this.Length);
        }

        protected Chromosome()
        {
        }

        public Gene[] GenerateGenes(int length)
        {
            return this.GeneFactory.GenerateGenes(length);
        }
    }
}
