using System.Collections.Generic;
using MLAPI.Server;
using MLAPI.World.Data.Disk;
using MLAPI.World.Data.Disk.DataStorage;
using MLDedicatedServer.Properties;

namespace MLDedicatedServer.API.Commands
{
    public class SaveGame : ICommand
    {
        public string GetHelp()
        {
            return DedicatedServer.SaveGameCommandDesc;
        }

        public string GetName()
        {
            return "SaveGame";
        }

        public void Run(List<string> input)
        {
            WorldStorage.SerializeWorld("Server World", new WorldDiskSink());
        }
    }
}