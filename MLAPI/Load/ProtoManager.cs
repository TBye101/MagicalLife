using MagicalLifeAPI.Networking.Serialization;
using System.Reflection;

namespace MagicalLifeAPI.Load
{
    internal class ProtoManager : IGameLoader
    {
        public void InitialStartup()
        {
            ProtoUtil.RegisterAssembly(Assembly.GetExecutingAssembly());
        }
    }
}