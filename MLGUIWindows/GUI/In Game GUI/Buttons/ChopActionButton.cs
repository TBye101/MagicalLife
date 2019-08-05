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

        public ChopActionButton() : base(TextureLoader.GuiAxeButtonGray, GetDisplayArea(), true)
        {
            this.GreyTextureIndex = AssetManager.GetTextureIndex(TextureLoader.GuiAxeButtonGray);
            this.GoldTextureIndex = AssetManager.GetTextureIndex(TextureLoader.GuiAxeButtonGold);
            this.ClickEvent += this.ChopActionButton_ClickEvent;
        }

        private void ChopActionButton_ClickEvent(object sender, ClickEventArgs e)
        {
            if (InGameGui.Selected == ActionSelected.Chop)
            {
                InGameGui.Selected = ActionSelected.None;
                this.TextureId = this.GreyTextureIndex;
            }
            else
            {
                InGameGui.Selected = ActionSelected.Chop;
                this.TextureId = this.GoldTextureIndex;
            }
        }

        private static Rectangle GetDisplayArea()
        {
            int x = InGameGuiLayout.ChopActionButtonX;
            int y = InGameGuiLayout.ActionButtonY;
            int width = InGameGuiLayout.ActionButtonSize;
            int height = InGameGuiLayout.ActionButtonSize;

            return new Rectangle(x, y, width, height);
        }
    }
}