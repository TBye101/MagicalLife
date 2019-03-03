using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Sound;
using MagicalLifeAPI.World.Data;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.In
{
    public class QuitButton : MonoButton
    {
        public QuitButton() : base(TextureLoader.GUIMenuButton, GetDisplayArea(), true, GetText())
        {
            this.ClickEvent += this.QuitButton_ClickEvent;
        }

        private void QuitButton_ClickEvent(object sender, Reusable.Event.ClickEventArgs e)
        {
            FMODUtil.RaiseEvent(SoundsTable.UIClick);
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
    }
}