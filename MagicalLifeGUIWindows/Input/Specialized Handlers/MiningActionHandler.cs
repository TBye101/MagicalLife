using MagicalLifeAPI.Entity.AI.Job;
using MagicalLifeAPI.Entity.AI.Task.Tasks;
using MagicalLifeAPI.Networking.Client;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data;
using MagicalLifeGUIWindows.Input.History;
using MagicalLifeGUIWindows.Rendering;
using MagicalLifeServer.JobSystem;
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
                foreach (MagicalLifeAPI.GUI.Selectable item in last.Selected)
                {
                    Tile tile = World.GetTile(RenderingPipe.Dimension, item.MapLocation.X, item.MapLocation.Y);

                    if (tile.Resources != null)
                    {
                        MineTask task = new MineTask(tile.MapLocation, Guid.NewGuid());
                        tile.ImpendingAction = ActionSelected.Mine;
                        TaskManager.Manager.AddTask(task);
                    }
                }
            }
        }
    }
}