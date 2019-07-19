using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Mutations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic.Mutations
{
    public class NoMutation : MutationBase
    {
        protected override void PerformMutate(IChromosome chromosome, float probability)
        {
            //No mutation is performed
        }
    }
}
