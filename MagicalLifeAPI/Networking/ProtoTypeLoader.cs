using MagicalLifeAPI.Protobuf;
using MagicalLifeAPI.Universal;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Tiles;
using ProtoBuf.Meta;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace MagicalLifeAPI.Networking
{
    /// <summary>
    /// Used to create the <see cref="RuntimeTypeModel"/> for our use of Protobuf-net.
    /// </summary>
    public class ProtoTypeLoader : IGameLoader
    {
        /// <summary>
        /// The messages that need to be registered.
        /// </summary>
        private List<Type> Messages = new List<Type>();

        public int GetTotalOperations()
        {
            this.Messages.AddRange(ReflectionUtil.LoadTypeOfAllSubclasses<BaseMessage>(Assembly.GetAssembly(typeof(BaseMessage))));
            return this.Messages.Count;
        }

        public void InitialStartup(ref int progress)
        {
            RuntimeTypeModel model = TypeModel.Create();

            MetaType baseMessageType = model.Add(typeof(BaseMessage), true);
            //MetaType tileType = model.Add(typeof(Tile), true);
            //tileType.AddSubType(1, typeof(Dirt));
            List<IHasSubclasses> ToProcess = ReflectionUtil.LoadAllInterface<IHasSubclasses>(Assembly.GetAssembly(typeof(BaseMessage)));

            foreach (IHasSubclasses item in ToProcess)
            {
                MetaType meta = model.Add(item.GetBaseType(), true);

                foreach (KeyValuePair<Type, int> subs in item.GetSubclassInformation())
                {
                    meta.AddSubType(subs.Value, subs.Key);
                }
            }

            //Must start at 2 because Protobuf-net can't have members and inheritance attributes with the same ID. I think. :D
            int i = 2;
            int length = this.Messages.Count + 2;
            while (i < length)
            {
                model.Add(this.Messages[i - 2], true);
                baseMessageType.AddSubType(i, this.Messages[i - 2]);

                BaseMessage sample = (BaseMessage)Activator.CreateInstance(this.Messages[i - 2]);
                ProtoUtil.IDToMessage.Add(sample.ID, this.Messages[i - 2]);

                i++;
                progress++;
            }

            ProtoUtil.TypeModel = model;
        }
    }
}