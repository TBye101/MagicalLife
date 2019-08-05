using System;
using Microsoft.Xna.Framework;
using MLAPI.Asset;
using MLAPI.Networking;
using MLAPI.Sound;
using MLAPI.World.Data;
using MLGUIWindows.Properties;
using MonoGUI.MonoGUI.Reusable;
using MonoGUI.MonoGUI.Reusable.Event;

namespace MLGUIWindows.GUI.In_Game_Escape_Menu.Buttons
{
    public class QuitButton : MonoButton
    {
        public QuitButton() : base(TextureLoader.GUIMenuButton, GetDisplayArea(), true, GetText())
        {
            this.ClickEvent += this.QuitButton_ClickEvent;
        }

        private void QuitButton_ClickEvent(object sender, ClickEventArgs e)
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