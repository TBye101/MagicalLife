using System.Collections.Generic;
using MonoGUI.MonoGUI.Reusable;

namespace MonoGUI.MonoGUI.Input.Comparators
{
    /// <summary>
    /// This class knows how to compare two <see cref="ClickBounds"/> objects.
    /// </summary>
    public class BoundsSorter : IComparer<GUIElement>
    {
        public int Compare(GUIElement x, GUIElement y)
        {
            return x.MouseBounds.Priority.CompareTo(y.MouseBounds.Priority);
        }
    }
}