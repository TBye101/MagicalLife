using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.World.Base;
using MagicalLifeMod.Core;
using ProtoBuf;
using System.Collections.Generic;

namespace MagicalLifeAPI.World.Items
{
    /// <summary>
    /// Represents a log in the world.
    /// </summary>
    [ProtoContract]
    public class Log : Item
    {
        private static readonly string ItemName = "Log";

        public Log(int count)
            : base(ItemName, new List<string>(), 50, count, TextureLoader.LogTexture1, 5, DescriptionValues.DisplayName)
        {
            this.InitializeComponents();
        }

        private void InitializeComponents()
        {
            ComponentHasTexture visualComponent = this.GetExactComponent<ComponentHasTexture>();
            visualComponent.Visuals.Add(new StaticTexture(AssetManager.NameToIndex[TextureLoader.LogTexture1], RenderLayer.MainObject));
        }

        protected Log()
        {
            //Protobuf-net constructor.
        }

        public override Item GetDeepCopy(int amount)
        {
            return new Log(amount);
        }
    }
}