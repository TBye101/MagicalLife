using MagicalLifeAPI.Server;
using MagicalLifeAPI.World.Data.Disk;
using MagicalLifeAPI.World.Data.Disk.DataStorage;
using MLDedicatedServer.Properties;
using System.Collections.Generic;

namespace MagicalLifeDedicatedServer.API.Commands
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