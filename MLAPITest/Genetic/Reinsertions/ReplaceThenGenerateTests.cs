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
            IFitness fitness = new TestFitness();
            TestGeneFactory geneFactory = new TestGeneFactory();
            ReplaceThenGenerate replaceThenGenerate = new ReplaceThenGenerate(geneFactory);
            ICrossover crossover = new KPointCrossover(2, 10);
            ISelection selection = new PercentSelection(.05F);
            List<Chromosome> initialPopulation = GeneticTestUtil.GenerateChromosomes(100);

            Population population = new Population(initialPopulation, 100);
            GeneticTestUtil.CalculateFitnesses(population.Chromosomes, fitness);
            List<Chromosome> parents = selection.SelectParents(population);
            List<Chromosome> offspring = crossover.CrossParents(parents);
            GeneticTestUtil.CalculateFitnesses(offspring, fitness);


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

            GeneticTestUtil.CalculateFitnesses(population.Chromosomes, fitness);
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
