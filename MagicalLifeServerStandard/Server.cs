using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Error.InternalExceptions;
using MagicalLifeAPI.Filing;
using MagicalLifeAPI.Load;
using MagicalLifeAPI.Networking;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Networking.Server;
using MagicalLifeAPI.Time;
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
        /// <summary>
        /// The tick the server is executing.
        /// </summary>
        public static UInt64 GameTick { get; private set; } = 0;

        private static Timer TickTimer = new Timer(50);

        /// <summary>
        /// The timer counting down the time between auto-saves.
        /// </summary>
        private static TickTimer AutoSave = new TickTimer(RealTime.HalfHour);

        /// <summary>
        /// The event that is raised when the game ticks.
        /// </summary>
        public static event EventHandler<UInt64> ServerTick;

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
                        new ItemLoader(),
                        new TextureLoader(),
                        new SpecificTextureLoader(),
                        new ProtoTypeLoader(),
                        new MainLoad()
                    });

                    break;

                default:
                    throw new UnexpectedEnumMemberException();
            }
        }

        private static void SetupTick()
        {
            TickTimer.AutoReset = true;
            TickTimer.Elapsed += Tick;
            ServerTick += Server_ServerTick;
            TickTimer.Start();
        }

        private static void Server_ServerTick(object sender, ulong e)
        {
            if (AutoSave.Allow())
            {
                WorldStorage.AutoSave(WorldStorage.SaveName, new WorldDiskSink());
            }
        }

        private static void Tick(object sender, ElapsedEventArgs e)
        {
            GameTick++;
            ServerSendRecieve.SendAll(new ServerTickMessage(GameTick));
            RaiseServerTick(sender, GameTick);
        }

        private static void RaiseServerTick(object sender, UInt64 tick)
        {
            ServerTick?.Invoke(sender, tick);
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
                    WorldUtil.SpawnRandomCharacter(item.Key, 0);
                    WorldUtil.SpawnRandomCharacter(item.Key, 0);
                    WorldUtil.SpawnRandomCharacter(item.Key, 0);
                }
            }

            if (World.Mode == EngineMode.ServerAndClient)
            {
                WorldUtil.SpawnRandomCharacter(SettingsManager.PlayerSettings.Settings.PlayerID, 0);
                WorldUtil.SpawnRandomCharacter(SettingsManager.PlayerSettings.Settings.PlayerID, 0);
                WorldUtil.SpawnRandomCharacter(SettingsManager.PlayerSettings.Settings.PlayerID, 0);
            }

            SetupTick();
        }
    }
}