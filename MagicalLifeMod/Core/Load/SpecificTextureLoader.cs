using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Visual.Rendering.AbstractVisuals;
using MagicalLifeAPI.World.Resources;
using MagicalLifeAPI.World.Resources.Tree;

namespace MagicalLifeAPI.Load
{
    /// <summary>
    /// Loads specific textures for specific classes such as the trees.
    /// </summary>
    internal class SpecificTextureLoader : IGameLoader
    {
        public void InitialStartup()
        {
            StaticTexture MapleStump = new StaticTexture(AssetManager.NameToIndex[TextureLoader.MapleStump], RenderLayer.TreeStump);
            StaticTexture MapleTrunk = new StaticTexture(AssetManager.NameToIndex[TextureLoader.MapleTrunk], RenderLayer.TreeTrunk);
            StaticTexture MapleLeaves = new StaticTexture(AssetManager.NameToIndex[TextureLoader.MapleLeaves1], RenderLayer.TreeLeaves);

            OffsetTexture OffsetMapleStump = new OffsetTexture(RenderLayer.TreeStump, MapleStump, MapleTree.XOffset, MapleTree.YOffset);
            OffsetTexture OffsetMapleTrunk = new OffsetTexture(RenderLayer.TreeTrunk, MapleTrunk, MapleTree.XOffset, MapleTree.YOffset);
            OffsetTexture OffsetMapleLeaves = new OffsetTexture(RenderLayer.TreeLeaves, MapleLeaves, MapleTree.XOffset, MapleTree.YOffset);

            MapleTree.OffsetStump = OffsetMapleStump;
            MapleTree.OffsetTrunk = OffsetMapleTrunk;
            MapleTree.OffsetLeaves = OffsetMapleLeaves;

            StaticTexture OakStump = new StaticTexture(AssetManager.NameToIndex[TextureLoader.OakStump], RenderLayer.TreeStump);
            StaticTexture OakTrunk = new StaticTexture(AssetManager.NameToIndex[TextureLoader.OakTrunk], RenderLayer.TreeTrunk);
            StaticTexture OakLeaves = new StaticTexture(AssetManager.NameToIndex[TextureLoader.OakLeaves1], RenderLayer.TreeLeaves);

            OffsetTexture OffsetOakStump = new OffsetTexture(RenderLayer.TreeStump, OakStump, OakTree.XOffset, OakTree.YOffset);
            OffsetTexture OffsetOakTrunk = new OffsetTexture(RenderLayer.TreeTrunk, OakTrunk, OakTree.XOffset, OakTree.YOffset);
            OffsetTexture OffsetOakLeaves = new OffsetTexture(RenderLayer.TreeLeaves, OakLeaves, OakTree.XOffset, OakTree.YOffset);

            OakTree.OffsetStump = OffsetOakStump;
            OakTree.OffsetTrunk = OffsetOakTrunk;
            OakTree.OffsetLeaves = OffsetOakLeaves;

            StaticTexture PineStump = new StaticTexture(AssetManager.NameToIndex[TextureLoader.PineStump], RenderLayer.TreeStump);
            StaticTexture PineTrunk = new StaticTexture(AssetManager.NameToIndex[TextureLoader.PineTrunk], RenderLayer.TreeTrunk);
            StaticTexture PineLeaves = new StaticTexture(AssetManager.NameToIndex[TextureLoader.PineLeaves1], RenderLayer.TreeLeaves);

            OffsetTexture OffsetPineStump = new OffsetTexture(RenderLayer.TreeStump, PineStump, PineTree.XOffset, PineTree.YOffset);
            OffsetTexture OffsetPineTrunk = new OffsetTexture(RenderLayer.TreeTrunk, PineTrunk, PineTree.XOffset, PineTree.YOffset);
            OffsetTexture OffsetPineLeaves = new OffsetTexture(RenderLayer.TreeLeaves, PineLeaves, PineTree.XOffset, PineTree.YOffset);

            PineTree.OffsetStump = OffsetPineStump;
            PineTree.OffsetTrunk = OffsetPineTrunk;
            PineTree.OffsetLeaves = OffsetPineLeaves;
        }
    }
}