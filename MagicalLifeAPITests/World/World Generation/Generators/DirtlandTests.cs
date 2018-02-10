using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MagicalLifeAPI.World.World_Generation.Generators.Tests
{
    [TestClass()]
    public class DirtlandTests
    {
        [TestMethod()]
        public void AssignBiomesTest()
        {
            Dirtland d = new Dirtland();
            Assert.IsNotNull(d);
        }

        [TestMethod()]
        public void AssignBiomesTest1()
        {
            Dirtland d = new Dirtland();
            Assert.IsNotNull(d);
            string[,,] biomes = d.AssignBiomes(10, 9, 2);
            Assert.IsNotNull(biomes);
            Assert.AreEqual(10, biomes.GetLength(0));
            Assert.AreEqual(9, biomes.GetLength(1));
            Assert.AreEqual(2, biomes.GetLength(2));
        }

        [TestMethod()]
        public void GenerateDetailsTest()
        {
            Dirtland d = new Dirtland();
            Assert.IsNotNull(d);
            string[,,] biomes = d.AssignBiomes(10, 9, 2);
            Assert.IsNotNull(biomes);
            Tile[,,] tiles = d.GenerateLandType(biomes);
            Assert.IsNotNull(tiles);
            Assert.AreEqual(10, tiles.GetLength(0));
            Assert.AreEqual(9, tiles.GetLength(1));
            Assert.AreEqual(2, tiles.GetLength(2));
            tiles = d.GenerateMinerals(tiles);
            Assert.IsNotNull(tiles);
            tiles = d.GenerateNaturalFeatures(tiles);
            Assert.IsNotNull(tiles);
            tiles = d.GenerateDetails(tiles);
            Assert.IsNotNull(tiles);
        }

        [TestMethod()]
        public void GenerateLandTypeTest()
        {
            Dirtland d = new Dirtland();
            Assert.IsNotNull(d);
            string[,,] biomes = d.AssignBiomes(10, 9, 2);
            Assert.IsNotNull(biomes);
            Tile[,,] tiles = d.GenerateLandType(biomes);
            Assert.IsNotNull(tiles);
            Assert.AreEqual(10, tiles.GetLength(0));
            Assert.AreEqual(9, tiles.GetLength(1));
            Assert.AreEqual(2, tiles.GetLength(2));
        }

        [TestMethod()]
        public void GenerateMineralsTest()
        {
            Dirtland d = new Dirtland();
            Assert.IsNotNull(d);
            string[,,] biomes = d.AssignBiomes(10, 9, 2);
            Assert.IsNotNull(biomes);
            Tile[,,] tiles = d.GenerateLandType(biomes);
            Assert.IsNotNull(tiles);
            Assert.AreEqual(10, tiles.GetLength(0));
            Assert.AreEqual(9, tiles.GetLength(1));
            Assert.AreEqual(2, tiles.GetLength(2));
            tiles = d.GenerateMinerals(tiles);
            Assert.IsNotNull(tiles);
        }

        [TestMethod()]
        public void GenerateNaturalFeaturesTest()
        {
            Dirtland d = new Dirtland();
            Assert.IsNotNull(d);
            string[,,] biomes = d.AssignBiomes(10, 9, 2);
            Assert.IsNotNull(biomes);
            Tile[,,] tiles = d.GenerateLandType(biomes);
            Assert.IsNotNull(tiles);
            Assert.AreEqual(10, tiles.GetLength(0));
            Assert.AreEqual(9, tiles.GetLength(1));
            Assert.AreEqual(2, tiles.GetLength(2));
            tiles = d.GenerateMinerals(tiles);
            Assert.IsNotNull(tiles);
            tiles = d.GenerateNaturalFeatures(tiles);
            Assert.IsNotNull(tiles);
        }

        [TestMethod()]
        public void GenerateVegetationTest()
        {
            Dirtland d = new Dirtland();
            Assert.IsNotNull(d);
            string[,,] biomes = d.AssignBiomes(10, 9, 2);
            Assert.IsNotNull(biomes);
            Tile[,,] tiles = d.GenerateLandType(biomes);
            Assert.IsNotNull(tiles);
            Assert.AreEqual(10, tiles.GetLength(0));
            Assert.AreEqual(9, tiles.GetLength(1));
            Assert.AreEqual(2, tiles.GetLength(2));
            tiles = d.GenerateMinerals(tiles);
            Assert.IsNotNull(tiles);
            tiles = d.GenerateNaturalFeatures(tiles);
            Assert.IsNotNull(tiles);
            tiles = d.GenerateVegetation(tiles);
            Assert.IsNotNull(tiles);
        }
    }
}