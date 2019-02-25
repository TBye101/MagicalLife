using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Entity.AI.Task;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.In
{
    public class ChopActionButton : MonoButton
    {
        protected int GreyTextureIndex;
        protected int GoldTextureIndex;

        public ChopActionButton() : base(TextureLoader.GUIAxeButtonGray, GetDisplayArea(), true)
        {
            this.GreyTextureIndex = AssetManager.GetTextureIndex(TextureLoader.GUIAxeButtonGray);
            this.GoldTextureIndex = AssetManager.GetTextureIndex(TextureLoader.GUIAxeButtonGold);
        }

        private static Rectangle GetDisplayArea()
        {
            int x = InGameGUILayout.ChopActionButtonX;
            int y = InGameGUILayout.ActionButtonY;
            int width = InGameGUILayout.ActionButtonSize;
            int height = InGameGUILayout.ActionButtonSize;

            return new Rectangle(x, y, width, height);
        }

        public override void Click(MouseEventArgs e, GUIContainer container)
        {
            if (InGameGUI.Selected == ActionSelected.Chop)
            {
                InGameGUI.Selected = ActionSelected.None;
                this.TextureID = this.GreyTextureIndex;
            }
            else
            {
                InGameGUI.Selected = ActionSelected.Chop;
                this.TextureID = this.GoldTextureIndex;
            }
        }

        public override void DoubleClick(MouseEventArgs e, GUIContainer container)
        {
            //Nothing to see here
        }
    }
}