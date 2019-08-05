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