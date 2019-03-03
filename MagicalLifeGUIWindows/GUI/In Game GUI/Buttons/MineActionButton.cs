using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Entity.AI.Task;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.In
{
    public class MineActionButton : MonoButton
    {
        protected int GreyTextureIndex;
        protected int GoldTextureIndex;

        public MineActionButton() : base(TextureLoader.GUIPickaxeButtonGrey, GetDisplayArea(), true)
        {
            this.GreyTextureIndex = AssetManager.GetTextureIndex(TextureLoader.GUIPickaxeButtonGrey);
            this.GoldTextureIndex = AssetManager.GetTextureIndex(TextureLoader.GUIPickaxeButtonGold);
            this.ClickEvent += this.MineActionButton_ClickEvent;
        }

        private void MineActionButton_ClickEvent(object sender, Reusable.Event.ClickEventArgs e)
        {
            if (InGameGUI.Selected == ActionSelected.Mine)
            {
                InGameGUI.Selected = ActionSelected.None;
                this.TextureID = this.GreyTextureIndex;
            }
            else
            {
                InGameGUI.Selected = ActionSelected.Mine;
                this.TextureID = this.GoldTextureIndex;
            }
        }

        private static Rectangle GetDisplayArea()
        {
            int x = InGameGUILayout.MineActionButtonX;
            int y = InGameGUILayout.ActionButtonY;
            int width = InGameGUILayout.ActionButtonSize;
            int height = InGameGUILayout.ActionButtonSize;

            return new Rectangle(x, y, width, height);
        }
    }
}