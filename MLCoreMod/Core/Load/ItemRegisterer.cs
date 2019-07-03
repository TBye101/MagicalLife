using MagicalLifeAPI.Load;
using MagicalLifeAPI.Registry.ItemRegistry;
using MagicalLifeAPI.World.Items;
using MagicalLifeMod.Core.Items;

namespace MagicalLifeMod.Core.Load
{
    /// <summary>
    /// Registers the items.
    /// </summary>
    public class ItemRegisterer : IGameLoader
    {
        internal static readonly Log ExampleLog = new Log(1);
        internal static readonly StoneRubble ExampleStoneRubble = new StoneRubble(1);
        internal static readonly WoodPlank ExampleWoodPlank = new WoodPlank(1);

        public void InitialStartup()
        {
            ItemRegistry.RegisterItemType(ExampleLog);
            ItemRegistry.RegisterItemType(ExampleStoneRubble);
            ItemRegistry.RegisterItemType(ExampleWoodPlank);
        }
    }
}