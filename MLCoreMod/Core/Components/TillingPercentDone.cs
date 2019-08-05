using System.Collections.Generic;
using MLAPI.Components.Resource;
using MLAPI.DataTypes;
using MLAPI.Sound;
using MLAPI.World.Base;
using MLCoreMod.Core.Tiles;
using ProtoBuf;

namespace MLCoreMod.Core.Components
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

        public override Tile ResultingTile(Point3D location)
        {
            return new TilledDirt(location);
        }

        protected override List<Item> TillPercent(float percent, Point3D position)
        {
            FmodUtil.RaiseEvent(SoundsTable.PickaxeHit, "", 0, position);
            return default;
        }
    }
}