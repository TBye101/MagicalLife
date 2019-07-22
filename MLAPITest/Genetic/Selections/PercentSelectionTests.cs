using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLAPI.Genetic;
using MLAPI.Genetic.Selections;
using System;
using System.Collections.Generic;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace MLAPITest.Genetic.Selections
{
    public class PercentSelectionTests
    {
        [Theory]
        [InlineData(.1)]
        [InlineData(.2)]
        [InlineData(.5)]
        [InlineData(.532345)]
        [InlineData(1)]
        public void SelectParents_StateUnderTest_ExpectedBehavior(float percent)
        {
            // Arrange
            PercentSelection percentSelection = new PercentSelection(percent);
            IGeneFactory geneFactory = new TestGeneFactory();
            List<Chromosome> initialPopulation = GeneticTestUtil.GenerateChromosomes(100);
            IFitness fitness = new TestFitness();
            Population pop = new Population(initialPopulation, 100);

            // Act
            GeneticTestUtil.CalculateFitnesses(pop.Chromosomes, fitness);
            List<Chromosome> selectedChromosomes = percentSelection.SelectParents(pop);

            // Assert
            Assert.IsNotNull(percentSelection);
            Assert.IsNotNull(geneFactory);
            Assert.IsNotNull(initialPopulation);
            Assert.IsNotNull(initialPopulation);
            Assert.IsNotNull(fitness);
            Assert.IsNotNull(pop);
            Assert.IsNotNull(pop.Chromosomes);
            Assert.IsNotNull(selectedChromosomes);

            GeneticTestUtil.ValidateChromosomes(initialPopulation);
            GeneticTestUtil.ValidateChromosomes(selectedChromosomes);
            this.ValidateSelectionIsTakingFittestPercent(selectedChromosomes, pop, percent);

            Assert.IsTrue(percent > 0);
        }

        private void ValidateSelectionIsTakingFittestPercent(List<Chromosome> selected, Population totalPopulation, float selectionPercent)
        {
            totalPopulation.Chromosomes.Sort((x, y) => x.Fitness.Value.CompareTo(y.Fitness.Value));
            int selectedCount = (int)selectionPercent * totalPopulation.FullSize;
            List<Chromosome> testSelection = totalPopulation.Chromosomes.GetRange(0, selectedCount);

            foreach (Chromosome item in testSelection)
            {
                Assert.IsTrue(selected.Contains(item));
            }
        }
    }
}
