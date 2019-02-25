using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.World.Data;
using MagicalLifeGUIWindows.GUI;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Input.Comparators;
using MagicalLifeGUIWindows.Input.History;
using MagicalLifeGUIWindows.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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

        public static MouseListener MouseListener { get; set; }

        private static readonly BoundsSorter BoundSorter = new BoundsSorter();

        private static readonly ContainerSorter containerSorter = new ContainerSorter();

        private static readonly ClickBoundsSorter ClickBoundsSorter = new ClickBoundsSorter();

        /// <summary>
        /// Constructs the <see cref="BoundHandler"/> class.
        /// </summary>
        public static void Initialize()
        {
            MouseListener = new MouseListener();
            MouseListener.MouseClicked += MouseListener_MouseClicked;
            MouseListener.MouseDoubleClicked += MouseListener_MouseDoubleClicked;
            MouseListener.MouseWheelMoved += MouseListener_MouseWheelMoved;
            MouseListener.MouseDrag += MouseListner_MouseDrag;
        }

        private static void MouseListner_MouseDrag(object sender, MouseEventArgs e)
        {
            //Don't need this yet
        }

        private static void MouseListener_MouseWheelMoved(object sender, MouseEventArgs e)
        {
            //Don't need this yet
        }

        private static void MouseListener_MouseDoubleClicked(object sender, MouseEventArgs e)
        {
            ContainerDoubleClick(e);
        }

        private static void MouseListener_MouseClicked(object sender, MouseEventArgs e)
        {
            ContainerClick(e);
        }

        /// <summary>
        /// Handles a click.
        /// </summary>
        /// <param name="clickData"></param>
        /// <param name="time"></param>
        public static void UpdateMouseInput(GameTime time)
        {
            MouseListener.Update(time);
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
                GUIContainer youngest = GetYoungestChild(item);
                if (youngest.Visible && youngest.DrawingBounds.Contains(clickData.Position))
                {
                    Click(clickData, youngest.Controls, youngest);
                    MasterLog.DebugWriteLine("Clicking in menu: " + youngest.GetType().FullName);
                    return;
                }
            }

            //If the click isn't in a GUI, then it must be in the map...
            MouseEventArgs transformed = TransformViaCamera(clickData);
            InputHistory.MapMouseClick(transformed);
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
            MasterLog.DebugWriteLine("Click position: " + clickData.Position.ToString());

            for (int i = 0; i < length; i++)
            {
                item = Options[i];

                MasterLog.DebugWriteLine(item.GetType().ToString() + " gui bounds: " + item.MouseBounds.Bounds.ToString());

                if (focus == -1 && item.MouseBounds.Bounds.Contains(clickData.Position.X - container.DrawingBounds.X, clickData.Position.Y - container.DrawingBounds.Y))
                {
                    item.HasFocus = true;
                    focus = i;
                    MasterLog.DebugWriteLine(item.GetType().ToString() + " with a bounds of " + item.MouseBounds.Bounds.ToString() + "was clicked on");
                }
                else
                {
                    item.HasFocus = false;
                    MasterLog.DebugWriteLine(item.GetType().ToString() + " with a bounds of " + item.MouseBounds.Bounds.ToString() + "was not clicked on");
                }
            }

            if (focus != -1)
            {
                MasterLog.DebugWriteLine("Clicking on item: " + Options[focus].GetType().FullName);
                Options[focus].Click(clickData, container);
            }
        }

        private static void ContainerDoubleClick(MouseEventArgs clickData)
        {
            foreach (GUIContainer item in GUIWindows)
            {
                GUIContainer youngest = GetYoungestChild(item);
                if (youngest.Visible && youngest.DrawingBounds.Contains(clickData.Position))
                {
                    DoubleClick(clickData, youngest.Controls, youngest);
                    return;
                }
            }

            MouseEventArgs transformed = TransformViaCamera(clickData);
            //TODO: Make a special map double click handler
            InputHistory.MapMouseClick(transformed);
        }

        /// <summary>
        /// Handles who gets the double click event.
        /// </summary>
        /// <param name="clickData"></param>
        private static void DoubleClick(MouseEventArgs clickData, List<GUIElement> Options, GUIContainer container)
        {
            int focus = -1;
            int length = Options.Count;
            GUIElement item = null;

            MasterLog.DebugWriteLine("Double click position: " + clickData.Position.ToString());

            for (int i = 0; i < length; i++)
            {
                item = Options[i];

                MasterLog.DebugWriteLine(item.GetType().ToString() + " gui bounds: " + item.MouseBounds.Bounds.ToString());

                if (focus == -1 && item.MouseBounds.Bounds.Contains(clickData.Position.X, clickData.Position.Y))
                {
                    item.HasFocus = true;
                    focus = i;
                    MasterLog.DebugWriteLine(item.GetType().ToString() + " with a bounds of " + item.MouseBounds.Bounds.ToString() + "was double clicked on");
                }
                else
                {
                    item.HasFocus = false;
                    MasterLog.DebugWriteLine(item.GetType().ToString() + " with a bounds of " + item.MouseBounds.Bounds.ToString() + "was not double clicked on");
                }
            }

            if (focus != -1)
            {
                Options[focus].DoubleClick(clickData, container);
            }
        }

        private static GUIContainer GetYoungestChild(GUIContainer container)
        {
            if (container.Child != null)
            {
                if (container.Child.Child != null)
                {
                    return GetYoungestChild(container.Child);
                }
                else
                {
                    return container.Child;
                }
            }
            else
            {
                return container;
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

            if (container.Visible)
            {
                ShowLast();
            }
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

        private static void ShowLast()
        {
            GUIWindows[GUIWindows.Count - 1].Visible = true;
        }

        /// <summary>
        /// Sets that container as the visible container, and gives it priority.
        /// </summary>
        /// <param name="container"></param>
        public static void Popup(GUIContainer container)
        {
            if (GUIWindows.Contains(container))
            {
                MenuHandler.Clear();
                container.Visible = true;
                container.Priority = RenderingData.GetGUIContainerPriority();

                GUIWindows.Remove(container);
                GUIWindows.Add(container);
            }
            else
            {
                MenuHandler.Clear();
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

        /// <summary>
        /// Transforms the old <see cref="MouseEventArgs"/> into a new one that takes into account the camera system.
        /// </summary>
        /// <param name="old"></param>
        /// <returns></returns>
        public static MouseEventArgs TransformViaCamera(MouseEventArgs old)
        {
            if (World.Dimensions.Count > 0)
            {
                //The new position adjusted for the camera
                Point position = RenderInfo.Camera2D.ScreenToWorld(old.Position.ToVector2()).ToPoint();
                //The previous state adjusted for the camera
                MouseState previousState = new MouseState(position.X, position.Y, old.ScrollWheelValue, old.PreviousState.LeftButton,
                    old.PreviousState.MiddleButton, old.PreviousState.RightButton, old.PreviousState.XButton1, old.PreviousState.XButton2);

                MouseState currentState = new MouseState(position.X, position.Y, old.ScrollWheelValue, old.CurrentState.LeftButton,
                    old.CurrentState.MiddleButton, old.CurrentState.RightButton, old.CurrentState.XButton1, old.CurrentState.XButton2);

                return new MouseEventArgs(MouseListener.ViewportAdapter, old.Time, previousState, currentState, old.Button);
            }
            else
            {
                return old;
            }
        }
    }
}