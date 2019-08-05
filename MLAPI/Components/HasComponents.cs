using System;
using System.Collections.Generic;
using ProtoBuf;

namespace MLAPI.Components
{
    /// <summary>
    /// Contains a collection of components, and allows for the manipulation and access of these components.
    /// </summary>
    [ProtoContract]
    public class HasComponents
    {
        //<AssemblyQualifiedName, Component>
        [ProtoMember(1)]
        private Dictionary<Type, Component> Components;

        /// <param name="irrelevant">A parameter to ensure that protobuf-net doesn't use this constructor. Its value doesn't matter.</param>
        public HasComponents(bool irrelevant)
        {
            this.Components = new Dictionary<Type, Component>();
        }

        protected HasComponents()
        {
            //Protobuf-net constructor
        }

        [ProtoAfterDeserialization]
        protected void AfterDeserialization()
        {
            if (this.Components == null)
            {
                this.Components = new Dictionary<Type, Component>();
            }
        }

        /// <summary>
        /// Returns the number of components.
        /// </summary>
        /// <returns></returns>
        public int ComponentCount()
        {
            if (this.Components != null)
            {
                return this.Components.Count;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Returns a component if a component of the exact same type as specified is found.
        /// Otherwise returns null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public T GetExactComponent<T>()
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

        /// <summary>
        /// Returns the first component that is exactly the same as the type specified, or is a subclass.
        /// Returns null if none are found.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetComponent<T>()
            where T : Component
        {
            T exact = this.GetExactComponent<T>();
            if (exact == null)
            {
                foreach (KeyValuePair<Type, Component> item in this.Components)
                {
                    if (typeof(T).IsAssignableFrom(item.Key))
                    {
                        return (T)item.Value;
                    }
                }

                return null;
            }
            else
            {
                return exact;
            }
        }

        public void AddComponent(Component component)
        {
            this.Components.Add(component.GetType(), component);
        }

        public bool HasComponent<T>()
            where T : Component
        {
            Component result = this.GetComponent<T>();
            return result != null && result != default(T);
        }

        public void ClearComponents()
        {
            this.Components.Clear();
        }
    }
}