using System;
using System.Collections.Generic;
using System.Linq;
using MLAPI.Components.Entity;
using MLAPI.Entity;
using MLAPI.Entity.AI.Task;
using MLAPI.Entity.Movement;
using MLAPI.Universal;
using MLAPI.World.Data;

namespace MLClient.Entity
{
    /// <summary>
    /// Used to do client side entity operations every tick.
    /// </summary>
    public static class EntityTicking
    {
        private static object SyncObject = new object();

        public static void Initialize()
        {
            Uni.TickEvent += Uni_TickEvent;
        }

        private static void Uni_TickEvent(object sender, ulong e)
        {
            lock (SyncObject)
            {
                foreach (Dimension ii in World.DefaultWorldProvider)
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
                                    ComponentMovement movementComponent = l.GetExactComponent<ComponentMovement>();
                                    movementComponent.Movement.WearOff();

                                    if (movementComponent.QueuedMovement.Count > 0)
                                    {
                                        EntityWorldMovement.MoveEntity(l);
                                    }

                                    if (l.Task != null && !l.Task.IsFinished)
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
}