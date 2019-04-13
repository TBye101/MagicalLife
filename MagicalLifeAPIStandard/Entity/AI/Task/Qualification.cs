using MagicalLifeAPI.Entity.AI.Task.Qualifications;
using ProtoBuf;

namespace MagicalLifeAPI.Entity.AI.Task
{
    /// <summary>
    /// Is used determine if a creature is suited to do a task, or if a job is ready to begin.
    /// A task normally has many criteria for allowing a creature to do the task.
    /// </summary>
    [ProtoContract]
    public abstract class Qualification
    {
        /// <summary>
        /// Determines if the creature has the
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public abstract bool IsQualified(Living l);

        /// <summary>
        /// Returns true if a certain precondition has been met.
        /// </summary>
        /// <returns></returns>
        public abstract bool ArePreconditionsMet();
    }
}