using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Components.Generic.Renderable
{
    /// <summary>
    /// Used to compare <see cref="AbstractVisual"/>s for the <see cref="RenderQueue"/>.
    /// </summary>
    public class RenderQueueComparer : IComparer<AbstractVisual>
    {
        public int Compare(AbstractVisual x, AbstractVisual y)
        {
            if (x.Priority == y.Priority)
            {
                //They are equal in priority.
                return 0;
            }

            if (x.Priority > y.Priority)
            {
                //x should be before y in priority.
                return 1;
            }
            else
            {
                //x should be behind y.
                return -1;
            }
        }
    }
}
