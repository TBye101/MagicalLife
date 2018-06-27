using Microsoft.Xna.Framework;

namespace MagicalLifeGUIWindows.GUI.Reusable
{
    /// <summary>
    /// A generic button class for use with the monogame framework, as well as the MagicalLifeGUI and API.
    /// </summary>
    public abstract class MonoButton : GUIElement
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="imageName"></param>
        /// <param name="displayArea"></param>
        /// <param name="text"></param>
        /// <param name="isContained">If true, this GUI element is within a container.</param>
        /// <param name="font"></param>
        protected MonoButton(string imageName, Rectangle displayArea, bool isContained, string text = "", string font = "MainMenuFont24x") : base(imageName, displayArea, int.MaxValue, isContained, font)
        {
            this.Text = text;
        }

        /// <summary>
        /// The text to display on the monolith.
        /// </summary>
        public string Text { get; set; }
    }
}