using MagicalLifeAPI.Asset;
using MagicalLifeAPI.World.Base;
using Microsoft.Xna.Framework;

namespace MagicalLifeAPI.World.Items
{
    public class StoneChunk : Item
    {
        public StoneChunk(int itemID) :
            base("Stone Chunk", 200,
            new System.Collections.Generic.List<string>()
            {
                "Stone Chunk",
                "Is dropped when stone is mined"
            },  
            9999, 
            1, 
            itemID)
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