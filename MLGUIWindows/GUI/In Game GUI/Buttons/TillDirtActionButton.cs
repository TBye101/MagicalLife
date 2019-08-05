using Microsoft.Xna.Framework;
using MLAPI.Asset;
using MLAPI.Entity.AI.Task;
using MonoGUI.MonoGUI.Reusable;
using MonoGUI.MonoGUI.Reusable.Event;

namespace MLGUIWindows.GUI.In_Game_GUI.Buttons
{
    public class TillDirtActionButton : MonoButton
    {
        protected int HoeTextureIndex;
        protected int GoldTextureIndex;

        public TillDirtActionButton() : base(TextureLoader.GuiHoeButtonGrey, GetDisplayArea(), true)
        {
            this.HoeTextureIndex = AssetManager.GetTextureIndex(TextureLoader.GuiHoeButtonGrey);
            this.GoldTextureIndex = AssetManager.GetTextureIndex(TextureLoader.GuiHoeButtonGold);
            this.ClickEvent += this.TillDirtActionButton_ClickEvent;
        }

        private void TillDirtActionButton_ClickEvent(object sender, ClickEventArgs e)
        {
            if (InGameGui.Selected == ActionSelected.Till)
            {
                InGameGui.Selected = ActionSelected.None;
                this.TextureId = this.HoeTextureIndex;
            }
            else
            {
                InGameGui.Selected = ActionSelected.Till;
                this.TextureId = this.GoldTextureIndex;
            }
        }

        private static Rectangle GetDisplayArea()
        {
            int x = InGameGuiLayout.HoeActionButtonX;
            int y = InGameGuiLayout.ActionButtonY;
            int width = InGameGuiLayout.ActionButtonSize;
            int height = InGameGuiLayout.ActionButtonSize;

            return new Rectangle(x, y, width, height);
        }
    }
}