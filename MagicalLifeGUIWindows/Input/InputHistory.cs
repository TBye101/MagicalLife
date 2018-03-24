using MagicalLifeAPI.DataTypes;
using MonoGame.Extended.Input.InputListeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.Input
{
    /// <summary>
    /// Used to keep a history of input. 
    /// </summary>
    public static class InputHistory
    {
        /// <summary>
        /// The last # of actions done by the mouse.
        /// </summary>
        public static FixedSizedQueue<MouseEventArgs> History { get; private set; } = new FixedSizedQueue<MouseEventArgs>(100);

        public static void Initialize()
        {
            BoundHandler.MouseListner.MouseClicked += MouseListner_MouseClicked;
            BoundHandler.MouseListner.MouseDoubleClicked += MouseListner_MouseDoubleClicked;
            BoundHandler.MouseListner.MouseDragStart += MouseListner_MouseDragStart;
            BoundHandler.MouseListner.MouseDragEnd += MouseListner_MouseDragEnd;
            BoundHandler.MouseListner.MouseWheelMoved += MouseListner_MouseWheelMoved;
        }

        private static void MouseListner_MouseWheelMoved(object sender, MouseEventArgs e)
        {
            History.Enqueue(e);
        }

        private static void MouseListner_MouseDragEnd(object sender, MouseEventArgs e)
        {
            History.Enqueue(e);
        }

        private static void MouseListner_MouseDragStart(object sender, MouseEventArgs e)
        {
            History.Enqueue(e);
        }

        private static void MouseListner_MouseDoubleClicked(object sender, MouseEventArgs e)
        {
            History.Enqueue(e);
        }

        private static void MouseListner_MouseClicked(object sender, MouseEventArgs e)
        {
            History.Enqueue(e);
        }
    }
}
