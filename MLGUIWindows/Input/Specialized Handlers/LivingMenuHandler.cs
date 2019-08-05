using System.Linq;
using MLAPI.Components;
using MLAPI.DataTypes;
using MLAPI.Entity;
using MLAPI.Entity.AI.Task;
using MLAPI.World;
using MLGUIWindows.GUI.Character_Menu;
using MonoGUI.MonoGUI.Input.History;

namespace MLGUIWindows.Input.Specialized_Handlers
{
    /// <summary>
    /// Handles players clicking on single creatures and pulls up menu.
    /// </summary>
    public class LivingMenuHandler
    {
        public LivingMenuHandler()
        {
            InputHistory.InputAdded += this.InputHistory_InputAdded;
        }

        private void InputHistory_InputAdded()
        {
            HistoricalInput historical = InputHistory.History.Last();

            if (historical.ActionSelected == ActionSelected.None && historical.Selected.Count == 1)
            {
                Point3D mapLocation = historical.Selected[0].GetExactComponent<ComponentSelectable>().MapLocation;
                Living creature = WorldUtil.GetCreature(mapLocation);

                if (creature != null)
                {
                    CharacterMenu.Initialize(creature);
                }
            }
        }
    }
}