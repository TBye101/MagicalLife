using MagicalLifeAPI.Asset;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Properties;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.Settings_Menu.Labels
{
    public class MasterVolumeLabel : MonoLabel
    {
        public MasterVolumeLabel() : base(GetLocation(), TextureLoader.GUIInputBox100x50, true, Resources.MasterVolume)
        {
        }



        private static Rectangle GetLocation()
        {
            int x = SettingsMenuLayout.MasterVolumeLabelX;
            int y = SettingsMenuLayout.MasterVolumeLabelY;
            int width = SettingsMenuLayout.MasterVolumeLabelWidth;
            int height = SettingsMenuLayout.MasterVolumeLabelHeight;

            return new Rectangle(x, y, width, height);
        }
    }
}
