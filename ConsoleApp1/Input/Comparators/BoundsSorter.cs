using MagicalLifeGUIWindows.GUI.Reusable;
using System.Collections.Generic;

namespace MagicalLifeGUIWindows.Input.Comparators
{
    /// <summary>
    /// This class knows how to compare two <see cref="ClickBounds"/> objects.
    /// </summary>
    public class BoundsSorter : IComparer<GUIElement>
    {
        public int Compare(GUIElement x, GUIElement y)
        {
            int ret = x.MouseBounds.Priority.CompareTo(y.MouseBounds.Priority);
            return ret;
        }
    }
}