using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World.Base;
using ProtoBuf;

namespace MagicalLifeAPI.Components.Resource
{
    /// <summary>
    /// Used to hold a <see cref="AbstractTillable"/> component.
    /// </summary>
    [ProtoContract]
    public abstract class TillableTile : Tile
    {
        [ProtoMember(1)]
        public AbstractTillable TillableBehavior { get; set; }

        protected TillableTile()
        {
        }

        protected TillableTile(Point2D location, int movementCost, int footStepSound) : base(location, movementCost, footStepSound)
        {
        }

        protected TillableTile(int x, int y, int movementCost, int footStepSound) : base(x, y, movementCost, footStepSound)
        {
        }
    }
}