using Microsoft.Xna.Framework;

namespace MagicalLifeGUIWindows.GUI.Reusable
{
    /// <summary>
    /// A generic button class for use with the monogame framework, as well as the MagicalLifeGUI and API.
    /// </summary>
    public abstract class MonoButton : GUIElement
    {
        protected MonoButton(string imageName, Rectangle displayArea, string text = "", string font = "MainMenuFont24x") : base(imageName, displayArea, int.MaxValue, font)
        {
            this.Text = text;
        }

        /// <summary>
        /// The text to display on the monolith.
        /// </summary>
        public string Text { get; set; }
    }
}