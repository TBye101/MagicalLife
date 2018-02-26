using MagicalLifeAPI.Filing.Logging;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input.InputListeners;
using System;
using System.Collections.Generic;
using MagicalLifeGUIWindows.GUI.Reusable;

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
        private static List<GUIElement> Bounds = new List<GUIElement>();

        public static MouseListener MouseListner = new MouseListener();

        private static BoundsSorter BoundSorter = new BoundsSorter();

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
            foreach (GUIElement item in Bounds)
            {
                MasterLog.DebugWriteLine("Bounds: " + item.MouseBounds.Bounds.ToString());
                if (item.MouseBounds.Bounds.Contains(clickData.Position.X, clickData.Position.Y))
                {
                    MasterLog.DebugWriteLine("Single Click Accepted: " + item.MouseBounds.Bounds.ToString());
                    item.Click(clickData);
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
            foreach (GUIElement item in Bounds)
            {
                if (item.MouseBounds.Bounds.Contains(clickData.Position.X, clickData.Position.Y))
                {
                    MasterLog.DebugWriteLine("Double Click Accepted: " + item.MouseBounds.Bounds.ToString());
                    item.DoubleClick(clickData);
                    break;
                }
            }
        }

        /// <summary>
        /// Adds a <see cref="ClickBounds"/> object to the system to be handled.
        /// </summary>
        /// <param name="bounds"></param>
        public static void AddClickBounds(GUIElement bounds)
        {
            MasterLog.DebugWriteLine(bounds.MouseBounds.Bounds.ToString());

            int index = Bounds.BinarySearch(bounds, BoundSorter);
            if (index < 0)
            {
                index = ~index;
            }

            Bounds.Insert(index, bounds);
        }

        /// <summary>
        /// Removes a <see cref="ClickBounds"/> object by ID.
        /// </summary>
        /// <param name="boundsID"></param>
        public static void RemoveClickBounds(Guid boundsID)
        {
            foreach (GUIElement item in Bounds)
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