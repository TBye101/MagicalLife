using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Time
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
