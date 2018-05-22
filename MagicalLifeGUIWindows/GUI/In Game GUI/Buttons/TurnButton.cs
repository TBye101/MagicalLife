using MagicalLifeAPI.Asset;
using MagicalLifeAPI.World;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.In_Game_GUI.Buttons
{
    public class TurnButton : MonoButton
    {
        /// <summary>
        /// The texture displayed by this button in-between turns.
        /// </summary>
        private Texture2D EndedTexture;

        /// <summary>
        /// The texture displayed by this button when it is the players turn.
        /// </summary>
        private Texture2D WaitTexture;

        public TurnButton(string font = "") : base("EndTurnButtonState1", GetLocation(), "", font)
        {
            this.WaitTexture = AssetManager.Textures[AssetManager.GetTextureIndex("EndTurnButtonState1")];
            this.EndedTexture = AssetManager.Textures[AssetManager.GetTextureIndex("EndTurnButtonState2")];
        }

        private void World_TurnEnd(object sender, WorldEventArgs e)
        {
            this.Image = this.EndedTexture;
        }

        private void World_TurnStart(object sender, WorldEventArgs e)
        {
            this.Image = this.WaitTexture;
        }

        public static Rectangle GetLocation()
        {
            int x = InGameGUILayout.TurnButtonX;
            int y = InGameGUILayout.TurnButtonY;
            int width = InGameGUILayout.TurnButtonWidth;
            int height = InGameGUILayout.TurnButtonHeight;

            return new Rectangle(x, y, width, height);
        }

        public override void Click(MouseEventArgs e)
        {
        }

        public override void DoubleClick(MouseEventArgs e)
        {
        }
    }
}