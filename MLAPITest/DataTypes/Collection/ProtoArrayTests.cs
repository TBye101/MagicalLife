using MLAPI.DataTypes.Collection;
using System;
using Xunit;

namespace MLAPITest.DataTypes.Collection
{
    public class ProtoArrayTests
    {
        [Theory]
        [InlineData(13, 27)]
        public void GetEnumerator_StateUnderTest_ExpectedBehavior(int width, int height)
        {
            // Arrange
            ProtoArray<int> protoArray = new ProtoArray<int>(width, height);

            int num = 0;
            for (int x = 0; x < protoArray.Width; x++)
            {
                for (int y = 0; y < protoArray.Height; y++)
                {
                    protoArray[x, y] = num;
                    num++;
                }
            }

            // Assert
            Assert.NotNull(protoArray);
            Assert.NotNull(protoArray.Data);
            Assert.True(protoArray.Width == width);
            Assert.True(protoArray.Height == height);

            int numCheck = 0;
            foreach (int item in protoArray)
            {
                Assert.True(numCheck == item);
                numCheck++;
            }
        }
    }
}
