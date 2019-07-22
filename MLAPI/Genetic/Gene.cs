using System;
using System.Collections.Generic;
using System.Text;

namespace MLAPI.Genetic
{
    /// <summary>
    /// Represents some genetic information that is utilized in a genetic algorithm.
    /// </summary>
    public struct Gene
    {
        public object Value { get; set; }

        public Gene(object value)
        {
            this.Value = value;
        }
    }
}
