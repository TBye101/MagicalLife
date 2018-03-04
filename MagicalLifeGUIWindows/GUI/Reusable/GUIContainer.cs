using MagicalLifeAPI.Universal;
using MagicalLifeGUIWindows.Map;
using MagicalLifeRenderEngine.Main.GUI.Click;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.Reusable
{
    /// <summary>
    /// Contains other <see cref="GUIElement"/>s.
    /// All coordinates of <see cref="GUIElement"/> objects are relative to the position of this container.
    /// </summary>
    public class GUIContainer : Unique
    {
        /// <summary>
        /// Constructs a new instance of the <see cref="GUIContainer"/> class.
        /// </summary>
        /// <param name="image">The texture of this GUI container.</param>
        /// <param name="drawingBounds">The bounds for which to draw the texture on the screen at.</param>
        /// <param name="priority">Determines if this GUI container should have priority over other GUI elements when sorting through input.</param>
        public GUIContainer(Texture2D image, Rectangle drawingBounds)
        {
            this.Image = image;
            this.DrawingBounds = drawingBounds;
            this.Controls = new List<GUIElement>();
            this.Priority = RenderingData.GetGUIContainerPriority();
        }

        /// <summary>
        /// The priority level of this <see cref="GUIContainer"/>
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// The area on the screen to draw the container at.
        /// </summary>
        public Rectangle DrawingBounds { get; set; }

        /// <summary>
        /// The visibility of this container.
        /// </summary>
        public bool Visible { get; set; } = true;

        /// <summary>
        /// The image of the container.
        /// Generally just a background for other GUIElements.
        /// </summary>
        public Texture2D Image { get; set; }

        /// <summary>
        /// The controls that are within this <see cref="GUIContainer"/>
        /// </summary>
        public List<GUIElement> Controls { get; set; }
    }
}
