using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicalLifeAPI.Components
{
    /// <summary>
    /// Contains a collection of components, and allows for the manipulation and access of these components.
    /// </summary>
    [ProtoContract(SkipConstructor = true)]
    public class HasComponents
    {
        [ProtoMember(1)]
        private Dictionary<Type, Component> Components;

        public HasComponents()
        {
            this.Components = new Dictionary<Type, Component>();
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
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetComponent<T>()
            where T : Component
        {
            T exact = this.GetExactComponent<T>();
            if (exact == null)
            {
                return (T)this.Components.First(x => x.Key.IsSubclassOf(typeof(T))).Value;
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
    }
}