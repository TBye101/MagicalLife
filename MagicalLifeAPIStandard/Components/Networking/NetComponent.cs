using MagicalLifeAPI.Networking.Object;
using MagicalLifeAPI.Registry.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Components.Networking
{
    /// <summary>
    /// Used to synchronize another component between client and server.
    /// </summary>
    /// <typeparam name="T">The type of the object that this <see cref="NetComponent{T}"/> will be used to sync.</typeparam>
    public abstract class NetComponent<T> : NComponent
    {
        protected T SyncedComponent { get; set; }

        protected NetComponent(T syncedComponent)
        {
            this.SyncedComponent = syncedComponent;
            NetComponentManager.AddComponent(this);
        }
    }
}
