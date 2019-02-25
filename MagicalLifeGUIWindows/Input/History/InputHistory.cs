using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.GUI;
using MonoGame.Extended.Input.InputListeners;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicalLifeGUIWindows.Input.History
{
    /// <summary>
    /// Used to keep a history of input.
    /// </summary>
    public static class InputHistory
    {
        /// <summary>
        /// If true, the shift key is down.
        /// </summary>
        private static bool ShiftDown = false;

        /// <summary>
        /// If true, the ctrl key is down.
        /// </summary>
        private static bool CtrlDown = false;

        /// <summary>
        /// The last # of actions done by the mouse.
        /// </summary>
        public static FixedSizedQueue<HistoricalInput> History { get; private set; } = new FixedSizedQueue<HistoricalInput>(100);

        public static event Action InputAdded;

        private static readonly HistoricalInputFactory Factory = new HistoricalInputFactory();

        public static List<Selectable> Selected = new List<Selectable>();

        /// <summary>
        /// Raises the world generated event.
        /// </summary>
        /// <param name="e"></param>
        public static void InputAddedHandler()
        {
            InputAdded?.Invoke();
        }

        public static void Initialize()
        {
            BoundHandler.MouseListener.MouseDoubleClicked += MouseListner_MouseDoubleClicked;
            BoundHandler.MouseListener.MouseDragStart += MouseListner_MouseDragStart;
            BoundHandler.MouseListener.MouseDragEnd += MouseListner_MouseDragEnd;
            BoundHandler.MouseListener.MouseWheelMoved += MouseListner_MouseWheelMoved;
            KeyboardHandler.KeysPressed += KeyboardHandler_KeysPressed;
            KeyboardHandler.KeysReleased += KeyboardHandler_KeysReleased;
            BoundHandler.MouseListener.MouseDrag += MouseListner_MouseDrag;
        }

        private static void MouseListner_MouseDrag(object sender, MouseEventArgs e)
        {
            //Haven't done anything here yet
        }

        private static void KeyboardHandler_KeysReleased(object sender, Microsoft.Xna.Framework.Input.Keys e)
        {
            switch (e)
            {
                case Microsoft.Xna.Framework.Input.Keys.LeftShift:
                case Microsoft.Xna.Framework.Input.Keys.RightShift:
                    ShiftDown = false;
                    break;

                case Microsoft.Xna.Framework.Input.Keys.LeftControl:
                case Microsoft.Xna.Framework.Input.Keys.RightControl:
                    CtrlDown = false;
                    break;

                default:
                    break;
            }
        }

        private static void KeyboardHandler_KeysPressed(object sender, Microsoft.Xna.Framework.Input.Keys e)
        {
            switch (e)
            {
                case Microsoft.Xna.Framework.Input.Keys.LeftShift:
                case Microsoft.Xna.Framework.Input.Keys.RightShift:
                    ShiftDown = true;
                    break;

                case Microsoft.Xna.Framework.Input.Keys.LeftControl:
                case Microsoft.Xna.Framework.Input.Keys.RightControl:
                    CtrlDown = true;
                    break;

                default:
                    break;
            }
        }

        private static void MouseListner_MouseWheelMoved(object sender, MouseEventArgs e)
        {
            //We don't need this yet
        }

        private static void MouseListner_MouseDragEnd(object sender, MouseEventArgs e)
        {
            //We don't need this yet
        }

        private static void MouseListner_MouseDragStart(object sender, MouseEventArgs e)
        {
            //We don't need this yet
        }

        private static void MouseListner_MouseDoubleClicked(object sender, MouseEventArgs e)
        {
            //We don't need this yet
        }

        /// <summary>
        /// Used to handle the new selection state as dictated by the last <see cref="HistoricalInput"/> added to <see cref="History"/>.
        /// </summary>
        private static void HandleNewSelectionHistory()
        {
            HistoricalInput lastHistory = History.Last();

            if (!lastHistory.OrderedToTile)
            {
                if (lastHistory.DeselectingAll)
                {
                    Selected.Clear();
                    MasterLog.DebugWriteLine("Deselected all");
                }

                foreach (Selectable item in lastHistory.DeselectSome)
                {
                    Selected.Remove(item);
                    MasterLog.DebugWriteLine("Deselected: " + item.MapLocation.ToString());
                }

                Selected.AddRange(lastHistory.Selected);
            }
        }

        /// <summary>
        /// Handles a mouse click that is somewhere in the game.
        /// </summary>
        /// <param name="e"></param>
        public static void MapMouseClick(MouseEventArgs e)
        {
            HistoricalInput historicalInput = Factory.Generate(new InputEventArgs(ShiftDown, CtrlDown, e));

            if (historicalInput != null)
            {
                History.Enqueue(historicalInput);
                HandleNewSelectionHistory();
                InputAddedHandler();
            }
        }
    }
}