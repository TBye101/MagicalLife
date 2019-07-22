using MLAPI.Genetic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLAPITest.Genetic
{
    public class TestGeneFactory : IGeneFactory
    {
        public Gene[] GenerateGenes(int length)
        {
            Gene[] genes = new Gene[length];

            Random r = new Random();

            for (int i = 0; i < genes.Length; i++)
            {
                genes[i] = new Gene(r.Next(0, 100));
            }

            return genes;
        }
    }
}
