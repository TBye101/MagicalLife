using MagicalLifeAPI.Error.InternalExceptions;
using System.Collections.Generic;

namespace MagicalLifeGUIWindows.Input.Comparators
{
    /// <summary>
    /// Used to sort <see cref="ClickBounds"/>
    /// </summary>
    public class ClickBoundsSorter : Comparer<ClickBounds>
    {
        public override int Compare(ClickBounds x, ClickBounds y)
        {
            if (x.Bounds.X != y.Bounds.Y)
            {
                return x.Bounds.X.CompareTo(y.Bounds.Y);
            }

            if (x.Bounds.Y != y.Bounds.Y)
            {
                return x.Bounds.Y.CompareTo(y.Bounds.Y);
            }

            if (x.Bounds.Width != y.Bounds.Width)
            {
                return x.Bounds.Width.CompareTo(y.Bounds.Width);
            }

            if (x.Bounds.Height != y.Bounds.Height)
            {
                return x.Bounds.Height.CompareTo(y.Bounds.Height);
            }

            if (x.Priority != y.Priority)
            {
                return x.Priority.CompareTo(y.Priority);
            }

            throw new DuplicateEntryException("There's two objects that are identical for all practical purposes!");
        }
    }
}