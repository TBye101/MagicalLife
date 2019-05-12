using MagicalLifeAPI.Components.Entity;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Components.Networking
{
    /// <summary>
    /// Used to synchronize a <see cref="MovementComponent"/>.
    /// </summary>
    public class NetMovementComponent : NetComponent<ComponentMovement>
    {
        public NetMovementComponent(ComponentMovement syncedComponent) : base(syncedComponent)
        {
        }

        public override void RecieveClientMessage(BaseMessage clientMessage)
        {
        }

        public override void RecieveServerMessage(BaseMessage serverMessage)
        {
        }
    }
}
