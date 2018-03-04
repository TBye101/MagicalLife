using MagicalLifeGUIWindows.GUI.Reusable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.Input
{
    /// <summary>
    /// This class knows how to compare two <see cref="GUIContainer"/> objects.
    /// </summary>
    public class ContainerSorter : IComparer<GUIContainer>
    {
        public int Compare(GUIContainer x, GUIContainer y)
        {
            int ret = x.Priority.CompareTo(y.Priority);
            return ret;
        }
    }
}
