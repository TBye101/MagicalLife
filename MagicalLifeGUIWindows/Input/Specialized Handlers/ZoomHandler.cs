using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeGUIWindows.Input.History;
using MagicalLifeGUIWindows.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.Input.Specialized_Handlers
{
    public class ZoomHandler
    {
        /// <summary>
        /// The most zoomed out the player can get.
        /// </summary>
        private static readonly float MinZoom = 1F;

        /// <summary>
        /// The most zoomed in the player can get.
        /// </summary>
        private static readonly float MaxZoom = 4F;


        public ZoomHandler()
        {
            BoundHandler.MouseListner.MouseWheelMoved += this.MouseListner_MouseWheelMoved;
        }

        private void MouseListner_MouseWheelMoved(object sender, MonoGame.Extended.Input.InputListeners.MouseEventArgs e)
        {
            float previous = e.PreviousState.ScrollWheelValue;
            float current = e.ScrollWheelValue;

            float change = (previous - current) / 1000;

            //Ensure that zoom is above the minimum.
            float aboveMin = Math.Max(ZoomHandler.MinZoom, RenderInfo.Zoom - change);

            //Ensure that zoom is below the maximum.
            float belowMaxAndAboveMin = Math.Min(ZoomHandler.MaxZoom, aboveMin);

            RenderInfo.Zoom = belowMaxAndAboveMin;
            MasterLog.DebugWriteLine("Zoom: " + RenderInfo.Zoom.ToString());
        }
    }
}
