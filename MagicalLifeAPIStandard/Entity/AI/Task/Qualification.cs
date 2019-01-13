using MagicalLifeAPI.Entity.AI.Task.Qualifications;
using ProtoBuf;

namespace MagicalLifeAPI.Entity.AI.Task
{
    /// <summary>
    /// Is used determine if a creature is suited to do a task.
    /// A task normally has many criteria for allowing a creature to do the task.
    /// </summary>
    [ProtoContract]
    [ProtoInclude(1, typeof(CanMoveQualification))]
    [ProtoInclude(2, typeof(SpecificCreatureQualification))]
    [ProtoInclude(3, typeof(HasSkillQualification))]
    public abstract class Qualification
    {
        /// <summary>
        /// Determines if the creature has the
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public abstract bool IsQualified(Living l);
    }
}