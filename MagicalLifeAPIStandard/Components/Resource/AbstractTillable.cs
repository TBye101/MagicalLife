using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World.Base;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.Components.Resource
{
    [ProtoContract]
    public abstract class AbstractTillable
    {
        [ProtoMember(1)]
        public float PercentTilled { get; private set; }

        protected AbstractTillable()
        {
            this.PercentTilled = 0;
        }

        public Type GetBaseType()
        {
            return typeof(AbstractTillable);
        }

        /// <summary>
        /// Called anytime the object is in the process of being mined, but not totally mined.
        /// Should the object be completely mined in one step, this is called with 100%, then <see cref="Mined"/> is called.
        /// </summary>
        /// <param name="percentMined"></param>
        /// <returns>Any items that should be dropped due to the progress in mining the object. Return null to drop nothing.</returns>
        public List<Item> TillSomePercent(float percentTilled, Point2D position)
        {
            this.PercentTilled += percentTilled;

            if (this.PercentTilled < 1)
            {
                return this.TillPercent(this.PercentTilled, position);
            }
            else
            {
                return null;
            }
        }

        /// <param name="percent">The total percent mined so far.</param>
        /// <returns></returns>
        protected abstract List<Item> TillPercent(float percent, Point2D position);
    }
}