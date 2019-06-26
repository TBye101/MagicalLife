using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World.Base;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.Components.Resource
{
    /// <summary>
    /// Holds logic to do with the tilling of tiles.
    /// </summary>
    [ProtoContract]
    public abstract class ComponentTillable : Component
    {
        [ProtoMember(1)]
        public float PercentTilled { get; private set; }

        /// <summary>
        /// The percentage to till each tick this tillable is tilled. 
        /// </summary>
        [ProtoMember(2)]
        public float PercentTillTick { get; private set; }

        protected ComponentTillable(float percentTillTick)
        {
            this.PercentTilled = 0;
            this.PercentTillTick = percentTillTick;
        }

        protected ComponentTillable()
        {
            //Protobuf-net constructor
        }

        public Type GetBaseType()
        {
            return typeof(ComponentTillable);
        }

        /// <summary>
        /// Called anytime the object is in the process of being tilled, but not totally tilled.
        /// Should the object be completely tilled in one step, this is called with 100%, then <see cref="Mined"/> is called.
        /// </summary>
        /// <param name="percentMined"></param>
        /// <returns>Any items that should be dropped due to the progress in tilled the object. Return null to drop nothing.</returns>
        public List<Item> TillSomePercent(float percentTilled, Point3D position)
        {
            this.PercentTilled += percentTilled;

            if (this.PercentTilled < 1)
            {
                return this.TillPercent(this.PercentTilled, position);
            }
            else
            {
                return default;
            }
        }

        /// <summary>
        /// Returns the total percent tilled so far.
        /// </summary>
        /// <param name="percent">The total percent tilled so far.</param>
        /// <returns></returns>
        protected abstract List<Item> TillPercent(float percent, Point3D position);

        /// <summary>
        /// Returns the finished product of the tiling.
        /// </summary>
        /// <returns></returns>
        public abstract Tile ResultingTile(Point3D location);
    }
}