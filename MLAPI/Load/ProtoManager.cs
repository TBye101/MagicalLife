using System.Reflection;
using MLAPI.Networking.Serialization;

namespace MLAPI.Load
{
    internal class ProtoManager : IGameLoader
    {
        public void InitialStartup()
        {
            ProtoUtil.RegisterAssembly(Assembly.GetExecutingAssembly());
        }
    }
}