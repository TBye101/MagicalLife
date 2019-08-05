using MLAPI.DataTypes.Attribute;
using MLAPI.Entity.Experience;
using MLAPI.Properties;
using ProtoBuf;

namespace MLAPI.Entity.Skills
{
    /// <summary>
    /// The skill of a creature in mining.
    /// </summary>
    [ProtoContract]
    public class HarvestingSkill : Skill
    {
        private static readonly string PublicDisplayName = Lang.Harvesting;
        public static readonly string InternalIdName = "HarvestingSkill";

        public HarvestingSkill(ComboAttribute skillAmount, bool learnable)
            : base(PublicDisplayName, skillAmount, learnable, InternalIdName, new SqrtXpCalculator(48))
        {
        }

        protected HarvestingSkill()
        {
            //Protobuf-net constructor.
        }
    }
}