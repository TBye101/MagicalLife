using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLAPI.Genetic;
using System;
using System.Collections.Generic;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace MLAPITest.Genetic
{
    public class PopulationTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        [InlineData(-1)]
        [InlineData(-55)]
        public void TestMethod1(int populationSize)
        {
            // Arrange
            List<Chromosome> generatedChromosomes = GeneticUtil.GenerateChromosomes(populationSize, new TestGeneFactory());
            Population population = new Population(generatedChromosomes, populationSize);
            IFitness fitness = new TestFitness();
            GeneticTestUtil.CalculateFitnesses(population.Chromosomes, fitness);

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
