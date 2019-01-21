using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity;
using MagicalLifeAPI.Entity.AI.Task;
using MagicalLifeAPI.World;
using MagicalLifeGUIWindows.GUI.Character_Menu;
using MagicalLifeGUIWindows.Input.History;
using System.Linq;

namespace MagicalLifeGUIWindows.Input.Specialized_Handlers
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
                Point2D mapLocation = historical.Selected[0].MapLocation;
                Living creature = WorldUtil.GetCreature(mapLocation, RenderInfo.Dimension);

                if (creature != null)
                {
                    CharacterMenu.Initialize(creature);
                }
            }
        }
    }
}