using MagicalLifeAPI.Filing.Logging;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Input.Comparators;
using MagicalLifeGUIWindows.Input.History;
using MagicalLifeGUIWindows.Input.Specialized_Handlers;
using MagicalLifeGUIWindows.Map;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;
using System.Collections.Generic;

namespace MagicalLifeGUIWindows.Input
{
    /// <summary>
    /// Determines who is being clicked on when the user clicks.
    /// </summary>
    public static class BoundHandler
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

        private static ClickBoundsSorter ClickBoundsSorter = new ClickBoundsSorter();

        /// <summary>
        /// Anything in game that can be clicked on, that is not considered a menu or popup.
        /// Ex: a human, a sword.
        /// </summary>
        //public static List<ClickBounds> GameObjectBounds = new List<ClickBounds>();

        /// <summary>
        /// Constructs the <see cref="BoundHandler"/> class.
        /// </summary>
        public static void Initialize()
        {
            MouseListner.MouseClicked += MouseListener_MouseClicked;
            MouseListner.MouseDoubleClicked += MouseListener_MouseDoubleClicked;
            MouseListner.MouseWheelMoved += MouseListener_MouseWheelMoved;
            MouseListner.MouseDrag += MouseListner_MouseDrag;
            LivingBoundHandler.Initialize();
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
            ContainerDoubleClick(e);
        }

        private static void MouseListener_MouseClicked(object sender, MouseEventArgs e)
        {
            //MasterLog.DebugWriteLine("Single click detected: " + e.Position.ToString());
            ContainerClick(e);
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
        /// Handles container clicks before handling normal UI elements.
        /// </summary>
        /// <param name="clickData"></param>
        /// <returns></returns>
        private static void ContainerClick(MouseEventArgs clickData)
        {
            foreach (GUIContainer item in GUIWindows)
            {
                if (item.Visible && item.DrawingBounds.Contains(clickData.Position))
                {
                    Click(clickData, item.Controls, item);
                    MasterLog.DebugWriteLine("Clicking in menu: " + item.GetType().FullName);
                    return;
                }
            }

            if (!Click(clickData, Bounds))
            {
                InputHistory.MapMouseClick(clickData);
            }
        }

        /// <summary>
        /// Handles who gets the single click event from the options provided.
        /// </summary>
        /// <param name="clickData"></param>
        private static bool Click(MouseEventArgs clickData, List<GUIElement> Options)
        {
            int focus = -1;
            int length = Options.Count;
            GUIElement item = null;

            for (int i = 0; i < length; i++)
            {
                item = Options[i];
                if (focus == -1 && item.MouseBounds.Bounds.Contains(clickData.Position.X, clickData.Position.Y))
                {
                    item.HasFocus = true;
                    focus = i;
                }
                else
                {
                    item.HasFocus = false;
                }
            }

            if (focus != -1)
            {
                Options[focus].Click(clickData);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Handles who gets the single click event from the options provided.
        /// For use if a container is being used.
        /// </summary>
        /// <param name="clickData"></param>
        private static void Click(MouseEventArgs clickData, List<GUIElement> Options, GUIContainer container)
        {
            int focus = -1;
            int length = Options.Count;
            GUIElement item = null;

            for (int i = 0; i < length; i++)
            {
                item = Options[i];
                if (focus == -1 && item.MouseBounds.Bounds.Contains(clickData.Position.X + container.DrawingBounds.X, clickData.Position.Y - container.DrawingBounds.Y))
                {
                    item.HasFocus = true;
                    focus = i;
                }
                else
                {
                    item.HasFocus = false;
                }
            }

            if (focus != -1)
            {
                MasterLog.DebugWriteLine("Clicking on item: " + Options[focus].GetType().FullName);
                Options[focus].Click(clickData);
            }
        }

        private static void ContainerDoubleClick(MouseEventArgs clickData)
        {
            foreach (GUIContainer item in GUIWindows)
            {
                if (item.Visible && item.DrawingBounds.Contains(clickData.Position))
                {
                    DoubleClick(clickData, item.Controls);
                    return;
                }
            }

            DoubleClick(clickData, Bounds);
        }

        /// <summary>
        /// Handles who gets the double click event.
        /// </summary>
        /// <param name="clickData"></param>
        private static void DoubleClick(MouseEventArgs clickData, List<GUIElement> Options)
        {
            int focus = -1;
            //Focus is wrong somehow.
            int length = Options.Count;
            GUIElement item = null;

            for (int i = 0; i < length; i++)
            {
                item = Options[i];
                if (focus == -1 && item.MouseBounds.Bounds.Contains(clickData.Position.X, clickData.Position.Y))
                {
                    item.HasFocus = true;
                    focus = i;
                }
                else
                {
                    item.HasFocus = false;
                }
            }

            if (focus != -1)
            {
                Options[focus].DoubleClick(clickData);
            }
        }

        /// <summary>
        /// Adds a container.
        /// </summary>
        /// <param name="container"></param>
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
        /// Removes a container.
        /// </summary>
        /// <param name="container"></param>
        public static void RemoveContainer(GUIContainer container)
        {
            GUIWindows.Remove(container);
        }

        /// <summary>
        /// Adds a <see cref="ClickBounds"/> object to the system to be handled.
        /// </summary>
        /// <param name="bounds"></param>
        public static void AddGUIElement(GUIElement bounds)
        {
            int index = Bounds.BinarySearch(bounds, BoundSorter);
            if (index < 0)
            {
                index = ~index;
            }

            Bounds.Insert(index, bounds);
        }

        /// <summary>
        /// Removes a <see cref="ClickBounds"/> object from the system.
        /// </summary>
        /// <param name="bounds"></param>
        //public static void AddClickBounds(ClickBounds bounds)
        //{
        //    int index = GameObjectBounds.BinarySearch(bounds, ClickBoundsSorter);

        //    if (index < 0)
        //    {
        //        index = ~index;
        //    }

        //    GameObjectBounds.Insert(index, bounds);
        //}

        //public static void RemoveClickBounds(ClickBounds bounds)
        //{
        //    GameObjectBounds.Remove(bounds);
        //}

        /// <summary>
        /// Sets that container as the visible container, and gives it priority.
        /// </summary>
        /// <param name="container"></param>
        public static void Popup(GUIContainer container)
        {
            if (GUIWindows.Contains(container))
            {
                HideAll();
                container.Visible = true;
                container.Priority = RenderingData.GetGUIContainerPriority();

                GUIWindows.Remove(container);
                GUIWindows.Add(container);
            }
            else
            {
                HideAll();
                container.Visible = true;
                container.Priority = RenderingData.GetGUIContainerPriority();

                GUIWindows.Add(container);
            }
        }

        public static void HideAll()
        {
            foreach (GUIContainer item in GUIWindows)
            {
                item.Visible = false;
            }
        }
    }
}