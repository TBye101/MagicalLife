using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLAPI.Genetic;
using MLAPI.Genetic.Crossovers;
using MLAPI.Genetic.Selections;
using System;
using System.Collections.Generic;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace MLAPITest.Genetic.Crossovers
{
    public class KPointCrossoverTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void CrossParents_StateUnderTest_ExpectedBehavior(int k)
        {
            // Arrange
            List<Chromosome> initialPopulation = GeneticTestUtil.GenerateChromosomes(100);
            Population pop = new Population(initialPopulation, 100);
            KPointCrossover kPointCrossover = new KPointCrossover(k);
            ISelection selection = new PercentSelection(.1F);
            List<Chromosome> parents = selection.SelectParents(pop);

            // Act
            List<Chromosome> result = kPointCrossover.CrossParents(parents);

            // Assert
            Assert.IsNotNull(initialPopulation);
            Assert.IsNotNull(pop);
            Assert.IsNotNull(pop.Chromosomes);
            Assert.IsNotNull(kPointCrossover);
            Assert.IsNotNull(selection);
            Assert.IsNotNull(parents);
            Assert.IsNotNull(result);

            GeneticTestUtil.ValidateChromosomes(initialPopulation);
            GeneticTestUtil.ValidateChromosomes(parents);
            GeneticTestUtil.ValidateChromosomes(result);
        }
    }
}
