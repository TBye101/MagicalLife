using MonoGame.Extended.Input.InputListeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.Reusable.Event
{
    /// <summary>
    /// Holds some data about click events.
    /// </summary>
    public class ClickEventArgs : EventArgs
    {
        public MouseEventArgs MouseEventArgs { get; set; }

        /// <summary>
        /// The container which was clicked in.
        /// </summary>
        public GUIContainer GUIContainer { get; set; }

        /// <param name="guiContainer">The container which was clicked in.</param>
        public ClickEventArgs(MouseEventArgs mouseEventArgs, GUIContainer guiContainer)
        {
            this.MouseEventArgs = mouseEventArgs;
            this.GUIContainer = guiContainer;
        }
    }
}
