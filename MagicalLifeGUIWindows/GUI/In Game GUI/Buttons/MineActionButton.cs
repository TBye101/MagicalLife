using MagicalLifeAPI.Entity.AI.Job;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.In_Game_GUI.Buttons
{
    public class MineActionButton : MonoButton
    {
        public MineActionButton() : base("MineAction", GetDisplayArea(), true)
        {
        }

        private static Rectangle GetDisplayArea()
        {
            int x = InGameGUILayout.MineActionButtonX;
            int y = InGameGUILayout.ActionButtonY;
            int width = InGameGUILayout.ActionButtonSize;
            int height = InGameGUILayout.ActionButtonSize;

            return new Rectangle(x, y, width, height);
        }

        public override void Click(MouseEventArgs e)
        {
            if (InGameGUI.Selected == ActionSelected.Mine)
            {
                InGameGUI.Selected = ActionSelected.None;
            }
            else
            {
                InGameGUI.Selected = ActionSelected.Mine;
            }
        }

        public override void DoubleClick(MouseEventArgs e)
        {
        }
    }
}
