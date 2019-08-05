using System.Collections.Generic;
using MonoGUI.MonoGUI.Reusable;

namespace MonoGUI.MonoGUI.Input.Comparators
{
    /// <summary>
    /// This class knows how to compare two <see cref="GuiContainer"/> objects.
    /// </summary>
    public class ContainerSorter : IComparer<GuiContainer>
    {
        public int Compare(GuiContainer x, GuiContainer y)
        {
            int ret = x.Priority.CompareTo(y.Priority);
            return ret;
        }
    }
}