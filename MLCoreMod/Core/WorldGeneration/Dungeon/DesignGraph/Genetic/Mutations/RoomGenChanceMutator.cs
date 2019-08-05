using MLAPI.Genetic;
using System;
using System.Collections.Generic;
using System.Text;
using MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic.DesignRules;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic.Mutations
{
    class RoomGenChanceMutator : IMutation
    {
        private double ChanceToMutate { get; set; }

        private Random Rng { get; set; }

        public RoomGenChanceMutator(double chanceToMutate)
        {
            this.ChanceToMutate = chanceToMutate;
            this.Rng = new Random();
        }

        public void MutateChromosomes(List<Chromosome> chromosomes)
        {
            for (int i = 0; i < chromosomes.Count; i++)
            {
                Chromosome chromo = chromosomes[i];

                double randomNumber = this.Rng.NextDouble();

                if (randomNumber < this.ChanceToMutate)
                {
                    int randomIndex = this.Rng.Next(0, chromo.Genes.Length);
                    RoomGenChance geneValue = (RoomGenChance)chromo.Genes[randomIndex].Value;
                    geneValue.ChanceToGenerate = this.Rng.NextDouble();
                    chromo.Genes[randomIndex].Value = geneValue;
                }
            }
        }
    }
}
