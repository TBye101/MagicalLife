using GeneticSharp.Domain.Chromosomes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic
{
    internal class DungeonCapabilitiesChromosome : ChromosomeBase
    {
        public DungeonCapabilitiesChromosome() : base(10)
        {
        }

        public override IChromosome CreateNew()
        {
            return new DungeonCapabilitiesChromosome();
        }

        public override Gene GenerateGene(int geneIndex)
        {
            throw new NotImplementedException();
        }
    }
}