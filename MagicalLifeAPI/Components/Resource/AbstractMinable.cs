using MagicalLifeAPI.World.Base;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.Components.Resource
{
    /// <summary>
    /// Anything that implements this must describe its behavior in terms of mining.
    /// </summary>
    [ProtoContract]
    [ProtoInclude(2, typeof(DropWhenCompletelyMined))]
    public abstract class AbstractMinable
    {
        /// <summary>
        /// The total percentage of the IMinable that has been mined so far.
        /// </summary>
        [ProtoMember(1)]
        public float PercentMined { get; private set; }

        protected AbstractMinable()
        {
            this.PercentMined = 0;
        }

        public Type GetBaseType()
        {
            return typeof(AbstractMinable);
        }

        /// <summary>
        /// Called when the object is mined up completely.
        /// </summary>
        /// <returns>Any items that should be dropped when completely mined. Return null to drop nothing.</returns>
        public abstract List<Item> Mined();

        /// <summary>
        /// Called anytime the object is in the process of being mined, but not totally mined.
        /// Should the object be completely mined in one step, this is called with 100%, then <see cref="Mined"/> is called.
        /// </summary>
        /// <param name="percentMined"></param>
        /// <returns>Any items that should be dropped due to the progress in mining the object. Return null to drop nothing.</returns>
        public List<Item> MineSomePercent(float percentMined)
        {
            this.PercentMined += percentMined;

            if (this.PercentMined < 1)
            {
                return this.MinePercent(this.PercentMined);
            }
            else
            {
                return this.Mined();
            }
        }

        /// <param name="percent">The total percent mined so far.</param>
        /// <returns></returns>
        protected abstract List<Item> MinePercent(float percent);
    }
}