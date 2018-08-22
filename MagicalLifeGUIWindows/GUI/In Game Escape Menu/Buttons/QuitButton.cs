using MagicalLifeAPI.Sound;
using MagicalLifeAPI.World.Data;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.In
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
                    throw new MagicalLifeAPI.Error.InternalExceptions.UnexpectedEnumMemberException();
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