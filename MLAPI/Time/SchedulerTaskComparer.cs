using System.Collections.Generic;

namespace MLAPI.Time
{
    /// <summary>
    /// Used to compare <see cref="SchedulerTask"/>.
    /// </summary>
    public class SchedulerTaskComparer : IComparer<SchedulerTask>
    {
        public int Compare(SchedulerTask x, SchedulerTask y)
        {
            return x.WakeUp.CompareTo(y.WakeUp);
        }
    }
}
