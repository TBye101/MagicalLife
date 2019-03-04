using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.Entity.AI.Task
{
    /// <summary>
    /// Used to determine available tasks for a creature, as well as complete tasks in required dependency order.
    /// This class also handles "bound" tasks, also known as tasks that require the same worker to complete them.
    /// </summary>
    internal class TaskDriver
    {
        /// <summary>
        /// The task to be completed.
        /// </summary>
        public readonly MagicalTask Task;

        public TaskDriver(MagicalTask task)
        {
            this.Task = task;
        }

        /// <summary>
        /// Returns all tasks that do not have uncompleted dependencies that still need to be completed.
        /// </summary>
        /// <returns></returns>
        private List<MagicalTask> GetReadyTasks()
        {
            return this.GetReadyTasksRecursion(new List<MagicalTask>() { this.Task });
        }

        private List<MagicalTask> GetReadyTasksRecursion(List<MagicalTask> tasks)
        {
            List<MagicalTask> ret = new List<MagicalTask>();

            foreach (MagicalTask item in tasks)
            {
                if (item.Dependencies.PreRequisite.Count > 0)
                {
                    ret.AddRange(this.GetReadyTasksRecursion(item.Dependencies.PreRequisite));
                }
                else
                {
                    if (item.ToilingWorker == Guid.Empty)
                    {
                        ret.Add(item);
                    }
                }
            }

            return ret;
        }

        /// <summary>
        /// Returns all of the tasks that this <see cref="TaskDriver"/> has control of that the creature can do.
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public List<MagicalTask> GetCompatibleJobs(Living l)
        {
            List<MagicalTask> qualified = this.GetAllQualifiedJobs(l);

            for (int i = qualified.Count; i > 0; i--)
            {
                MagicalTask item = qualified[i - 1];

                //If a creature has already started on a related task,
                //and the task requires the same worker to do this task too
                if (item.ReservedFor != Guid.Empty && item.ReservedFor != l.ID)
                {
                    qualified.RemoveAt(i - 1);
                }
            }

            return qualified;
        }

        /// <summary>
        /// Returns all of the tasks that the creature is qualified for.
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        private List<MagicalTask> GetAllQualifiedJobs(Living l)
        {
            List<MagicalTask> availibleTasks = this.GetReadyTasks();
            List<MagicalTask> ret = new List<MagicalTask>();

            foreach (MagicalTask item in availibleTasks)
            {
                //If true, the worker passed all criteria to do the task.
                bool compatible = true;

                foreach (Qualification qualification in item.Qualifications)
                {
                    //Does the creature meet the criteria?
                    if (!qualification.IsQualified(l))
                    {
                        compatible = false;
                        break;
                    }
                }

                //If the creature met all criteria
                if (compatible)
                {
                    ret.Add(item);
                }
            }

            return ret;
        }
    }
}