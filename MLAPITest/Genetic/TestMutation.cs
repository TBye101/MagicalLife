using MLAPI.Genetic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLAPITest.Genetic
{
    public class TestMutation : IMutation
    {
        public void MutateChromosomes(List<Chromosome> chromosomes)
        {
            Random r = new Random();

            for (int i = 0; i < chromosomes.Count; i++)
            {
                Chromosome chromo = chromosomes[i];

                int randomNumber = r.Next(0, 100);

                if (randomNumber < 20)
                {
                    int randomIndex = r.Next(0, chromo.Genes.Length);
                    chromo.Genes[randomIndex].Value = r.Next(0, 100);
                }
            }
        }
    }
}
