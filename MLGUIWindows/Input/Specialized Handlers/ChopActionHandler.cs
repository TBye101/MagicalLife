using System;
using System.Linq;
using MLAPI.Components;
using MLAPI.Entity.AI.Task;
using MLAPI.Entity.AI.Task.Tasks;
using MLAPI.Visual.Rendering;
using MLAPI.World.Base;
using MLAPI.World.Data;
using MLAPI.World.Resources;
using MonoGUI.MonoGUI.Input.History;

namespace MLGUIWindows.Input.Specialized_Handlers
{
    public class ChopActionHandler
    {
        public ChopActionHandler()
        {
            InputHistory.InputAdded += this.InputHistory_InputAdded;
        }

        private void InputHistory_InputAdded()
        {
            HistoricalInput last = InputHistory.History.Last();

            if (last.ActionSelected == ActionSelected.Chop)
            {
                foreach (HasComponents item in last.Selected)
                {
                    ComponentSelectable selectable = item.GetExactComponent<ComponentSelectable>();
                    Tile tile = World.GetTile(RenderInfo.DimensionID, selectable.MapLocation.X, selectable.MapLocation.Y);

                    if (tile.MainObject != null && tile.ImpendingAction == ActionSelected.None)
                    {
                        if (tile.MainObject is TreeBase)
                        {
                            HarvestTask task = new HarvestTask(selectable.MapLocation, Guid.NewGuid());
                            tile.ImpendingAction = ActionSelected.Chop;
                            TaskManager.Manager.AddTask(task);
                        }
                    }
                }
            }
        }
    }
}