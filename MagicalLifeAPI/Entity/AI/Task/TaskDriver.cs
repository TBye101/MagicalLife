using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Entity.AI.Task
{
    /// <summary>
    /// Used to determine available tasks for a creature, as well as complete tasks in required dependency order.
    /// This class also handles "bound" tasks, also known as tasks that require the same worker to complete them.
    /// </summary>
    public class TaskDriver
    {
        /// <summary>
        /// Returns all of the tasks that this <see cref="TaskDriver"/> has control of that the creature can do. 
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public List<MagicalTask> GetCompatibleJobs(Living l)
        {

        }
    }
}
