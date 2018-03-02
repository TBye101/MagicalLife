using MagicalLifeGUIWindows.GUI;
using MagicalLifeSettings.Storage;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.Rendering
{
    /// <summary>
    /// Some rendering utilities.
    /// </summary>
    public static class RenderUtils
    {
        public static Point GetScreenResolution()
        {
            switch ((Resolution)MainWindow.Default.Resolution)
            {
                case Resolution._1920x1080:
                    return new Point(1920, 1080);
                default:
                    throw new Exception("Screen resolution not found!");
            }
        }
    }
}
