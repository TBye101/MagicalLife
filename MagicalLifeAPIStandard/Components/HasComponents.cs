using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Components
{
    /// <summary>
    /// Anything that inherits from this has components.
    /// </summary>
    [ProtoContract]
    public class HasComponents
    {
        [ProtoMember(1)]
        private Dictionary<Type, Component> Components { get; set; }

        /// <summary>
        /// Non protobuf-net constructor.
        /// </summary>
        /// <param name="whatever">Only purpose of this is to prevent protobuf-net from calling this constructor.
        /// Value is not used.</param>
        public HasComponents(bool whatever)
        {
            this.Components = new Dictionary<Type, Component>();
        }

        /// <summary>
        /// Protobuf-net constructor
        /// </summary>
        protected HasComponents()
        {
            //Protobuf-net constructor.
        }

        /// <summary>
        /// Returns the found component. If the component is not found, null/default is returned.
        /// </summary>
        public T GetComponent<T>()
            where T : Component
        {
            this.Components.TryGetValue(typeof(T), out Component value);
            if (value == null)
            {
                return default;
            }
            else
            {
                return (T)value;
            }
        }

        public void AddComponent(Component component)
        {
            this.Components.Add(component.GetType(), component);
        }
    }
}
