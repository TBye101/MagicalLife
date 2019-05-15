using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Filing;
using MagicalLifeAPI.Load;
using MagicalLifeAPI.Mod;
using MagicalLifeAPI.Networking;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Networking.Server;
using MagicalLifeAPI.Time;
using MagicalLifeAPI.Universal;
using MagicalLifeAPI.Util.Reusable;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Data;
using MagicalLifeAPI.World.Data.Disk;
using MagicalLifeAPI.World.Data.Disk.DataStorage;
using MagicalLifeServer.Load;
using System;
using System.Collections.Generic;
using System.Timers;

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
                        WorldUtil.SpawnRandomCharacter(item.Key, 0);
                        WorldUtil.SpawnRandomCharacter(item.Key, 0);
                        WorldUtil.SpawnRandomCharacter(item.Key, 0);
                    }
                }
            }

            if (World.Mode == EngineMode.ServerAndClient)
            {
                if (!WorldUtil.PlayerHasCharacter(SettingsManager.PlayerSettings.Settings.PlayerID))
                {
                    WorldUtil.SpawnRandomCharacter(SettingsManager.PlayerSettings.Settings.PlayerID, 0);
                    WorldUtil.SpawnRandomCharacter(SettingsManager.PlayerSettings.Settings.PlayerID, 0);
                    WorldUtil.SpawnRandomCharacter(SettingsManager.PlayerSettings.Settings.PlayerID, 0);
                }
            }
        }
    }
}