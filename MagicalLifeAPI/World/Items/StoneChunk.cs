using MagicalLifeAPI.World.Base;
using ProtoBuf;

namespace MagicalLifeAPI.World.Items
{
    [ProtoContract]
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
            typeof(StoneChunk), "MarbleChunk")
        {
        }

        public StoneChunk()
        {
        }
    }
}