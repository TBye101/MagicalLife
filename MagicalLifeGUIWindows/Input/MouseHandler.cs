using System.Diagnostics;
using Microsoft.Xna.Framework;
using MonoGame.Extended.ViewportAdapters;
using MonoGame.Extended.Input.InputListeners;
using Microsoft.Xna.Framework.Input;
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

        /// <summary>
        /// Holds the last state of the mouse.
        /// </summary>
        private static MouseState LastMouseAction { get; set; } = new MouseState();

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
            Debug.WriteLine("Mouse moved!");
        }

        private static void MouseListener_MouseDoubleClicked(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("Double click!");
        }

        private static void MouseListener_MouseClicked(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("Mouse click!");
        }

        /// <summary>
        /// Handles a click.
        /// </summary>
        /// <param name="clickData"></param>
        public static void UpdateMouseInput(GameTime time)
        {
            MouseListner.Update(time);
        }

        private static void Process(MouseState clickData)
        {
            foreach (ClickBounds item in Bounds)
            {
                if (item.Bounds.Contains(clickData.Position.X, clickData.Position.Y))
                {
                    item.ClickMe(clickData);
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