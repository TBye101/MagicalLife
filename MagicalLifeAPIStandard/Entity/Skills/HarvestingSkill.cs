using MagicalLifeAPI.DataTypes.Attribute;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Entity.Skills
{
    /// <summary>
    /// The skill of a creature in mining.
    /// </summary>
    [ProtoContract]
    public class HarvestingSkill : Skill
    {
        private static readonly string PublicDisplayName = "Harvesting";
        private static readonly string InternalIDName = "HarvestingSkill";

        public HarvestingSkill(ComboAttribute skillAmount, bool learnable)
            : base(PublicDisplayName, skillAmount, learnable, InternalIDName)
        {

        }

        protected HarvestingSkill()
        {
            //Protobuf-net constructor. 
        }
    }
}
