using MagicalLifeAPI.Components;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Entity.AI.Task;
using MagicalLifeAPI.Entity.AI.Task.Tasks;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data;
using MagicalLifeAPI.World.Resources;
using MagicalLifeGUIWindows.Input.History;
using System;
using System.Linq;

namespace MagicalLifeGUIWindows.Input.Specialized_Handlers
{
    public class MiningActionHandler
    {
        public MiningActionHandler()
        {
            InputHistory.InputAdded += this.InputHistory_InputAdded;
        }

        private void InputHistory_InputAdded()
        {
            HistoricalInput last = InputHistory.History.Last();

            if (last.ActionSelected == ActionSelected.Mine)
            {
                foreach (HasComponents item in last.Selected)
                {
                    ComponentSelectable selectable = item.GetExactComponent<ComponentSelectable>();
                    Tile tile = World.GetTile(RenderInfo.DimensionID, selectable.MapLocation.X, selectable.MapLocation.Y);

                    if (tile.MainObject != null && tile.ImpendingAction == ActionSelected.None)
                    {
                        if (tile.MainObject is RockBase)
                        {
                            HarvestTask task = new HarvestTask(selectable.MapLocation, Guid.NewGuid());
                            tile.ImpendingAction = ActionSelected.Mine;
                            TaskManager.Manager.AddTask(task);
                        }
                    }
                }
            }
        }
    }
}