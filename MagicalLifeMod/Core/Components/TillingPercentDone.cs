using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Sound;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Tiles;
using ProtoBuf;
using System.Collections.Generic;

namespace MagicalLifeAPI.Components.Resource
{
    [ProtoContract]
    public class TillablePercentDone : ComponentTillable
    {
        public TillablePercentDone(float percentTillTick)
            : base(percentTillTick)
        {

        }

        protected TillablePercentDone()
        {
            //Protobuf-net constructor.
        }

        public override Tile ResultingTile(Point3D location, int dimension)
        {
            return new TilledDirt(location);
        }

        protected override List<Item> TillPercent(float percent, Point3D position)
        {
            FMODUtil.RaiseEvent(SoundsTable.PickaxeHit, "", 0, position);
            return default;
        }
    }
}