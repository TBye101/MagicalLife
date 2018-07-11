using MagicalLifeAPI.Asset;
using MagicalLifeAPI.World.Base;

namespace MagicalLifeAPI.World.Items
{
    public class StoneChunk : Item
    {
        public StoneChunk() : base()
        {
        }

        public override string GetTextureName()
        {
            return "MarbleChunk";
        }
    }
}