using MagicalLifeAPI.Server;
using MagicalLifeAPI.World.Data.Disk;
using MagicalLifeAPI.World.Data.Disk.DataStorage;
using MagicalLifeDedicatedServer.Properties;
using System.Collections.Generic;

namespace MagicalLifeDedicatedServer.API.Commands
{
    public class SaveGame : ICommand
    {
        public string getHelp()
        {
            return DedicatedServer.SaveGameCommandDesc;
        }

        public string getName()
        {
            return "SaveGame";
        }

        public void run(List<string> input)
        {
            WorldStorage.SerializeWorld("Server World", new WorldDiskSink());
        }
    }
}