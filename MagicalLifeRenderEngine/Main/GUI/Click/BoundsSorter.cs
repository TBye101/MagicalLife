using System.Collections.Generic;

namespace MagicalLifeRenderEngine.Main.GUI.Click
{
    /// <summary>
    /// This class knows how to compare two <see cref="ClickBounds"/> objects.
    /// </summary>
    public class BoundsSorter : IComparer<ClickBounds>
    {
        public int Compare(ClickBounds x, ClickBounds y)
        {
            return x.Priority.CompareTo(y.Priority);
        }
    }
}