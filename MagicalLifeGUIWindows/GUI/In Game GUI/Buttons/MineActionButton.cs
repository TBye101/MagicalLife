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
        }

        private static Rectangle GetDisplayArea()
        {
            int x = InGameGUILayout.MineActionButtonX;
            int y = InGameGUILayout.ActionButtonY;
            int width = InGameGUILayout.ActionButtonSize;
            int height = InGameGUILayout.ActionButtonSize;

            return new Rectangle(x, y, width, height);
        }

        public override void Click(MouseEventArgs e, GUIContainer container)
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

        public override void DoubleClick(MouseEventArgs e, GUIContainer container)
        {
        }
    }
}