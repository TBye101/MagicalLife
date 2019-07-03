using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MagicalLifeAPI.Util
{
    /// <summary>
    /// Holds some reflection utilities.
    /// </summary>
    public static class ReflectionUtil
    {
        /// <summary>
        /// Loads all implementations of type "T", where T is an interface.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="containing"></param>
        /// <returns></returns>
        public static List<T> LoadAllInterface<T>(Assembly containing)
        {
            List<T> objects = new List<T>();

            foreach (Type item in containing.ExportedTypes)
            {
                if (!item.IsInterface && !item.IsAbstract && item.GetInterfaces().Contains(typeof(T)))
                {
                    object tileObject = Activator.CreateInstance(item);

                    if (tileObject is T)
                    {
                        objects.Add((T)tileObject);
                    }
                }
            }

            return objects;
        }

        /// <summary>
        /// Loads all objects that inherit from the abstract class "T".
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="containing"></param>
        /// <returns></returns>
        public static List<T> LoadAllAbstractClass<T>(Assembly containing)
        {
            List<T> objects = new List<T>();

            foreach (Type item in containing.ExportedTypes)
            {
                if (!item.IsInterface && !item.IsAbstract && item.IsSubclassOf(typeof(T)))
                {
                    object tileObject = Activator.CreateInstance(item);

                    if (tileObject is T)
                    {
                        objects.Add((T)tileObject);
                    }
                }
            }

            return objects;
        }

        public static List<Type> LoadTypeOfAllSubclasses<T>(Assembly containing)
        {
            List<Type> objects = new List<Type>();

            foreach (Type item in containing.ExportedTypes)
            {
                if (item.IsSubclassOf(typeof(T)))
                {
                    objects.Add(item);
                }
            }

            return objects;
        }
    }
}