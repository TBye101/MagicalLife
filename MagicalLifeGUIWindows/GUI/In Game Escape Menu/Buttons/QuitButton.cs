using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Error.InternalExceptions;
using MagicalLifeAPI.Networking;
using MagicalLifeAPI.Sound;
using MagicalLifeAPI.World.Data;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Properties;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;
using System;

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
                case EngineMode.ClientOnly:
                    return Resources.Disconnect;

                case EngineMode.ServerAndClient:
                    return Resources.Quit;

                default:
                    throw new InvalidOperationException("Unexpected value for world mode = " + World.Mode.ToString());
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