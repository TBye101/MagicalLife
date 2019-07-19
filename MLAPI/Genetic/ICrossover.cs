using System;
using System.Collections.Generic;
using System.Text;

namespace MLAPI.Genetic
{
    public interface ICrossover
    {
        /// <summary>
        /// Generates offspring from the given parents.
        /// </summary>
        /// <param name="parents"></param>
        /// <returns></returns>
        List<Chromosome> CrossParents(List<Chromosome> parents);
    }
}
