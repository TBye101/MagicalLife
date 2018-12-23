using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Entity.AI.Task;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.In
{
    public class TillDirtActionButton : MonoButton
    {
        protected int HoeTextureIndex;
        protected int GoldTextureIndex;

        public TillDirtActionButton() : base(TextureLoader.GUIHoeButton, GetDisplayArea(), true)
        {
            this.HoeTextureIndex = AssetManager.GetTextureIndex(TextureLoader.GUIHoeButton);
            this.GoldTextureIndex = AssetManager.GetTextureIndex(TextureLoader.GUIHoeButtonGold);
        }

        private static Rectangle GetDisplayArea()
        {
            int x = InGameGUILayout.HoeActionButtonX;
            int y = InGameGUILayout.ActionButtonY;
            int width = InGameGUILayout.ActionButtonSize;
            int height = InGameGUILayout.ActionButtonSize;

            return new Rectangle(x, y, width, height);
        }

        public override void Click(MouseEventArgs e, GUIContainer container)
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

        public override void DoubleClick(MouseEventArgs e, GUIContainer container)
        {
        }
    }
}
