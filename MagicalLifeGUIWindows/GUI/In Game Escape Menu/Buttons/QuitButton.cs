using MagicalLifeAPI.Sound;
using MagicalLifeAPI.World.Data;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.In_Game_Escape_Menu.Buttons
{
    public class QuitButton : MonoButton
    {
        public QuitButton() : base("MenuButton", GetDisplayArea(), true, GetText())
        {
        }

        public static string GetText()
        {
            switch (World.Mode)
            {
                case MagicalLifeAPI.Networking.EngineMode.ClientOnly:
                    return "Disconnect";
                case MagicalLifeAPI.Networking.EngineMode.ServerAndClient:
                    return "Quit";
                default:
                    throw new MagicalLifeAPI.InternalExceptions.UnexpectedEnumMemberException();
            }
        }

        private static Rectangle GetDisplayArea()
        {
            int x = InGameEscapeMenuLayout.ButtonX;
            int y = InGameEscapeMenuLayout.QuitButtonY;
            int width = InGameEscapeMenuLayout.ButtonWidth;
            int height = InGameEscapeMenuLayout.ButtonHeight;

            return new Rectangle(x, y, width, height);
        }

        public override void Click(MouseEventArgs e, GUIContainer container)
        {
            FMODUtil.RaiseEvent(EffectsTable.UIClick);
        }

        public override void DoubleClick(MouseEventArgs e, GUIContainer container)
        {
            FMODUtil.RaiseEvent(EffectsTable.UIClick);
        }
    }
}
