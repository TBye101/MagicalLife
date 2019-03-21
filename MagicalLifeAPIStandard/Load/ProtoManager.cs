using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Registry.ItemRegistry;
using System;
using System.Collections.Generic;
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