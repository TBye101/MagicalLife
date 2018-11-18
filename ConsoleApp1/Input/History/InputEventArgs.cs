using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.Input.History
{
    /// <summary>
    /// Used to hold the keyboard hotkey states and the mouse information.
    /// </summary>
    public class InputEventArgs
    {
        public MouseEventArgs MouseEventArgs { get; private set; }
        public bool ShiftDown { get; private set; }
        public bool CtrlDown { get; private set; }

        public InputEventArgs(bool shiftDown, bool ctrlDown, MouseEventArgs e)
        {
            this.ShiftDown = shiftDown;
            this.CtrlDown = ctrlDown;
            this.MouseEventArgs = e;
        }
    }
}