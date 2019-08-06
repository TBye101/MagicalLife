using MLAPI.World;
using System;
using MLAPI.DataTypes;
using MLAPI.DataTypes.Collection;
using MLAPI.World.Data;
using Xunit;

namespace MLAPITest.World
{
    public class WorldUtilTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(10, 10)]
        [InlineData(13, 27)]
        public void GenerateBlankChunks_StateUnderTest_ExpectedBehavior(int chunkWidth, int chunkHeight)
        {
            // Act
            ProtoArray<MLAPI.World.Data.Chunk> result = WorldUtil.GenerateBlankChunks(chunkWidth, chunkHeight);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Data.Length == chunkWidth * chunkHeight);
            Assert.True(result.Height == chunkHeight);
            Assert.True(result.Width == chunkWidth);

            foreach (Chunk item in result.Data)
            {
                Assert.NotNull(item);
                Assert.NotNull(item.ChunkLocation);
                Assert.NotNull(item.Creatures);
                Assert.NotNull(item.Items);
                Assert.NotNull(item.Tiles);

                Assert.False(item.Id.Equals(Guid.Empty));
            }
        }
    }
}
