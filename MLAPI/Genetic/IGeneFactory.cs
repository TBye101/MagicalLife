using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLAPI.Genetic
{
    /// <summary>
    /// Used to generate genes.
    /// </summary>
    public interface IGeneFactory
    {
        /// <summary>
        /// Generates a set number of genes.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        Gene[] GenerateGenes(int length);
        
        /// <summary>
        /// Generates a recommended number of genes.
        /// </summary>
        /// <returns></returns>
        Gene[] GenerateGenes();
    }
}
