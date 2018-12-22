using MagicalLifeAPI.DataTypes.Attribute;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Entity.Skills
{
    /// <summary>
    /// Holds data about a specific skill.
    /// </summary>
    [ProtoContract]
    public class Skill
    {
        /// <summary>
        /// The display name of the skill.
        /// </summary>
        [ProtoMember(1)]
        public string DisplayName { get; set; }

        /// <summary>
        /// The level of the creature's skill.
        /// </summary>
        [ProtoMember(2)]
        public ComboAttribute SkillAmount { get; set; }

        /// <summary>
        /// If true the creature is capable of learning the skill.
        /// </summary>
        [ProtoMember(3)]
        public bool Learnable { get; set; }

        /// <summary>
        /// The internal name of the skill. Reference this to determine a skill's identity instead of the display name.
        /// </summary>
        [ProtoMember(4)]
        public string InternalName { get; set; }

        /// <param name="displayName">The display name of the skill.</param>
        /// <param name="skillAmount">The level of the creature's skill.</param>
        /// <param name="learnable">If true the creature is capable of learning the skill.</param>
        public Skill(string displayName, ComboAttribute skillAmount, bool learnable, string internalName)
        {
            this.DisplayName = displayName;
            this.SkillAmount = skillAmount;
            this.Learnable = learnable;
            this.InternalName = internalName;
        }

        protected Skill()
        {
            //Protobuf-net Constructor
        }
    }
}
