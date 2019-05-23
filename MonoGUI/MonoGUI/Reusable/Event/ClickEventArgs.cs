using MonoGame.Extended.Input.InputListeners;
using System;

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
        public GuiContainer GUIContainer { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="mouseEventArgs"></param>
        /// <param name="guiContainer">The container which was clicked in.</param>
        public ClickEventArgs(MouseEventArgs mouseEventArgs, GuiContainer guiContainer)
        {
            this.MouseEventArgs = mouseEventArgs;
            this.GUIContainer = guiContainer;
        }
    }
}