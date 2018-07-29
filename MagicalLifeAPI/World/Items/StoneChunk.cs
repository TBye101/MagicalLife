using MagicalLifeAPI.World.Base;

namespace MagicalLifeAPI.World.Items
{
    public class StoneChunk : Item
    {
        public StoneChunk(int count) :
            base("Stone Chunk", 200,
            new System.Collections.Generic.List<string>()
            {
                "Stone Chunk",
                "Is dropped when stone is mined"
            },
            9999,
            count,
            typeof(StoneChunk))
        {
        }

        public StoneChunk() : base()
        {
        }

        public override string GetTextureName()
        {
            return "MarbleChunk";
        }
    }
}