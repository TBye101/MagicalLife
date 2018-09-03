using MagicalLifeAPI.Entity.AI.Task;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.In
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

        public override void Click(MouseEventArgs e, GUIContainer container)
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

        public override void DoubleClick(MouseEventArgs e, GUIContainer container)
        {
        }
    }
}