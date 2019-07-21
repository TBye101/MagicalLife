using System;
using System.Collections.Generic;
using System.Text;

namespace MLAPI.Genetic
{
    /// <summary>
    /// Handles how to reinsert offspring and parents into a generation.
    /// </summary>
    public interface IReinsertion
    {
        void Reinsert(List<Chromosome> parents, List<Chromosome> offspring, Population population);
    }
}
