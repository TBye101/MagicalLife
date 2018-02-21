using MagicalLifeRenderEngine.Main.GUI.Click;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.Reusable
{
    /// <summary>
    /// A generic button class for use with the monogame framework, as well as the MagicalLifeGUI and API.
    /// </summary>
    public abstract class MonoButton : GUIElement
    {
        public MonoButton(string imageName, Rectangle displayArea, string text = "") : base(Game1.AssetManager.Load<Texture2D>(imageName), displayArea, int.MaxValue)
        {
            this.Text = text;
        }

        /// <summary>
        /// The text to display on the monolith.
        /// </summary>
        public string Text { get; set; } = "";
    }
}