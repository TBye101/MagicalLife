using MagicalLifeAPI.Asset;
using MagicalLifeAPI.World.Base;
using ProtoBuf;
using System.Collections.Generic;

namespace MagicalLifeMod.Core.Items
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