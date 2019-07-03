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
    public class CornEar : Item
    {
        private static readonly string ItemName = "Ear of corn";

        public CornEar(int count)
            : base(ItemName, new List<string>(), 100, count, TextureLoader.CornEar, .3, DescriptionValues.DisplayName)
        {
            this.InitializeComponents();
        }

        private void InitializeComponents()
        {
            ComponentHasTexture visualComponent = this.GetExactComponent<ComponentHasTexture>();
            visualComponent.Visuals.Add(new StaticTexture(AssetManager.NameToIndex[TextureLoader.CornEar], RenderLayer.MainObject));
        }

        protected CornEar()
        {
            //Protobuf-net constructor.
        }

        public override Item GetDeepCopy(int amount)
        {
            return new CornEar(amount);
        }
    }
}