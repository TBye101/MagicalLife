using Microsoft.Xna.Framework.Input;

namespace MLAPI.Filing.Settings
{
    /// <summary>
    /// Keybindings for everything in the base game.
    /// </summary>
    public class Keybindings
    {
        public Keys OpenInGameEscapeMenu { get; set; } = Keys.Escape;

        public Keys OpenActionMenu { get; set; } = Keys.C;

        public Keys StrafeUp { get; set; } = Keys.W;
        public Keys StrafeDown { get; set; } = Keys.S;
        public Keys StrafeLeft { get; set; } = Keys.A;
        public Keys StrafeRight { get; set; } = Keys.D;
    }
}