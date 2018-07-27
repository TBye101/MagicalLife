using MagicalLifeAPI.Networking.Server;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeServer.JobSystem
{
    /// <summary>
    /// Handles all <see cref="JobSystem"/>s for all players.
    /// </summary>
    [ProtoContract]
    public class JobSystemManager
    {
        public static JobSystemManager Manager { get; set; }

        [ProtoMember(1)]
        public Dictionary<Guid, JobSystem> PlayerToJobSystem { get; set; }

        public JobSystemManager(bool NonProtoConstructor)
        {
            Server.ServerTick += this.Server_ServerTick;
            this.PlayerToJobSystem = new Dictionary<Guid, JobSystem>();
        }

        private void Server_ServerTick(object sender, ulong e)
        {
            foreach (KeyValuePair<Guid, JobSystem> item in this.PlayerToJobSystem)
            {
                item.Value.ManageJobs();
            }
        }
    }
}
