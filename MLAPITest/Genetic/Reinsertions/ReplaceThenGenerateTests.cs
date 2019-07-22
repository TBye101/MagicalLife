using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLAPI.Genetic;
using MLAPI.Genetic.Crossovers;
using MLAPI.Genetic.Reinsertions;
using MLAPI.Genetic.Selections;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace MLAPITest.Genetic.Reinsertions
{
    public class ReplaceThenGenerateTests
    {
        [Fact]
        public void Reinsert_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            TestGeneFactory geneFactory = new TestGeneFactory();
            ReplaceThenGenerate replaceThenGenerate = new ReplaceThenGenerate(geneFactory);
            ICrossover crossover = new KPointCrossover(2);
            ISelection selection = new PercentSelection(.05F);
            List<Chromosome> initialPopulation = GeneticTestUtil.GenerateChromosomes(100);

            Population population = new Population(initialPopulation, 100);
            List<Chromosome> parents = selection.SelectParents(population);
            List<Chromosome> offspring = crossover.CrossParents(parents);


            // Act
            replaceThenGenerate.Reinsert(parents, offspring, population);

            // Assert
            Assert.IsNotNull(geneFactory);
            Assert.IsNotNull(replaceThenGenerate);
            Assert.IsNotNull(crossover);
            Assert.IsNotNull(selection);
            Assert.IsNotNull(initialPopulation);
            Assert.IsNotNull(population);
            Assert.IsNotNull(parents);
            Assert.IsNotNull(offspring);

            GeneticTestUtil.ValidateChromosomes(population.Chromosomes);
            GeneticTestUtil.ValidateChromosomes(parents);
            GeneticTestUtil.ValidateChromosomes(offspring);

            int howManyOffspringExpected = Math.Min(population.FullSize, offspring.Count);
            int howManyParentsExpected = Math.Min(population.FullSize - howManyOffspringExpected, parents.Count);
            int howManyNewChromosomesExpected = population.FullSize - howManyOffspringExpected - howManyParentsExpected;

            IEnumerable<Chromosome> offspringFound = population.Chromosomes.Intersect(offspring);
            IEnumerable<Chromosome> parentsFound = population.Chromosomes.Intersect(parents);

            Assert.IsTrue(howManyOffspringExpected == offspringFound.Count());
            Assert.IsTrue(howManyParentsExpected == parentsFound.Count());

            int newChromosomesFound = population.Chromosomes.Count - offspringFound.Count() - parentsFound.Count();
            Assert.IsTrue(newChromosomesFound == howManyNewChromosomesExpected);
        }
    }
}
