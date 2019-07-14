using GeneticSharp.Domain.Chromosomes;
using MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic.Capabilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic
{
    public class DungeonCapabilitiesChromosome : IChromosome
    {
        public double? Fitness { get; set; }

        public int Length { get; }

        Gene[] Genes { get; set; }

        public DungeonCapabilitiesChromosome()
        {

        }

        private DungeonCapabilitiesChromosome(Gene[] genes, int length, double? fitness)
        {
            this.Genes = genes;
            this.Length = length;
            this.Fitness = fitness;
        }

        public IChromosome Clone()
        {
            return new DungeonCapabilitiesChromosome(this.Genes, this.Length, this.Fitness);
        }

        public int CompareTo(IChromosome other)
        {
            if (other == null)
            {
                return -1;
            }


            if (this.Fitness == other.Fitness)
            {
                return 0;
            }

            if (this.Fitness > other.Fitness)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public IChromosome CreateNew()
        {
            return new DungeonCapabilitiesChromosome();
        }

        public Gene GenerateGene(int geneIndex)
        {
            int chanceBasedCap = geneIndex % 7;
            Gene gene = new Gene(new ChanceBasedCapability((DungeonNodeType)chanceBasedCap));
            return gene;
        }

        public Gene GetGene(int index)
        {
            return this.Genes[index];
        }

        public Gene[] GetGenes()
        {
            return this.Genes;
        }

        public void ReplaceGene(int index, Gene gene)
        {
            this.Genes[index] = gene;
        }

        public void ReplaceGenes(int startIndex, Gene[] genes)
        {
            Array.Copy(genes, 0, this.Genes, startIndex, genes.Length);
        }

        public void Resize(int newLength)
        {
            Gene[] newGenes = new Gene[newLength];
            Array.Copy(this.Genes, newGenes, this.Genes.Length);
            this.Genes = newGenes;
        }
    }
}