using System;
using System.Collections.Generic;
using MLAPI.Asset;
using MLAPI.Filing;
using MLAPI.Load;
using MLAPI.Mod;
using MLAPI.Networking;
using MLAPI.Networking.Serialization;
using MLAPI.Networking.Server;
using MLAPI.Properties;
using MLAPI.World;
using MLAPI.World.Data;
using MLServer.Load;

namespace MLServer
{
    /// <summary>
    /// Commands some high level functions of a server.
    /// </summary>
    public static class Server
    {
        public static void Load()
        {
            Loader load = new Loader();
            string msg = "";

            switch (World.Mode)
            {
                case EngineMode.ServerAndClient:
                    load.LoadAll(ref msg, new List<IGameLoader>()
                    {
                        new TextureLoader(),
                        new MainLoad()
                    });
                    break;

                case EngineMode.ServerOnly:
                    SettingsManager.Initialize();
                    load.LoadAll(ref msg, new List<IGameLoader>()
                    {
                        new TextureLoader(),
                        new MainLoad(),
                        new ProtoTypeLoader(),
                        new ModLoader(),
                        new ProtoManager()
                    });
                    break;

                default:
                    throw new InvalidOperationException("Unexpected value for World Mode: " + World.Mode.ToString());
            }
        }

        /// <summary>
        /// Starts the internal tick system, and begins running game logic.
        /// </summary>
        public static void StartGame()
        {
            if (World.Mode == EngineMode.ServerOnly)
            {
                foreach (KeyValuePair<Guid, System.Net.Sockets.Socket> item
                    in ServerSendRecieve.TcpServer.PlayerToSocket)
                {
                    if (!WorldUtil.PlayerHasCharacter(item.Key))
                    {
                        Guid firstDimensionId = WorldUtil.GetDimensionByName(Lang._1stDimensionName).Key;
                        WorldUtil.SpawnRandomCharacter(item.Key, firstDimensionId);
                        WorldUtil.SpawnRandomCharacter(item.Key, firstDimensionId);
                        WorldUtil.SpawnRandomCharacter(item.Key, firstDimensionId);
                    }
                }
            }

            if (World.Mode == EngineMode.ServerAndClient)
            {
                if (!WorldUtil.PlayerHasCharacter(SettingsManager.PlayerSettings.Settings.PlayerId))
                {
                    Guid firstDimensionId = WorldUtil.GetDimensionByName(Lang._1stDimensionName).Key;
                    WorldUtil.SpawnRandomCharacter(SettingsManager.PlayerSettings.Settings.PlayerId, firstDimensionId);
                    WorldUtil.SpawnRandomCharacter(SettingsManager.PlayerSettings.Settings.PlayerId, firstDimensionId);
                    WorldUtil.SpawnRandomCharacter(SettingsManager.PlayerSettings.Settings.PlayerId, firstDimensionId);
                }
            }
        }
    }
}