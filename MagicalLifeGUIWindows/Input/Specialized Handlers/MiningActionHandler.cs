using MagicalLifeAPI.Entity.AI.Job;
using MagicalLifeAPI.Entity.AI.Job.Jobs;
using MagicalLifeAPI.Networking.Client;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data;
using MagicalLifeGUIWindows.Input.History;
using MagicalLifeGUIWindows.Rendering;
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
                        MineJob job = new MineJob(tile.MapLocation);
                        tile.ImpendingAction = ActionSelected.Mine;
                        ClientSendRecieve.Send(new JobCreatedMessage(job));
                    }
                }
            }
        }
    }
}