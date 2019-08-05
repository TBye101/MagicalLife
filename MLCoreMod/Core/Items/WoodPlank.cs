using System.Collections.Generic;
using MLAPI.Asset;
using MLAPI.World.Base;
using ProtoBuf;

namespace MLCoreMod.Core.Items
{
    /// <summary>
    /// A wooden plank item, created from logs.
    /// </summary>
    [ProtoContract]
    public class WoodPlank : Item
    {
        public static readonly string DisplayName = "Wood Plank";

        protected WoodPlank()
        {
        }

        public WoodPlank(int count)
            : base(DisplayName, new List<string>(), 99, count, TextureLoader.TextureWoodPlank,
                  1.25, DescriptionValues.DisplayName)
        {
        }

        public override Item GetDeepCopy(int amount)
        {
            return new WoodPlank(amount);
        }
    }
}