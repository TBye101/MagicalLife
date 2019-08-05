using System.Collections.Generic;
using MonoGUI.MonoGUI.Reusable;

namespace MonoGUI.MonoGUI.Input.Comparators
{
    /// <summary>
    /// This class knows how to compare two <see cref="ClickBounds"/> objects.
    /// </summary>
    public class BoundsSorter : IComparer<GuiElement>
    {
        public int Compare(GuiElement x, GuiElement y)
        {
            return x.MouseBounds.Priority.CompareTo(y.MouseBounds.Priority);
        }
    }
}