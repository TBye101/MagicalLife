using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.Reusable.API
{
    /// <summary>
    /// Anything that implements this can be scrolled forward and backward by external calls.
    /// </summary>
    public interface IScrollable
    {
        void Forward();

        void Backwards();
    }
}
