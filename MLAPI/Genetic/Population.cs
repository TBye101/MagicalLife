using System;
using System.Collections.Generic;
using System.Text;

namespace MLAPI.Genetic
{
    /// <summary>
    /// Holds a number of chromosomes from the same generation.
    /// </summary>
    public class Population
    {
        public List<Chromosome> Chromosomes { get; set; }
        public int Generation { get; set; }

        /// <summary>
        /// The size of the population when fully created, and not in the middle of selection operations.
        /// </summary>
        public int FullSize { get; set; }

        public Population(List<Chromosome> chromosomes, int size)
        {
            this.Chromosomes = chromosomes;
            this.Generation = 0;
            this.FullSize = size;
        }
    }
}
