using MagicalLifeAPI.Entity;
using MagicalLifeAPI.Entity.AI.Task;
using MagicalLifeAPI.Entity.Movement;
using MagicalLifeAPI.World.Data;
using System;
using System.Collections.Generic;
using System.Linq;

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

            foreach (Dimension ii in World.Dimensions)
            {
                int chunkWidth = ii.Width;
                int chunkHeight = ii.Height;

                for (int chunkX = 0; chunkX < chunkWidth; chunkX++)
                {
                    for (int chunkY = 0; chunkY < chunkHeight; chunkY++)
                    {
                        Chunk chunk = ii.GetChunk(chunkX, chunkY);

                        List<Guid> keys = chunk.Creatures.Keys.ToList();
                        int length = keys.Count;
                        for (int i = 0; i < length; i++)
                        {
                            chunk.Creatures.TryGetValue(keys[i], out Living l);

                            if (l != null)
                            {
                                l.Movement.WearOff();

                                if (l.QueuedMovement.Count > 0)
                                {
                                    EntityWorldMovement.MoveEntity(l);
                                }

                                if (l.Task != null)
                                {
                                    l.Task.Tick(l);
                                }
                                else
                                {
                                    TaskManager.Manager.AssignTask(l);
                                    //Find a job
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}