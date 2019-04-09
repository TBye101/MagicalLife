using MagicalLifeGUIWindows.GUI.Reusable;
using System.Collections.Generic;

namespace MagicalLifeGUIWindows.Input.Comparators
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