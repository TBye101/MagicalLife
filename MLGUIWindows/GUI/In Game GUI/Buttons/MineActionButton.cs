using Microsoft.Xna.Framework;
using MLAPI.Asset;
using MLAPI.Entity.AI.Task;
using MonoGUI.MonoGUI.Reusable;
using MonoGUI.MonoGUI.Reusable.Event;

namespace MLGUIWindows.GUI.In_Game_GUI.Buttons
{
    public class MineActionButton : MonoButton
    {
        protected int GreyTextureIndex;
        protected int GoldTextureIndex;

        public MineActionButton() : base(TextureLoader.GuiPickaxeButtonGrey, GetDisplayArea(), true)
        {
            this.GreyTextureIndex = AssetManager.GetTextureIndex(TextureLoader.GuiPickaxeButtonGrey);
            this.GoldTextureIndex = AssetManager.GetTextureIndex(TextureLoader.GuiPickaxeButtonGold);
            this.ClickEvent += this.MineActionButton_ClickEvent;
        }

        private void MineActionButton_ClickEvent(object sender, ClickEventArgs e)
        {
            if (InGameGui.Selected == ActionSelected.Mine)
            {
                InGameGui.Selected = ActionSelected.None;
                this.TextureId = this.GreyTextureIndex;
            }
            else
            {
                InGameGui.Selected = ActionSelected.Mine;
                this.TextureId = this.GoldTextureIndex;
            }
        }

        private static Rectangle GetDisplayArea()
        {
            int x = InGameGuiLayout.MineActionButtonX;
            int y = InGameGuiLayout.ActionButtonY;
            int width = InGameGuiLayout.ActionButtonSize;
            int height = InGameGuiLayout.ActionButtonSize;

            return new Rectangle(x, y, width, height);
        }
    }
}