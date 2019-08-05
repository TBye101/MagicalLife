using System;
using System.Linq;
using MLAPI.Components;
using MLAPI.Components.Resource;
using MLAPI.Entity.AI.Task;
using MLAPI.Entity.AI.Task.Tasks;
using MLAPI.Visual.Rendering;
using MLAPI.World.Base;
using MLAPI.World.Data;
using MonoGUI.MonoGUI.Input.History;

namespace MLGUIWindows.Input.Specialized_Handlers
{
    public class TillingActionHandler
    {
        public TillingActionHandler()
        {
            InputHistory.InputAdded += this.InputHistory_InputAdded;
        }

        private void InputHistory_InputAdded()
        {
            HistoricalInput last = InputHistory.History.Last();

            if (last.ActionSelected == ActionSelected.Till)
            {
                foreach (HasComponents item in last.Selected)
                {
                    ComponentSelectable selected = item.GetExactComponent<ComponentSelectable>();
                    Tile tile = World.GetTile(RenderInfo.DimensionId, selected.MapLocation.X, selected.MapLocation.Y);

                    if (tile.HasComponent<ComponentTillable>()
                        && tile.ImpendingAction == ActionSelected.None
                        && tile.MainObject == null)
                    {
                        TillTask task = new TillTask(tile.GetExactComponent<ComponentSelectable>().MapLocation, Guid.NewGuid());
                        tile.ImpendingAction = ActionSelected.Till;
                        TaskManager.Manager.AddTask(task);
                    }
                }
            }
        }
    }
}