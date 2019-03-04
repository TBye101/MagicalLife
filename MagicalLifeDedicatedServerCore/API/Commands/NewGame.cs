using MagicalLifeAPI.Networking;
using MagicalLifeAPI.Networking.Server;
using MagicalLifeAPI.Server;
using MagicalLifeAPI.World.Data;
using MagicalLifeAPI.World.Data.Disk;
using MagicalLifeDedicatedServer.API.Settings;
using MagicalLifeServer;
using MagicalLifeServer.ServerWorld.World;
using System.Collections.Generic;
using System.Net.Sockets;

namespace MagicalLifeDedicatedServer.API.Commands
{
    /// <summary>
    /// Creates a new world and launches a new game.
    /// </summary>
    public class NewGame : ICommand
    {
        public string GetHelp()
        {
            return "Creates a new world and hosts a new game\r\n Usage: ml newgame (mygamenamehere)";
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
                Util.WriteLine("Generating world!");
                World.Initialize(wset.DimensionWidth, wset.DimensionHeight, new GrassAndDirt(0));
                Util.WriteLine("World generated!");

                Util.WriteLine("Initializing networking!");
                int port = SettingsHandler.NetworkSettings.Settings.Port;
                ServerSendRecieve.Initialize(new NetworkSettings(port));
                ServerSendRecieve.TCPServer.Server.ClientConnected += Server_ClientConnected;
                ServerSendRecieve.TCPServer.Server.ClientDisconnected += Server_ClientDisconnected;

                Util.WriteLine("Done!");
            }
            else
            {
                Util.WriteLine("Invalid command parameters");
            }
        }

        private static void Server_ClientDisconnected(object sender, TcpClient e)
        {
            Util.WriteLine("Client disconnected: " + e.Client.RemoteEndPoint.ToString());
        }

        private static void Server_ClientConnected(object sender, System.Net.Sockets.TcpClient e)
        {
            Util.WriteLine("Client connected: " + e.Client.RemoteEndPoint.ToString());
        }
    }
}