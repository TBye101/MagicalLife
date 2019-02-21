using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Filing.Logging;
using System;

namespace MagicalLifeGUIWindows.Input.Specialized_Handlers
{
    public class ZoomHandler
    {
        /// <summary>
        /// The most zoomed out the player can get.
        /// </summary>
        private static readonly float MinZoom = .125F;

        /// <summary>
        /// The most zoomed in the player can get.
        /// </summary>
        private static readonly float MaxZoom = 4F;

        public ZoomHandler()
        {
            BoundHandler.MouseListener.MouseWheelMoved += this.MouseListner_MouseWheelMoved;
        }

        private void MouseListner_MouseWheelMoved(object sender, MonoGame.Extended.Input.InputListeners.MouseEventArgs e)
        {
            float previous = e.PreviousState.ScrollWheelValue;
            float current = e.ScrollWheelValue;

            float change = (previous - current) / 1000;

            if (change > 0)
            {
                RenderInfo.Camera2D.HandleInput(Rendering.Map.CameraMovementState.ZoomIn);
            }
            if (change < 0)
            {
                RenderInfo.Camera2D.HandleInput(Rendering.Map.CameraMovementState.ZoomOut);
            }
        }
    }
}