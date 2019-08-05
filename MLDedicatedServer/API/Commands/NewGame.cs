using System.Collections.Generic;
using System.Net.Sockets;
using MLAPI.GameRegistry.WorldGeneration;
using MLAPI.Networking;
using MLAPI.Networking.Server;
using MLAPI.Server;
using MLAPI.World.Data;
using MLAPI.World.Data.Disk;
using MLDedicatedServer.API.Settings;
using MLDedicatedServer.Properties;
using MLServer;

namespace MLDedicatedServer.API.Commands
{
    /// <summary>
    /// Creates a new world and launches a new game.
    /// </summary>
    public class NewGame : ICommand
    {
        public string GetHelp()
        {
            return DedicatedServer.GeneratingWorld;
        }

        public string GetName()
        {
            return "NewGame";
        }

        public void Run(List<string> input)
        {
            if (input.Count > 0)
            {
                World.Mode = EngineMode.ServerOnly;
                WorldStorage.SaveName = input[0];
                Server.Load();

                WorldGenerationSettings wset = SettingsHandler.WorldGenerationSettings.Settings;
                Util.WriteLine(DedicatedServer.GeneratingWorld);
                World.Initialize(wset.DimensionWidth, wset.DimensionHeight, WorldGeneratorRegistry.Generators[0], "Main");
                Util.WriteLine(DedicatedServer.WorldGenerated);

                Util.WriteLine(DedicatedServer.InitializingNetwork);
                int port = SettingsHandler.NetworkSettings.Settings.Port;
                ServerSendRecieve.Initialize(new NetworkSettings(port));
                ServerSendRecieve.TCPServer.Server.ClientConnected += Server_ClientConnected;
                ServerSendRecieve.TCPServer.Server.ClientDisconnected += Server_ClientDisconnected;

                Util.WriteLine(DedicatedServer.Done);
            }
            else
            {
                Util.WriteLine(DedicatedServer.InvalidCommandParameters);
            }
        }

        private static void Server_ClientDisconnected(object sender, TcpClient e)
        {
            Util.WriteLine(DedicatedServer.ClientDisconnected + ": " + e.Client.RemoteEndPoint.ToString());
        }

        private static void Server_ClientConnected(object sender, TcpClient e)
        {
            Util.WriteLine(DedicatedServer.ClientConnected + ": " + e.Client.RemoteEndPoint.ToString());
        }
    }
}