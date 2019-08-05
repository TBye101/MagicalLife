using System;
using System.Collections.Generic;
using MLAPI.Asset;
using MLAPI.Components;
using MLAPI.DataTypes;
using MLAPI.Visual.Rendering;
using MLAPI.World.Structure;
using MLCoreMod.Core.Settings;
using ProtoBuf;

namespace MLCoreMod.Core.GameStructures.Parts
{
    [ProtoContract]
    public class DungeonStairDown : StructurePart
    {
        private static readonly Guid PartId = Guid.Parse("B4FEE056-D498-4F25-BBE1-248CF8F894DE");

        private static readonly StaticTexture Visual = 
            new StaticTexture(AssetManager.GetTextureIndex(TextureLoader.StairDown1), RenderLayer.MainObject);

        /// <param name="uniqueStructureId"></param>
        /// <param name="connection">The location of the corrosponding entrance/exit to the dungeon.</param>
        public DungeonStairDown(Guid uniqueStructureId, Point3D connection)
            : base(CoreSettingsHandler.PartConfig.Settings.DungeonStairDownDurability, true, Visual, PartId, uniqueStructureId)
        {
            PortalComponent dungeonConnection = new PortalComponent(new List<Point3D> { connection });

            this.AddComponent(dungeonConnection);
        }

        protected DungeonStairDown()
        {
        }
    }
}
