using System.Collections.Generic;

namespace MagicalLifeGUIWindows.Input.Comparators
{
    /// <summary>
    /// Used to sort <see cref="ClickBounds"/>
    /// </summary>
    public class ClickBoundsSorter : Comparer<ClickBounds>
    {
        /// <summary>
        /// When overridden in a derived class, performs a comparison of two objects of the same type and returns a value indicating whether one object is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>
        /// A signed integer that indicates the relative values of <paramref name="x" /> and <paramref name="y" />, as shown in the following table.Value Meaning Less than zero
        /// <paramref name="x" /> is less than <paramref name="y" />.Zero
        /// <paramref name="x" /> equals <paramref name="y" />.Greater than zero
        /// <paramref name="x" /> is greater than <paramref name="y" />.
        /// </returns>
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

            return 0;
        }
    }
}