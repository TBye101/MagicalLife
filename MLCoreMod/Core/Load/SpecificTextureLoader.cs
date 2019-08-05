using MLAPI.Asset;
using MLAPI.Load;
using MLAPI.Visual.Rendering;
using MLCoreMod.Core.Resources;

namespace MLCoreMod.Core.Load
{
    /// <summary>
    /// Loads specific textures for specific classes such as the trees.
    /// </summary>
    internal class SpecificTextureLoader : IGameLoader
    {
        public void InitialStartup()
        {
            StaticTexture mapleStump = new StaticTexture(AssetManager.NameToIndex[TextureLoader.MapleStump], RenderLayer.TreeStump);
            StaticTexture mapleTrunk = new StaticTexture(AssetManager.NameToIndex[TextureLoader.MapleTrunk], RenderLayer.TreeTrunk);
            StaticTexture mapleLeaves = new StaticTexture(AssetManager.NameToIndex[TextureLoader.MapleLeaves1], RenderLayer.TreeLeaves);

            OffsetTexture offsetMapleStump = new OffsetTexture(RenderLayer.TreeStump, mapleStump, MapleTree.XOffset, MapleTree.YOffset);
            OffsetTexture offsetMapleTrunk = new OffsetTexture(RenderLayer.TreeTrunk, mapleTrunk, MapleTree.XOffset, MapleTree.YOffset);
            OffsetTexture offsetMapleLeaves = new OffsetTexture(RenderLayer.TreeLeaves, mapleLeaves, MapleTree.XOffset, MapleTree.YOffset);

            MapleTree.OffsetStump = offsetMapleStump;
            MapleTree.OffsetTrunk = offsetMapleTrunk;
            MapleTree.OffsetLeaves = offsetMapleLeaves;

            StaticTexture oakStump = new StaticTexture(AssetManager.NameToIndex[TextureLoader.OakStump], RenderLayer.TreeStump);
            StaticTexture oakTrunk = new StaticTexture(AssetManager.NameToIndex[TextureLoader.OakTrunk], RenderLayer.TreeTrunk);
            StaticTexture oakLeaves = new StaticTexture(AssetManager.NameToIndex[TextureLoader.OakLeaves1], RenderLayer.TreeLeaves);

            OffsetTexture offsetOakStump = new OffsetTexture(RenderLayer.TreeStump, oakStump, OakTree.XOffset, OakTree.YOffset);
            OffsetTexture offsetOakTrunk = new OffsetTexture(RenderLayer.TreeTrunk, oakTrunk, OakTree.XOffset, OakTree.YOffset);
            OffsetTexture offsetOakLeaves = new OffsetTexture(RenderLayer.TreeLeaves, oakLeaves, OakTree.XOffset, OakTree.YOffset);

            OakTree.OffsetStump = offsetOakStump;
            OakTree.OffsetTrunk = offsetOakTrunk;
            OakTree.OffsetLeaves = offsetOakLeaves;

            StaticTexture pineStump = new StaticTexture(AssetManager.NameToIndex[TextureLoader.PineStump], RenderLayer.TreeStump);
            StaticTexture pineTrunk = new StaticTexture(AssetManager.NameToIndex[TextureLoader.PineTrunk], RenderLayer.TreeTrunk);
            StaticTexture pineLeaves = new StaticTexture(AssetManager.NameToIndex[TextureLoader.PineLeaves1], RenderLayer.TreeLeaves);

            OffsetTexture offsetPineStump = new OffsetTexture(RenderLayer.TreeStump, pineStump, PineTree.XOffset, PineTree.YOffset);
            OffsetTexture offsetPineTrunk = new OffsetTexture(RenderLayer.TreeTrunk, pineTrunk, PineTree.XOffset, PineTree.YOffset);
            OffsetTexture offsetPineLeaves = new OffsetTexture(RenderLayer.TreeLeaves, pineLeaves, PineTree.XOffset, PineTree.YOffset);

            PineTree.OffsetStump = offsetPineStump;
            PineTree.OffsetTrunk = offsetPineTrunk;
            PineTree.OffsetLeaves = offsetPineLeaves;
        }
    }
}