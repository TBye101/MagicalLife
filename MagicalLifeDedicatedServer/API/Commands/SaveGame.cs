using MagicalLifeAPI.Server;
using MagicalLifeAPI.World.Data.Disk;
using MagicalLifeAPI.World.Data.Disk.DataStorage;
using System.Collections.Generic;

namespace MagicalLifeDedicatedServer.API.Commands
{
    public class SaveGame : ICommand
    {
        public string getHelp()
        {
            return "Saves the game to disk";
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