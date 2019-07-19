using System;
using System.Collections.Generic;
using System.Text;

namespace MLAPI.Genetic
{
    /// <summary>
    /// Defines how fit a chromosome is.
    /// </summary>
    public interface IFitness
    {
        double CalculateFitness(Chromosome chromosome);
    }
}
