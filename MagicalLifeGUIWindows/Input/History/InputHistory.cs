using MagicalLifeAPI.DataTypes;
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
        //TODO: Process input, determine which objects were interacted on (This might take a lot of classes). Then put those results into the queue

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

        private static HistoricalInputFactory Factory = new HistoricalInputFactory();

        public static List<Selectable> Selected = new List<Selectable>();

        /// <summary>
        /// Raises the world generated event.
        /// </summary>
        /// <param name="e"></param>
        public static void InputAddedHandler()
        {
            Action handler = InputAdded;
            if (handler != null)
            {
                handler();
            }
        }

        public static void Initialize()
        {
            BoundHandler.MouseListner.MouseDoubleClicked += MouseListner_MouseDoubleClicked;
            BoundHandler.MouseListner.MouseDragStart += MouseListner_MouseDragStart;
            BoundHandler.MouseListner.MouseDragEnd += MouseListner_MouseDragEnd;
            BoundHandler.MouseListner.MouseWheelMoved += MouseListner_MouseWheelMoved;
            KeyboardHandler.keyboardListener.KeyPressed += KeyboardListener_KeyPressed;
            KeyboardHandler.keyboardListener.KeyReleased += KeyboardListener_KeyReleased;
        }

        private static void KeyboardListener_KeyReleased(object sender, KeyboardEventArgs e)
        {
            switch (e.Key)
            {
                case Microsoft.Xna.Framework.Input.Keys.LeftShift:
                case Microsoft.Xna.Framework.Input.Keys.RightShift:
                    ShiftDown = false;
                    break;

                case Microsoft.Xna.Framework.Input.Keys.LeftControl:
                case Microsoft.Xna.Framework.Input.Keys.RightControl:
                    CtrlDown = false;
                    break;
            }
        }

        private static void KeyboardListener_KeyPressed(object sender, KeyboardEventArgs e)
        {
            switch (e.Key)
            {
                case Microsoft.Xna.Framework.Input.Keys.LeftShift:
                case Microsoft.Xna.Framework.Input.Keys.RightShift:
                    ShiftDown = true;
                    break;

                case Microsoft.Xna.Framework.Input.Keys.LeftControl:
                case Microsoft.Xna.Framework.Input.Keys.RightControl:
                    CtrlDown = true;
                    break;
            }
        }

        private static void MouseListner_MouseWheelMoved(object sender, MouseEventArgs e)
        {
            //History.Enqueue(Factory.Generate(new InputEventArgs(ShiftDown, CtrlDown, e)));
        }

        private static void MouseListner_MouseDragEnd(object sender, MouseEventArgs e)
        {
            //History.Enqueue(Factory.Generate(new InputEventArgs(ShiftDown, CtrlDown, e)));
        }

        private static void MouseListner_MouseDragStart(object sender, MouseEventArgs e)
        {
            //History.Enqueue(Factory.Generate(new InputEventArgs(ShiftDown, CtrlDown, e)));
        }

        private static void MouseListner_MouseDoubleClicked(object sender, MouseEventArgs e)
        {
            //History.Enqueue(Factory.Generate(new InputEventArgs(ShiftDown, CtrlDown, e)));
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
                }

                foreach (Selectable item in lastHistory.DeselectSome)
                {
                    Selected.Remove(item);
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