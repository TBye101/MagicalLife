using MagicalLifeAPI.Entities;
using MagicalLifeAPI.Entities.Movement;
using MagicalLifeAPI.Pathfinding;
using MagicalLifeAPI.World;
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
            //This needs to be changed, as the performance time will be awful.
            //This WILL be changed after the rewrite of how the world is stored in memory
            foreach (Tile item in World.MainWorld.Tiles)
            {
                if (item.Living != null)
                {
                    Living l = item.Living;
                    Test(ref l);
                    if (item.Living.QueuedMovement.Count > 0)
                    {
                        EntityWorldMovement.MoveEntity(ref l);
                    }
                }
            }
        }

        private static void Test(ref Living living)
        {
            if (World.MainWorld.Tiles[0, 0].IsWalkable)
            {
                Microsoft.Xna.Framework.Point start = living.MapLocation;
                if (start != new Microsoft.Xna.Framework.Point(0, 0))
                {
                    List<PathLink> pth = MainPathFinder.PFinder.GetRoute(World.MainWorld, living, World.MainWorld.Tiles[start.X, start.Y].Location, World.MainWorld.Tiles[0, 0].Location);

                    living.QueuedMovement.Clear();
                    MagicalLifeAPI.Util.Extensions.EnqueueCollection(living.QueuedMovement, pth);
                    ClientSendRecieve.Send<RouteCreatedMessage>(new RouteCreatedMessage(pth, living.ID));
                }
            }
        }
    }
}