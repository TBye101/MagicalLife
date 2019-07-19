using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Mutations;
using MagicalLifeAPI.Error.InternalExceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic.Mutations
{
    /// <summary>
    /// Requires the genes stored within the chromosome to be a <see cref="Capability"/>.
    /// </summary>
    public class CapabilityMutation : MutationBase
    {
        public CapabilityMutation()
        {
        }

        protected override void PerformMutate(IChromosome chromosome, float probability)
        {
            Random r = new Random();
            double randomNumber = r.NextDouble();
            
            if (randomNumber < probability)
            {
                int mutationIndex = r.Next(0, chromosome.Length);
                Gene mutatedGene = chromosome.GetGene(mutationIndex);
                Capability capability = mutatedGene.Value as Capability;

                if (capability == null)
                {
                    throw new UnexpectedStateException();
                }
                else
                {
                    capability.Mutate();
                    chromosome.ReplaceGene(mutationIndex, mutatedGene);
                }
            }
        }
    }
}
