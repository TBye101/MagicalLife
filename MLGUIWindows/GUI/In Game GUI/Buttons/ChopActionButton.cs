using Microsoft.Xna.Framework;
using MLAPI.Asset;
using MLAPI.Entity.AI.Task;
using MonoGUI.MonoGUI.Reusable;
using MonoGUI.MonoGUI.Reusable.Event;

namespace MLGUIWindows.GUI.In_Game_GUI.Buttons
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

        private void ChopActionButton_ClickEvent(object sender, ClickEventArgs e)
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