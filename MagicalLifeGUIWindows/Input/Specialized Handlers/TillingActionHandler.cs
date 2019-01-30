using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Components.Resource;
using MagicalLifeAPI.Entity.AI.Task;
using MagicalLifeAPI.Entity.AI.Task.Tasks;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data;
using MagicalLifeGUIWindows.Input.History;
using System;
using System.Linq;

namespace MagicalLifeGUIWindows.Input.Specialized_Handlers
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
                foreach (MagicalLifeAPI.GUI.Selectable item in last.Selected)
                {
                    Tile tile = World.GetTile(RenderInfo.Dimension, item.MapLocation.X, item.MapLocation.Y);

                    if (tile is ITillable
                        && tile.ImpendingAction == ActionSelected.None
                        && tile.Resources == null)
                    {
                        TillTask task = new TillTask(tile.MapLocation, Guid.NewGuid(), RenderInfo.Dimension);
                        tile.ImpendingAction = ActionSelected.Till;
                        TaskManager.Manager.AddTask(task);
                    }
                }
            }
        }
    }
}