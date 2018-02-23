using MagicalLifeAPI.Filing.Logging;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input.InputListeners;
using System;
using System.Collections.Generic;

namespace MagicalLifeRenderEngine.Main.GUI.Click
{
    /// <summary>
    /// Determines who is being clicked on when the user clicks.
    /// </summary>
    public static class MouseHandler
    {
        /// <summary>
        /// Contains all of the ClickBounds this class handles.
        /// </summary>
        private static SortedSet<ClickBounds> Bounds = new SortedSet<ClickBounds>(new BoundsSorter());

        public static MouseListener MouseListner = new MouseListener();

        /// <summary>
        /// Constructs the <see cref="MouseHandler"/> class.
        /// </summary>
        public static void Initialize()
        {
            MouseListner.MouseClicked += MouseListener_MouseClicked;
            MouseListner.MouseDoubleClicked += MouseListener_MouseDoubleClicked;
            MouseListner.MouseWheelMoved += MouseListener_MouseWheelMoved;
        }

        private static void MouseListener_MouseWheelMoved(object sender, MouseEventArgs e)
        {
        }

        private static void MouseListener_MouseDoubleClicked(object sender, MouseEventArgs e)
        {
            MasterLog.DebugWriteLine("Double click detected: " + e.Position.ToString());
            DoubleClick(e);
        }

        private static void MouseListener_MouseClicked(object sender, MouseEventArgs e)
        {
            MasterLog.DebugWriteLine("Single click detected: " + e.Position.ToString());
            Click(e);
        }

        /// <summary>
        /// Handles a click.
        /// </summary>
        /// <param name="clickData"></param>
        /// <param name="time"></param>
        public static void UpdateMouseInput(GameTime time)
        {
            MouseListner.Update(time);
        }

        /// <summary>
        /// Handles who gets the single click event.
        /// </summary>
        /// <param name="clickData"></param>
        private static void Click(MouseEventArgs clickData)
        {
            foreach (ClickBounds item in Bounds)
            {
                MasterLog.DebugWriteLine("Bounds: " + item.Bounds.ToString());
                if (item.Bounds.Contains(clickData.Position.X, clickData.Position.Y))
                {
                    MasterLog.DebugWriteLine("Single Click Accepted: " + item.Bounds.ToString());
                    item.ClickMe(clickData);
                    break;
                }
            }
        }

        /// <summary>
        /// Handles who gets the double click event.
        /// </summary>
        /// <param name="clickData"></param>
        private static void DoubleClick(MouseEventArgs clickData)
        {
            foreach (ClickBounds item in Bounds)
            {
                if (item.Bounds.Contains(clickData.Position.X, clickData.Position.Y))
                {
                    MasterLog.DebugWriteLine("Double Click Accepted: " + item.Bounds.ToString());
                    item.DoubleClickMe(clickData);
                    break;
                }
            }
        }

        /// <summary>
        /// Adds a <see cref="ClickBounds"/> object to the system to be handled.
        /// </summary>
        /// <param name="bounds"></param>
        public static void AddClickBounds(ClickBounds bounds)
        {
            MasterLog.DebugWriteLine(bounds.Bounds.ToString());
            Bounds.Add(bounds);
        }

        /// <summary>
        /// Removes a <see cref="ClickBounds"/> object by ID.
        /// </summary>
        /// <param name="boundsID"></param>
        public static void RemoveClickBounds(Guid boundsID)
        {
            foreach (ClickBounds item in Bounds)
            {
                if (item.ID == boundsID)
                {
                    Bounds.Remove(item);
                    break;
                }
            }
        }
    }
}