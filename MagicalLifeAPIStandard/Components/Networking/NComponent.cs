using MagicalLifeAPI.Components;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Registry.Network;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Networking.Object
{
    /// <summary>
    /// Used to synchronize another component between client and server.
    /// </summary>
    /// <typeparam name="T">The type of the object that this <see cref="NComponent{T}"/> will be used to sync.</typeparam>
    public abstract class NComponent : Component
    {
        protected NComponent()
        {
        }

        /// <summary>
        /// Implementers of this should receive a message from the server, and process it.
        /// </summary>
        public abstract void RecieveServerMessage(BaseMessage serverMessage);

        /// <summary>
        /// Implementers of this should recieve a message from the client, and process it.
        /// </summary>
        /// <param name="clientMessage"></param>
        public abstract void RecieveClientMessage(BaseMessage clientMessage);
    }
}
