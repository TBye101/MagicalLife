using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLAPI.Genetic;
using System;
using System.Collections.Generic;
using Xunit;

namespace MLAPITest.Genetic
{
    public class PopulationTests
    {
        [Fact]
        [InlineData(1)]
        [InlineData(100)]
        [InlineData(-1)]
        [InlineData(-55)]
        public void TestMethod1(int populationSize)
        {
            // Arrange
            List<Chromosome> generatedChromosomes = GeneticTestUtil.GenerateChromosomes(populationSize);
            Population population = new Population(generatedChromosomes, populationSize);

            // Act


            // Assert
            Assert.IsNotNull(generatedChromosomes);
            Assert.IsNotNull(population);
            Assert.IsNotNull(population.Chromosomes);
            Assert.IsTrue(population.Generation == 0);
            Assert.IsTrue(population.FullSize == populationSize);
            GeneticTestUtil.ValidateChromosomes(population.Chromosomes);
        }
    }
}
