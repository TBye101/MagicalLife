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

        public TillDirtActionButton() : base(TextureLoader.GUIHoeButtonGrey, GetDisplayArea(), true)
        {
            this.HoeTextureIndex = AssetManager.GetTextureIndex(TextureLoader.GUIHoeButtonGrey);
            this.GoldTextureIndex = AssetManager.GetTextureIndex(TextureLoader.GUIHoeButtonGold);
            this.ClickEvent += this.TillDirtActionButton_ClickEvent;
        }

        private void TillDirtActionButton_ClickEvent(object sender, ClickEventArgs e)
        {
            if (InGameGUI.Selected == ActionSelected.Till)
            {
                InGameGUI.Selected = ActionSelected.None;
                this.TextureID = this.HoeTextureIndex;
            }
            else
            {
                InGameGUI.Selected = ActionSelected.Till;
                this.TextureID = this.GoldTextureIndex;
            }
        }

        private static Rectangle GetDisplayArea()
        {
            int x = InGameGUILayout.HoeActionButtonX;
            int y = InGameGUILayout.ActionButtonY;
            int width = InGameGUILayout.ActionButtonSize;
            int height = InGameGUILayout.ActionButtonSize;

            return new Rectangle(x, y, width, height);
        }
    }
}