using MagicalLifeAPI.Load;
using MagicalLifeAPI.Networking.External;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.World.Base;
using ProtoBuf.Meta;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace MagicalLifeAPI.Networking.Serialization
{
    /// <summary>
    /// Used to create the <see cref="RuntimeTypeModel"/> for our use of Protobuf-net.
    /// </summary>
    public class ProtoTypeLoader : IGameLoader
    {
        /// <summary>
        /// The messages that need to be registered.
        /// </summary>
        private readonly List<Type> Messages = new List<Type>();

        private readonly List<ITeachSerialization> Teachers = new List<ITeachSerialization>();

        public ProtoTypeLoader()
        {
            this.Prepare();
        }

        public void Prepare()
        {
            this.Messages.AddRange(ReflectionUtil.LoadTypeOfAllSubclasses<BaseMessage>(Assembly.GetAssembly(typeof(BaseMessage))));
            this.Teachers.AddRange(ReflectionUtil.LoadAllInterface<ITeachSerialization>(Assembly.GetAssembly(typeof(Point2DTeacher))));
        }

        public void InitialStartup()
        {
            RuntimeTypeModel current = RuntimeTypeModel.Create();

            foreach (ITeachSerialization item in this.Teachers)
            {
                item.Teach(current);
            }

            MetaType baseMessageType = current.Add(typeof(BaseMessage), true);
            List<IHasSubclasses> ToProcess = new List<IHasSubclasses>();
            ToProcess.AddRange(ReflectionUtil.LoadAllInterface<IHasSubclasses>(Assembly.GetAssembly(typeof(Tile))));

            foreach (IHasSubclasses item in ToProcess)
            {
                if (item.GetType().IsAbstract)
                {
                    MetaType meta = current.Add(item.GetBaseType(), true);

                    foreach (KeyValuePair<Type, int> subs in item.GetSubclassInformation())
                    {
                        meta.AddSubType(subs.Value, subs.Key);
                    }
                }
            }

            //Must start at 2 because Protobuf-net can't have members and inheritance attributes with the same ID. I think. :D
            int i = 3;
            int length = this.Messages.Count + 3;
            while (i < length)
            {
                current.Add(this.Messages[i - 3], true);
                baseMessageType.AddSubType(i, this.Messages[i - 3]);

                BaseMessage sample = (BaseMessage)Activator.CreateInstance(this.Messages[i - 3]);
                ProtoUtil.IDToMessage.Add(sample.ID, this.Messages[i - 3]);

                i++;
            }

            ProtoUtil.TypeModel = current;
        }
    }
}