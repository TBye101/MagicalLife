using System;
using System.Collections.Generic;
using System.Text;

namespace MLAPI.Genetic
{
    /// <summary>
    /// Represents some genetic information that is utilized in a genetic algorithm.
    /// </summary>
    public abstract class Gene
    {
        /// <summary>
        /// If true, then this gene can reproduce with the specified gene.
        /// </summary>
        /// <param name="gene"></param>
        /// <returns></returns>
        public abstract bool CanReproduce(Gene gene);

        /// <summary>
        /// Returns the child of the two genes.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public abstract Gene Reproduce(Gene a, Gene b);
    }
}
