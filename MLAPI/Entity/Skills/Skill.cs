using System;
using MLAPI.DataTypes.Attribute;
using MLAPI.Entity.Experience;
using ProtoBuf;

namespace MLAPI.Entity.Skills
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
        public Xp Experience { get; private set; }

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

        /// <summary>
        ///
        /// </summary>
        /// <param name="displayName">The display name of the skill.</param>
        /// <param name="skillAmount">The level of the creature's skill.</param>
        /// <param name="learnable">If true the creature is capable of learning the skill.</param>
        /// <param name="internalName"></param>
        /// <param name="xpProgression"></param>
        public Skill(string displayName, ComboAttribute skillAmount, bool learnable, string internalName, IXpCalculator xpProgression)
        {
            this.DisplayName = displayName;
            this.SkillAmount = skillAmount;
            this.Learnable = learnable;
            this.InternalName = internalName;
            this.Experience = new Xp(1, skillAmount.BaseValue.GetValue(), xpProgression);
        }

        protected Skill()
        {
            //Protobuf-net Constructor
        }

        public void GainXp(UInt64 xp)
        {
            this.Experience.AddXp(xp);
            this.SkillAmount.SetBaseValue(Convert.ToInt32(this.Experience.CurrentLevel));
        }

        public void RemoveXp(UInt64 xp)
        {
            this.Experience.RemoveXp(xp);
            this.SkillAmount.SetBaseValue(Convert.ToInt32(this.Experience.CurrentLevel));
        }
    }
}