namespace EarthWithMagicAPI.API.Registry
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using EarthWithMagicAPI.API.Interfaces.Spells;

    public static class SpellRegistry
    {
        public static List<ISpell> Items = new List<ISpell>();

        static SpellRegistry()
        {
            Assembly itemAssembly = Assembly.Load(new AssemblyName("EarthMagicItems"));
            Type interfaceType = typeof(ISpell);

            foreach (Type item in itemAssembly.GetTypes())
            {
                if (interfaceType.IsAssignableFrom(item) && !item.GetTypeInfo().IsAbstract)
                {
                    foreach (ConstructorInfo constructor in item.GetTypeInfo().DeclaredConstructors)
                    {
                        if (constructor.GetParameters().Length == 0)
                        {
                            ISpell someItem = (ISpell)itemAssembly.CreateInstance(item.FullName, false);
                            Items.Add(someItem);
                        }
                    }
                }
            }
        }
    }
}
