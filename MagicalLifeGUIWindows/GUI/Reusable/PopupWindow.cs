using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalLifeAPI.DataTypes;
using MagicalLifeGUIWindows.GUI.Reusable.Premade;
using Microsoft.Xna.Framework;

namespace MagicalLifeGUIWindows.GUI.Reusable
{
    /// <summary>
    /// A window that can be closed as well as moved.
    /// </summary>
    public abstract class PopupWindow : GUIContainer
    {
        public PopupWindow(string image, Rectangle drawingBounds) : base(image, drawingBounds)
        {
            this.Controls.Add(new WindowX(new Point2D(drawingBounds.Width, drawingBounds.Height)));
        }
    }
}
