using MagicalLifeAPI.Filing.Logging;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Input;
using Microsoft.Xna.Framework;
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
        private static List<GUIElement> Bounds = new List<GUIElement>();

        /// <summary>
        /// All of the GUI windows.
        /// </summary>
        public static List<GUIContainer> GUIWindows { get; private set; } = new List<GUIContainer>();

        public static MouseListener MouseListner = new MouseListener();

        private static BoundsSorter BoundSorter = new BoundsSorter();

        private static ContainerSorter containerSorter = new ContainerSorter();

        /// <summary>
        /// Constructs the <see cref="MouseHandler"/> class.
        /// </summary>
        public static void Initialize()
        {
            MouseListner.MouseClicked += MouseListener_MouseClicked;
            MouseListner.MouseDoubleClicked += MouseListener_MouseDoubleClicked;
            MouseListner.MouseWheelMoved += MouseListener_MouseWheelMoved;
            MouseListner.MouseDrag += MouseListner_MouseDrag;
        }



        private static void MouseListner_MouseDrag(object sender, MouseEventArgs e)
        {
            
        }

        private static void MouseListener_MouseWheelMoved(object sender, MouseEventArgs e)
        {
        }

        private static void MouseListener_MouseDoubleClicked(object sender, MouseEventArgs e)
        {
            //MasterLog.DebugWriteLine("Double click detected: " + e.Position.ToString());
            DoubleClick(e);
        }

        private static void MouseListener_MouseClicked(object sender, MouseEventArgs e)
        {
            //MasterLog.DebugWriteLine("Single click detected: " + e.Position.ToString());
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
            //Point loc = ApplyOffset(clickData.Position);
            //MasterLog.DebugWriteLine("Offset: " + loc.ToString());
            foreach (GUIElement item in Bounds)
            {
                //MasterLog.DebugWriteLine("Bounds: " + item.MouseBounds.Bounds.ToString());
                if (item.MouseBounds.Bounds.Contains(clickData.Position.X, clickData.Position.Y))
                {
                    //MasterLog.DebugWriteLine("Single Click Accepted: " + item.MouseBounds.Bounds.ToString());
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
                    //MasterLog.DebugWriteLine("Double Click Accepted: " + item.MouseBounds.Bounds.ToString());
                    item.DoubleClick(clickData);
                    break;
                }
            }
        }

        public static void AddContainer(GUIContainer container)
        {
            int index = GUIWindows.BinarySearch(container, containerSorter);
            if (index < 0)
            {
                index = ~index;
            }

            GUIWindows.Insert(index, container);
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
    }
}