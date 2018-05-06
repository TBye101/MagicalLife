using MagicalLifeAPI.Universal;
using MagicalLifeAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Networking
{
    /// <summary>
    /// Handles classes who teach the type model how to serialize some of the external types this game uses.
    /// </summary>
    public class ExternalTypeSerializer : IGameLoader
    {
        private List<ITeachSerialization> teachers = new List<ITeachSerialization>();

        public int GetTotalOperations()
        {
            this.teachers.AddRange(ReflectionUtil.LoadAllInterface<ITeachSerialization>(Assembly.GetAssembly(typeof(ITeachSerialization))));
            return this.teachers.Count;
        }

        public void InitialStartup(ref int progress)
        {
            foreach (ITeachSerialization item in this.teachers)
            {
                item.Teach();
            }
        }
    }
}
