using System;
using System.Collections.Generic;
using System.Text;

namespace MLAPI.Genetic.Terminations
{
    public class GenerationCountTermination : ITermination
    {
        private int Generation { get; set; }

        /// <param name="generation">The generation to terminate the evolution at.</param>
        public GenerationCountTermination(int generation)
        {
            this.Generation = generation;
        }

        public bool ShouldStopEvolving(GeneticAlgorithm algorithm)
        {
            return algorithm.Pop.Generation >= this.Generation;
        }
    }
}
