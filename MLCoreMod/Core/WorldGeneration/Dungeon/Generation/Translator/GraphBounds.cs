using System;
using System.Collections.Generic;
using System.Text;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.Generation.Translator
{
    internal struct GraphBounds
    {
        public int LowestXPosition;
        public int HighestXPosition;
        public int LowestYPosition;
        public int HighestYPosition;

        public GraphBounds(int lowestXPosition, int highestXPosition, int lowestYPosition, int highestYPosition)
        {
            this.LowestXPosition = lowestXPosition;
            this.HighestXPosition = highestXPosition;
            this.LowestYPosition = lowestYPosition;
            this.HighestYPosition = highestYPosition;
        }
    }
}
