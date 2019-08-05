using Microsoft.Xna.Framework;
using MLAPI.Filing;
using MonoGUI.MonoGUI;

namespace MLGUIWindows.GUI.Action_Menu
{
    /// <summary>
    /// Positioning data for the action menu.
    /// </summary>
    public static class ActionMenuLayout
    {
        /// <summary>
        /// The dimensions of the action menu.
        /// </summary>
        public static Rectangle ActionMenuLocation
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return ActionMenuLayout2560x1440.ActionMenuLocation;

                    default:
                        return ActionMenuLayout1920x1080.ActionMenuLocation;
                }
            }
        }

        /// <summary>
        /// The dimensions of the actual grid containing the action items.
        /// </summary>
        public static Rectangle ActionGridBounds
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return ActionMenuLayout2560x1440.ActionGridBounds;

                    default:
                        return ActionMenuLayout1920x1080.ActionGridBounds;
                }
            }
        }
    }
}