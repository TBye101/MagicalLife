using System.Collections.Generic;
using MLAPI.Asset;
using MLAPI.Visual;
using MLAPI.Visual.Rendering;
using MLAPI.World.Base;
using ProtoBuf;

namespace MLCoreMod.Core.Items
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