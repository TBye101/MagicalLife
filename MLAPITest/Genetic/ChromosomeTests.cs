using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLAPI.Genetic;
using System;
using System.Collections.Generic;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace MLAPITest.Genetic
{
    public class ChromosomeTests
    {
        [Fact]
        public void NewChromosome_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            IGeneFactory factory = new TestGeneFactory();
            Chromosome chromosome = new Chromosome(factory.GenerateGenes(10));

            // Act
            Chromosome result = chromosome.NewChromosome(factory);

            // Assert
            Assert.IsNotNull(factory);
            Assert.IsNotNull(chromosome);
            Assert.IsNotNull(result);
            Assert.IsNotNull(chromosome.Genes);
            Assert.IsNotNull(result.Genes);

            Assert.IsTrue(chromosome.Genes.Length == result.Genes.Length);

            GeneticTestUtil.ValidateChromosomes(new List<Chromosome> { chromosome, result });
        }
    }
}
