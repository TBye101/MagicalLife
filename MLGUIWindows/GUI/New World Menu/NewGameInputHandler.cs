using MLAPI.GameRegistry.WorldGeneration;
using MLAPI.World.Data;
using MLAPI.World.Data.Disk;

namespace MLGUIWindows.GUI.New_World_Menu
{
    /// <summary>
    /// Handles all input from the new world menu.
    /// </summary>
    public class NewGameInputHandler
    {
        /// <summary>
        /// Handles the input in the world size input boxes, and starts a new game.
        /// Returns true if the operation was successful.
        /// </summary>
        public bool StartNewGame()
        {
            bool widthSuccess = int.TryParse(NewWorldMenu.NewWorldMenuM.WorldWidth.Text, out int width);

            bool lengthSuccess = int.TryParse(NewWorldMenu.NewWorldMenuM.WorldLength.Text, out int length);

            bool nameSuccess = !string.IsNullOrEmpty(NewWorldMenu.NewWorldMenuM.GameName.Text);

            if (widthSuccess && lengthSuccess && width > 0 && length > 0 && nameSuccess)
            {
                WorldStorage.SaveName = NewWorldMenu.NewWorldMenuM.GameName.Text;
                World.Initialize(width, length, WorldGeneratorRegistry.Generators[0], "Main");
                return true;
            }
            else
            {
                //The application no longer blows up but we should
                //Go to the NewWorldNextButton click event and notify the user.
                return false;
            }
        }
    }
}