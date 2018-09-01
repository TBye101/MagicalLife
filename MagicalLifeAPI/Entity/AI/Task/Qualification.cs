using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Entity.AI.Task
{
    /// <summary>
    /// Is used determine if a creature is suited to do a task.
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
    }
}
