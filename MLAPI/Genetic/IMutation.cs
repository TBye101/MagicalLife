using System;
using System.Collections.Generic;
using System.Text;

namespace MLAPI.Genetic
{
    public interface IMutation
    {
        void MutateChromosomes(List<Chromosome> chromosomes);
    }
}
