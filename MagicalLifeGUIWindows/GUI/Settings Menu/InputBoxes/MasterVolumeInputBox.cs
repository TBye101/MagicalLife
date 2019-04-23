using MagicalLifeAPI.Asset;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Rendering.Text;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalLifeAPI.Filing;

namespace MagicalLifeGUIWindows.GUI.Settings_Menu.InputBoxes
{
    public class MasterVolumeInputBox : MonoInputBox
    {
        public MasterVolumeInputBox() :
           base(TextureLoader.GUIInputBox100x50, TextureLoader.GUICursorCarrot, GetInitialLocation(), int.MaxValue, TextureLoader.FontMainMenuFont12x,
               false, SimpleTextRenderer.Alignment.Left, true)
        {
            TextChanged += UpdateAudio;
        }


        /// <summary>
        /// Updates the audio.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="args">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void UpdateAudio(Object obj, EventArgs args)
        {
            if (int.TryParse(this.Text, out int volume) && volume >=0 && volume <= 100)
            {
                SettingsManager.AudioSettings.Settings.MasterVolume = volume;
                 SettingsManager.AudioSettings.Save();

            }
        }

        private static Rectangle GetInitialLocation()
        {
            int x = SettingsMenuLayout.MasterVolumeInputBoxX;
            int y = SettingsMenuLayout.MasterVolumeInputBoxY;
            int width = SettingsMenuLayout.MasterVolumeInputBoxWidth;
            int height = SettingsMenuLayout.MasterVolumeInputBoxHeight;

            return new Rectangle(x, y, width, height);
        }


    }
}
