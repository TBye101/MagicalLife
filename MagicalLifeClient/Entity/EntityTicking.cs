using MagicalLifeAPI.Entities;
using MagicalLifeAPI.Entities.Movement;
using MagicalLifeAPI.Pathfinding;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Data;
using MagicalLifeNetworking.Client;
using MagicalLifeNetworking.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeClient.Entity
{
    /// <summary>
    /// Used to do client side entity operations every tick.
    /// </summary>
    public static class EntityTicking
    {
        public static void Initialize()
        {
            Client.ClientTick += Client_ClientTick;
        }

        private static void Client_ClientTick(object sender, ulong e)
        {
            //This needs to be changed, as the performance time WILL be awful.
            //This WILL be changed after the rewrite of how the world is stored in memory

            foreach (Tile item in World.MainWorld.Chunks)
            {
                if (item.Living != null)
                {
                    Living l = item.Living;
                    l.Movement.WearOff();

                    if (item.Living.QueuedMovement.Count > 0)
                    {
                        EntityWorldMovement.MoveEntity(ref l);
                    }
                }
            }
        }
    }
}