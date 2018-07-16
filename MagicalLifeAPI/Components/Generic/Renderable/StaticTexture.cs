using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World;

namespace MagicalLifeAPI.Components.Generic
{
    /// <summary>
    /// For when an object has only one texture, that always is the same.
    /// </summary>
    public class StaticTexture : AbstractRenderable
    {
        public StaticTexture(int textureID)
        {
            this.TextureID = textureID;
        }

        public override int TextureID { get; set; }

        public override void CalculateTexture(ProtoArray<World.Tile> tiles, Point2D myLocation)
        {
        }
    }
}