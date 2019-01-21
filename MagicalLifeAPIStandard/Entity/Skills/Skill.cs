using MagicalLifeAPI.DataTypes.Attribute;
using MagicalLifeAPI.Entity.Experience;
using ProtoBuf;
using System;

namespace MagicalLifeAPI.Entity.Skills
{
    /// <summary>
    /// Holds data about a specific skill.
    /// </summary>
    [ProtoContract]
    [ProtoInclude(1, typeof(HarvestingSkill))]
    public class Skill
    {
        /// <summary>
        /// The display name of the skill.
        /// </summary>
        [ProtoMember(2)]
        public string DisplayName { get; set; }

        /// <summary>
        /// The level of the creature's skill.
        /// </summary>
        [ProtoMember(3)]
        public ComboAttribute SkillAmount { get; set; }

        /// <summary>
        /// If true the creature is capable of learning the skill.
        /// </summary>
        [ProtoMember(4)]
        public bool Learnable { get; set; }

        /// <summary>
        /// The internal name of the skill. Reference this to determine a skill's identity instead of the display name.
        /// </summary>
        [ProtoMember(5)]
        public string InternalName { get; set; }

        /// <summary>
        /// Do not use this to get current level, use <see cref="SkillAmount"/>.
        /// </summary>
        [ProtoMember(6)]
        public XP Experience { get; private set; }

        /// <summary>
        /// The current level of the skill.
        /// </summary>
        public int Level
        {
            get
            {
                return this.Experience.CurrentLevel;
            }
        }

        /// <param name="displayName">The display name of the skill.</param>
        /// <param name="skillAmount">The level of the creature's skill.</param>
        /// <param name="learnable">If true the creature is capable of learning the skill.</param>
        public Skill(string displayName, ComboAttribute skillAmount, bool learnable, string internalName, IXPCalculator xpProgression)
        {
            this.DisplayName = displayName;
            this.SkillAmount = skillAmount;
            this.Learnable = learnable;
            this.InternalName = internalName;
            this.Experience = new XP(1, skillAmount.BaseValue.GetValue(), xpProgression);
        }

        protected Skill()
        {
            //Protobuf-net Constructor
        }

        public void GainXP(UInt64 xp)
        {
            this.Experience.AddXP(xp);
            this.SkillAmount.SetBaseValue(Convert.ToInt32(this.Experience.CurrentLevel));
        }

        public void RemoveXP(UInt64 xp)
        {
            this.Experience.RemoveXP(xp);
            this.SkillAmount.SetBaseValue(Convert.ToInt32(this.Experience.CurrentLevel));
        }
    }
}