using System;
using System.Collections.Generic;
using System.Text;

namespace MLAPI.Genetic
{
    public interface ISelection
    {
        /// <summary>
        /// Selects the chromosomes to be parents from the specified population.
        /// </summary>
        /// <param name="pop"></param>
        /// <returns></returns>
        List<Chromosome> SelectParents(Population pop);
    }
}
