using MagicalLifeAPI.Filing;
using MagicalLifeAPI.Filing.Settings;
using MagicalLifeGUIWindows.Input;
using MagicalLifeGUIWindows.Properties;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.Reusable
{
    public class MonoKeyBindingButton : MonoButton
    {
        private bool ReAssigning;

        private readonly string KeyBindingName;

        protected MonoKeyBindingButton(string imageName, Rectangle displayArea, bool isContained, string font,string keybinding,string text = "")
            : base(imageName, displayArea, isContained, font, text)
        {
            ClickEvent += HandleAssignment;
            KeyBindingName = keybinding;
            KeyboardHandler.KeysPressed += KeyboardHandler_KeysPressed;
        }

        protected MonoKeyBindingButton(string imageName, Rectangle displayArea, bool isContained, string keybinding, string text = "")
            : base(imageName, displayArea, isContained, text)
        {
            ClickEvent += HandleAssignment;
            KeyBindingName = keybinding;
            KeyboardHandler.KeysPressed += KeyboardHandler_KeysPressed;
        }

        private void KeyboardHandler_KeysPressed(object sender, Keys e)
        {
            if(ReAssigning)
            {
                switch(KeyBindingName)
                {
                    case nameof(Keybindings.OpenInGameEscapeMenu):
                        SettingsManager.Keybindings.Settings.OpenInGameEscapeMenu = e;
                        Text = e.ToString();
                        ReAssigning = false;
                        break;
                    case nameof(Keybindings.StrafeDown):
                        SettingsManager.Keybindings.Settings.StrafeDown = e;
                        Text = e.ToString();
                        ReAssigning = false;
                        break;
                    case nameof(Keybindings.StrafeUp):
                        SettingsManager.Keybindings.Settings.StrafeUp = e;
                        Text = e.ToString();
                        ReAssigning = false;
                        break;
                    case nameof(Keybindings.StrafeLeft):
                        SettingsManager.Keybindings.Settings.StrafeLeft = e;
                        Text = e.ToString();
                        ReAssigning = false;
                        break;
                    case nameof(Keybindings.StrafeRight):
                        SettingsManager.Keybindings.Settings.StrafeRight = e;
                        Text = e.ToString();
                        ReAssigning = false;
                        break;
                }
                SettingsManager.Keybindings.Save();
            }
        }

        public void HandleAssignment(Object obj, EventArgs eventArgs)
        {
            if(!ReAssigning)
            {
                Text = Resources.WaitingForKeyPress;
                ReAssigning = true;
            }
        }

    }
}
