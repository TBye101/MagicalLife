using ProtoBuf;
using System.Collections.Generic;

namespace MagicalLifeAPI.Entity.AI.Task
{
    /// <summary>
    /// Holds tasks that must be completed before another task can begin.
    /// </summary>
    [ProtoContract]
    public class Dependencies
    {
        [ProtoMember(1)]
        public List<MagicalTask> PreRequisite { get; private set; }

        /// <summary>
        /// The amount of prerequisites originally.
        /// </summary>
        [ProtoMember(2)]
        public int InitialCount;

        public static readonly Dependencies None = new Dependencies(new List<MagicalTask>());

        public Dependencies(List<MagicalTask> dependencies)
        {
            this.PreRequisite = dependencies;
            this.InitialCount = dependencies.Count;

            foreach (MagicalTask item in this.PreRequisite)
            {
                item.Completed += this.Item_Completed;
            }
        }

        private void Item_Completed(MagicalTask task)
        {
            this.PreRequisite.Remove(task);
        }

        public Dependencies()
        {
            //Protobuf-net constructor.
        }
    }
}