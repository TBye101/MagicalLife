using System;
using System.Collections.Generic;
using MLAPI.Components;
using MLAPI.Visual.Rendering;
using ProtoBuf;

namespace MLAPI.Visual
{
    /// <summary>
    /// Any class that inherits from this has a texture.
    /// </summary>
    [ProtoBuf.ProtoContract]
    public class ComponentHasTexture : Component
    {
        /// <summary>
        /// The visuals that this component stores.
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