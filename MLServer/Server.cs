using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Filing;
using MagicalLifeAPI.Load;
using MagicalLifeAPI.Mod;
using MagicalLifeAPI.Networking;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Networking.Server;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Data;
using MagicalLifeServer.Load;
using MLAPI.Properties;
using System;
using System.Collections.Generic;

namespace MagicalLifeServer
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
                    in ServerSendRecieve.TCPServer.PlayerToSocket)
                {
                    if (!WorldUtil.PlayerHasCharacter(item.Key))
                    {
                        Guid firstDimensionID = WorldUtil.GetDimensionByName(Lang._1stDimensionName).Key;
                        WorldUtil.SpawnRandomCharacter(item.Key, firstDimensionID);
                        WorldUtil.SpawnRandomCharacter(item.Key, firstDimensionID);
                        WorldUtil.SpawnRandomCharacter(item.Key, firstDimensionID);
                    }
                }
            }

            if (World.Mode == EngineMode.ServerAndClient)
            {
                if (!WorldUtil.PlayerHasCharacter(SettingsManager.PlayerSettings.Settings.PlayerID))
                {
                    Guid firstDimensionID = WorldUtil.GetDimensionByName(Lang._1stDimensionName).Key;
                    WorldUtil.SpawnRandomCharacter(SettingsManager.PlayerSettings.Settings.PlayerID, firstDimensionID);
                    WorldUtil.SpawnRandomCharacter(SettingsManager.PlayerSettings.Settings.PlayerID, firstDimensionID);
                    WorldUtil.SpawnRandomCharacter(SettingsManager.PlayerSettings.Settings.PlayerID, firstDimensionID);
                }
            }
        }
    }
}