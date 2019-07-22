using MLAPI.Genetic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLAPITest.Genetic
{
    public class TestFitness : IFitness
    {
        public double CalculateFitness(Chromosome chromosome)
        {
            double total = 0;
            for (int i = 0; i < chromosome.Genes.Length; i++)
            {
                Gene gene = chromosome.Genes[i];
                int geneValue = (int)gene.Value;
                total += geneValue;
            }

            //             Number of genes divided by max value (100).
            return total / (10 * 100);
        }
    }
}
