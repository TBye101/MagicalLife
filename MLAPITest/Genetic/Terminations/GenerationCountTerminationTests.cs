using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLAPI.Genetic;
using MLAPI.Genetic.Algorithms;
using MLAPI.Genetic.Crossovers;
using MLAPI.Genetic.Reinsertions;
using MLAPI.Genetic.Selections;
using MLAPI.Genetic.Terminations;
using System;
using System.Collections.Generic;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace MLAPITest.Genetic.Terminations
{
    public class GenerationCountTerminationTests
    {
        [Theory]
        [MemberData(nameof(GetData))]
        public void ShouldStopEvolving_StateUnderTest_ExpectedBehavior(IFitness fitness, ICrossover crossover, ISelection selection,
            IMutation mutation, IReinsertion reinsertion, int populationSize, 
            Chromosome chromosome, IGeneFactory geneFactory)
        {
            // Arrange
            GenerationCountTermination generationCountTermination = new GenerationCountTermination(10);

            GeneticAlgorithm algorithm = new GenericGeneticAlgorithm(fitness, crossover, selection, generationCountTermination,
                mutation, reinsertion, populationSize, chromosome, geneFactory);
            algorithm.Start();

            // Act
            bool afterStop = generationCountTermination.ShouldStopEvolving(algorithm);

            // Assert
            Assert.IsNotNull(fitness);
            Assert.IsNotNull(crossover);
            Assert.IsNotNull(selection);
            Assert.IsNotNull(mutation);
            Assert.IsNotNull(reinsertion);
            Assert.IsNotNull(chromosome);
            Assert.IsNotNull(geneFactory);
            Assert.IsNotNull(generationCountTermination);
            Assert.IsNotNull(algorithm);

            Assert.IsFalse(populationSize == 0);
            Assert.IsTrue(algorithm.Pop.Generation == 10);
            Assert.IsTrue(afterStop);
        }

        public static IEnumerable<object[]> GetData
        {
            get
            {
                IGeneFactory factory = new TestGeneFactory();

                yield return new object[] {new TestFitness(), new KPointCrossover(1, 10), new PercentSelection(.1F), new TestMutation(),
                    new ReplaceThenGenerate(factory), 100, new Chromosome(factory.GenerateGenes(10)), factory };

                yield return new object[] {new TestFitness(), new KPointCrossover(2, 10), new PercentSelection(.2F), new TestMutation(),
    new ReplaceThenGenerate(factory), 50, new Chromosome(factory.GenerateGenes(10)), factory };

                yield return new object[] {new TestFitness(), new KPointCrossover(3, 10), new PercentSelection(.2F), new TestMutation(),
    new ReplaceThenGenerate(factory), 200, new Chromosome(factory.GenerateGenes(10)), factory };
            }
        }
    }
}
