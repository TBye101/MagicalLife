using MagicalLifeRenderEngine.Main.GUI.Click;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalLifeGUIWindows;

namespace MagicalLifeGUIWindows.GUI.Reusable
{
    /// <summary>
    /// A generic button class for use with the monogame framework, as well as the MagicalLifeGUI and API.
    /// </summary>
    public class MonoButton
    {
        public MonoButton(string imageName, Rectangle displayArea, string text = "")
        {
            this.Image = Game1.AssetManager.Load<Texture2D>(imageName);
            this.Text = text;
            this.MouseBounds = new ClickBounds(displayArea, -1);
        }

        /// <summary>
        /// The text to display on the monolith.
        /// </summary>
        public string Text { get; set; } = "";

        /// <summary>
        /// The image of the button.
        /// </summary>
        public Texture2D Image { get; protected set; }

        /// <summary>
        /// The visibility of this button.
        /// </summary>
        public bool Visible { get; set; } = true;

        /// <summary>
        /// The area on the screen to draw the button at.
        /// </summary>
        public Rectangle DrawingBounds { get; set; }

        /// <summary>
        /// The click bounds, which contains the <see cref="DrawingBounds"/>.
        /// </summary>
        public ClickBounds MouseBounds { get; set; }
    }
}
