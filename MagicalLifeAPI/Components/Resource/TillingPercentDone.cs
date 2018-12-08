using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Sound;
using MagicalLifeAPI.World.Base;
using ProtoBuf;
using System.Collections.Generic;

namespace MagicalLifeAPI.Components.Resource
{
    [ProtoContract]
    public class TillablePercentDone : AbstractTillable
    {
        public TillablePercentDone()
        {
        }

        protected override List<Item> TillPercent(float percentMined, Point2D position)
        {
            FMODUtil.RaiseEvent(SoundsTable.PickaxeHit, "", 0, position);
            return null;
        }
    }
}