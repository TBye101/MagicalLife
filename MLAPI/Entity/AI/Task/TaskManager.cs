using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MLAPI.Filing.Logging;

namespace MLAPI.Entity.AI.Task
{
    /// <summary>
    /// Manages task assignments to creatures.
    /// </summary>
    public class TaskManager
    {
        public static TaskManager Manager { get; set; } = new TaskManager();

        private List<MagicalTask> Tasks { get; } = new List<MagicalTask>();

        private readonly object SyncObject = new object();

        internal TaskManager()
        {
        }

        public void AddTask(MagicalTask task)
        {
            lock (this.SyncObject)
            {
                this.Tasks.Add(task);
                task.Completed += this.Task_Completed;
            }
        }

        private void Task_Completed(MagicalTask task)
        {
            lock (this.SyncObject)
            {
                this.Tasks.RemoveAll(x => x.Equals(task));
            }
        }

        internal void AssignTask(Living living)
        {
            lock (this.SyncObject)
            {
                //Get all valid parent tasks for the specified creature
                List<MagicalTask> validTasks = this.GetValidTasks(living);

                validTasks.Sort((x, y) => CompareTasks(x, y, living));

                if (validTasks.Any())
                {
                    MasterLog.DebugWriteLine("Creature searching for job: " + living.ID.ToString());
                    //Get the first task and dynamically create it's dependencies

                    for (int i = 0; i < validTasks.Count; i++)
                    {
                        MagicalTask taskGoal = validTasks[i];
                        this.CreateDependencies(taskGoal, living);

                        //Get the deepest tasks from the dependency chain, and filter out ones that the creature can't do.
                        List<MagicalTask> deepestTasks = this.GetDeepestTasks(taskGoal);
                        List<MagicalTask> possibleTasks = this.FilterByValidTasks(living, deepestTasks);
                        this.FilterByDependencyStatus(possibleTasks);
                        possibleTasks.Sort((x, y) => CompareTasks(x, y, living));

                        if (possibleTasks.Any())
                        {
                            //Reserve the tasks that must all be done by the same creature for this creature.
                            MagicalTask nextTask = possibleTasks[0];
                            this.ReserveBoundTree(living, nextTask.BoundID, taskGoal);
                            this.AssignJob(living, nextTask);
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// A comparator used to compare magical tasks in relations to a creature.
        /// Determines whether x is greater than, less than, or equal to y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static int CompareTasks(MagicalTask x, MagicalTask y, Living living)
        {
            int equal = 0; //x and y are equal.
            int lessThan = 1; //x is less than y.
            int greaterThan = -1; //x is greater than y.

            if (x.ReservedFor.Equals(living.ID) && !y.ReservedFor.Equals(living.ID))
            {
                return greaterThan;
            }
            if (!x.ReservedFor.Equals(living.ID) && y.ReservedFor.Equals(living.ID))
            {
                return lessThan;
            }

            if (x == null || y == null)
            {
                if (x == null && y != null)
                {
                    return lessThan; //x is less than y.
                }
                if (x != null)
                {
                    return greaterThan; //x is greater than y.
                }

                return equal; //They are both null.
            }
            else
            {
                if (x.TaskPriority == y.TaskPriority)
                {
                    return equal; //They are equal in priority.
                }
                if (x.TaskPriority > y.TaskPriority)
                {
                    return greaterThan; //x is greater in priority.
                }
                else
                {
                    return lessThan; //x is less than y.
                }
            }
        }

        /// <summary>
        /// Assigns a task to the creature.
        /// </summary>
        /// <param name="l"></param>
        /// <param name="task"></param>
        /// <returns></returns>
        private void AssignJob(Living l, MagicalTask task)
        {
            MasterLog.DebugWriteLine("Assigning job: " + task.ID.ToString() + " " + task.GetType().FullName);
            task.MakePreparations(l);
            l.AssignTask(task);
            task.ToilingWorker = l.ID;
        }

        /// <summary>
        /// Gets all valid parent level tasks for the specified creature.
        /// </summary>
        /// <param name="living"></param>
        /// <returns></returns>
        private List<MagicalTask> GetValidTasks(Living living)
        {
            List<MagicalTask> result;

            lock (this.SyncObject)
            {
                result = this.FilterByValidTasks(living, this.Tasks);
            }

            return result;
        }

        /// <summary>
        /// Filters out the tasks that haven't had their dependencies successfully generated.
        /// </summary>
        /// <param name="tasks"></param>
        /// <returns></returns>
        private void FilterByDependencyStatus(List<MagicalTask> tasks)
        {
            if (tasks != null)
            {
                for (int i = tasks.Count - 1; i >= 0; i--)
                {
                    MagicalTask task = tasks[i];

                    if (!task.DependenciesGenerated)
                    {
                        tasks.RemoveAt(i);
                    }
                }
            }
        }

        /// <summary>
        /// Returns a list of the tasks that the specified creature can complete.
        /// </summary>
        /// <param name="living"></param>
        /// <param name="tasks"></param>
        /// <returns></returns>
        private List<MagicalTask> FilterByValidTasks(Living living, List<MagicalTask> tasks)
        {
            List<MagicalTask> validTasks = new List<MagicalTask>();
            for (int i = 0; i < tasks.Count; i++)
            {
                MagicalTask task = tasks[i];
                if (task.ReservedFor.Equals(living.ID))
                {
                    validTasks.Add(task);
                }
                else if (task.ReservedFor.Equals(Guid.Empty) && task.ToilingWorker.Equals(Guid.Empty))
                {
                    if (this.IsTaskValid(living, task))
                    {
                        validTasks.Add(task);
                    }
                }
            }

            return validTasks;
        }

        private bool IsTaskValid(Living living, MagicalTask task)
        {
            foreach (Qualification qualification in task.Qualifications)
            {
                if (qualification.ArePreconditionsMet() && qualification.IsQualified(living))
                {
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Generates the unique dependencies for the task and all of it's child tasks.
        /// </summary>
        private void CreateDependencies(MagicalTask task, Living living)
        {
            if (!task.DependenciesGenerated)
            {
                bool success = task.CreateDependencies(living);
                if (success)
                {
                    task.DependenciesGenerated = true;
                }
            }

            if (task.DependenciesGenerated)
            {
                ObservableCollection<MagicalTask> childTasks = task.Dependencies.PreRequisite;
                foreach (MagicalTask childTask in childTasks)
                {
                    this.CreateDependencies(childTask, living);
                }
            }
        }

        /// <summary>
        /// Gets the deepest children tasks in the specified task. Returns the parent task if there are no child tasks.
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        private List<MagicalTask> GetDeepestTasks(MagicalTask task)
        {
            List<MagicalTask> deepest = new List<MagicalTask>();

            if (task.Dependencies.PreRequisite.Any())
            {
                foreach (MagicalTask childTask in task.Dependencies.PreRequisite)
                {
                    deepest.AddRange(this.GetDeepestTasks(childTask));
                }
            }
            else
            {
                deepest.Add(task);
            }

            return deepest;
        }

        /// <summary>
        /// Reserve all tasks bound with the specified boundID for the specified creature.
        /// </summary>
        /// <param name="task"></param>
        /// <param name="l"></param>
        /// <param name="boundID"></param>
        /// <param name="recursionTask">The task to recurse over.</param>
        private void ReserveBoundTree(Living l, Guid boundID, MagicalTask recursionTask)
        {
            //If the same creature that needs to do the parent task needs to do the child task too...
            if (recursionTask.BoundID.Equals(boundID))
            {
                recursionTask.ReservedFor = l.ID;
            }

            if (recursionTask.Dependencies.PreRequisite.Count > 0)
            {
                foreach (MagicalTask item in recursionTask.Dependencies.PreRequisite)
                {
                    this.ReserveBoundTree(l, boundID, item);
                }
            }
        }
    }
}