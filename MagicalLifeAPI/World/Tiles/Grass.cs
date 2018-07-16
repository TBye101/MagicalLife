using MagicalLifeAPI.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.World.Tiles
{
    public class Grass : Tile
    {
        public Grass(Point2D location) : base(location, 11)
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

        public override string GetTextureName()
        {
            return "Grass";
        }
    }
}