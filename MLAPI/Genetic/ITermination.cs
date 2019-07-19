using System;
using System.Collections.Generic;
using System.Text;

namespace MLAPI.Genetic
{
    public interface ITermination
    {
        bool ShouldStopEvolving(GeneticAlgorithm algorithm);
    }
}
