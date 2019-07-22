using MLAPI.Genetic;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic.Mutations
{
    class RoomGenChanceMutator : IMutation
    {
        private double ChanceToMutate { get; set; }

        private Random RNG { get; set; }

        public RoomGenChanceMutator(double chanceToMutate)
        {
            this.ChanceToMutate = chanceToMutate;
            this.RNG = new Random();
        }

        public void MutateChromosomes(List<Chromosome> chromosomes)
        {
            for (int i = 0; i < chromosomes.Count; i++)
            {
                Chromosome chromo = chromosomes[i];

                double randomNumber = this.RNG.NextDouble();

                if (randomNumber < this.ChanceToMutate)
                {
                    int randomIndex = this.RNG.Next(0, chromo.Genes.Length);
                    RoomGenChance geneValue = (RoomGenChance)chromo.Genes[randomIndex].Value;
                    geneValue.ChanceToGenerate = this.RNG.NextDouble();
                    chromo.Genes[randomIndex].Value = geneValue;
                }
            }
        }
    }
}
