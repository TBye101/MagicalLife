using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Filing.Settings
{
    /// <summary>
    /// Keybindings for everything in the base game.
    /// </summary>
    public class Keybindings
    {
        public int OpenInGameEscapeMenu = (int)Keys.Escape;

        public int StrafeUp = (int)Keys.W;
        public int StrafeDown = (int)Keys.S;
        public int StrafeLeft = (int)Keys.A;
        public int StrafeRight = (int)Keys.D;
    }
}
