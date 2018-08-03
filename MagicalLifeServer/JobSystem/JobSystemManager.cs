using MagicalLifeAPI.Entity;
using MagicalLifeAPI.Entity.Eventing;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicalLifeServer.JobSystem
{
    /// <summary>
    /// Handles all <see cref="JobSystem"/>s for all players.
    /// </summary>
    [ProtoContract]
    public class JobSystemManager
    {
        public static JobSystemManager Manager { get; set; }

        /// <summary>
        /// Key: PlayerID
        /// Value: JobSystem for the player
        /// </summary>
        [ProtoMember(1)]
        public Dictionary<Guid, JobSystem> PlayerToJobSystem { get; set; }

        private object SyncObject { get; set; } = new object();

        /// <summary>
        /// Entities that are newly created, controlled by a offline player, are sent here.
        /// Key: PlayerID
        /// </summary>
        [ProtoMember(2)]
        public Dictionary<Guid, Living> UnassignedEntities { get; set; }

        public JobSystemManager(bool NonProtoConstructor)
        {
            Server.ServerTick += this.Server_ServerTick;
            this.PlayerToJobSystem = new Dictionary<Guid, JobSystem>();
            this.UnassignedEntities = new Dictionary<Guid, Living>();
            Living.LivingCreated += this.Living_LivingCreated;
        }

        public JobSystemManager()
        {

        }

        private void Living_LivingCreated(object sender, LivingEventArg e)
        {
            if (this.PlayerToJobSystem.ContainsKey(e.Living.PlayerID))
            {
                this.PlayerToJobSystem[e.Living.PlayerID].Idle.Add(e.Living.ID, e.Living);
            }
            else
            {
                this.UnassignedEntities.Add(e.Living.PlayerID, e.Living);
            }
        }

        /// <summary>
        /// Evaluates all unassigned workers to see if the player they belong to is connected.
        /// </summary>
        public void EvaluateUnassigned()
        {
            lock (this.SyncObject)
            {
                if (this.UnassignedEntities != null)
                {
                    for (int i = this.UnassignedEntities.Count - 1; i >= 0; i--)
                    {
                        KeyValuePair<Guid, Living> item = this.UnassignedEntities.ElementAt(i);

                        if (this.PlayerToJobSystem.ContainsKey(item.Key))
                        {
                            this.UnassignedEntities.Remove(item.Key);
                            this.PlayerToJobSystem[item.Key].Idle.Add(item.Value.ID, item.Value);
                        }
                    }
                }
            }
        }

        private void Server_ServerTick(object sender, ulong e)
        {
            this.EvaluateUnassigned();
            foreach (KeyValuePair<Guid, JobSystem> item in this.PlayerToJobSystem)
            {
                item.Value.ManageJobs();
            }
        }
    }
}
