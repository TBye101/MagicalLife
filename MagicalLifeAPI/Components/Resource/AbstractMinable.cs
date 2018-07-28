using MagicalLifeAPI.Networking;
using MagicalLifeAPI.World.Base;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Components.Resource
{
    /// <summary>
    /// Anything that implements this must describe its behavior in terms of mining.
    /// </summary>
    [ProtoContract]
    public abstract class AbstractMinable : IHasSubclasses
    {
        public Type GetBaseType()
        {
            return typeof(AbstractMinable);
        }

        public Dictionary<Type, int> GetSubclassInformation()
        {
            return new Dictionary<Type, int>
            {
                { typeof(DropWhenCompletelyMined), 0 }
            };
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
        public abstract List<Item> MiningInProgress(float percentMined);
    }
}
