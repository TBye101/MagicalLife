using MagicalLifeAPI.Components;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.World.Base;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.GUI
{
    /// <summary>
    /// Any class that inherits from this has a texture.
    /// </summary>
    [ProtoBuf.ProtoContract]
    public class ComponentHasTexture : Component
    {
        /// <summary>
        /// The index of the texture in our asset manager.
        /// </summary>
        [ProtoMember(1)]
        public List<AbstractVisual> Visuals { get; set; }

        /// <param name="irrelevant">Used to disallow Protobuf-net from using this constructor.</param>
        public ComponentHasTexture(bool irrelevant)
        {
            this.ID = Guid.NewGuid();
            this.Visuals = new List<AbstractVisual>();
        }

        protected ComponentHasTexture()
        {
        }
    }
}