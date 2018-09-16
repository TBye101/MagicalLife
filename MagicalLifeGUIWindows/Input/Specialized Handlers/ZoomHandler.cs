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
        public ZoomHandler()
        {
            BoundHandler.MouseListner.MouseWheelMoved += this.MouseListner_MouseWheelMoved;
        }

        private void MouseListner_MouseWheelMoved(object sender, MonoGame.Extended.Input.InputListeners.MouseEventArgs e)
        {
            float previous = e.PreviousState.ScrollWheelValue;
            float current = e.ScrollWheelValue;

            float change = (previous - current) / 1000;

            RenderingPipe.Zoom -= change;
        }
    }
}
