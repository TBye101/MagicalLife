using MagicalLifeAPI.Components.Tile.Renderable;
using MagicalLifeAPI.DataTypes;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.World.Tiles
{
    [ProtoContract]
    public class Grass : Tile
    {
        public Grass(Point2D location) : base(location, 11, new TransitionTextures(typeof(Dirt), typeof(Grass), new ConnectedGrass()), 1)
        {
        }

        public Grass(int x, int y) : this(new Point2D(x, y))
        {
        }

        public Grass() : base()
        {
        }

        public override string GetName()
        {
            return "Grass";
        }
    }
}