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
            this.ClickEvent += this.ChopActionButton_ClickEvent;
        }

        private void ChopActionButton_ClickEvent(object sender, Reusable.Event.ClickEventArgs e)
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

        private static Rectangle GetDisplayArea()
        {
            int x = InGameGUILayout.ChopActionButtonX;
            int y = InGameGUILayout.ActionButtonY;
            int width = InGameGUILayout.ActionButtonSize;
            int height = InGameGUILayout.ActionButtonSize;

            return new Rectangle(x, y, width, height);
        }
    }
}