using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Components.MAP_GUI;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World.Base;
using MagicalLifeMod.Core.Settings;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeMod.Core.GameStructures.Parts
{
    [ProtoContract]
    public class DungeonStairDown : StructurePart
    {
        private static readonly Guid PartID = Guid.Parse("B4FEE056-D498-4F25-BBE1-248CF8F894DE");

        private static readonly StaticTexture Visual = 
            new StaticTexture(AssetManager.GetTextureIndex(TextureLoader.StairDown1), RenderLayer.MainObject);

        /// <param name="uniqueStructureID"></param>
        /// <param name="connection">The location of the corrosponding entrance/exit to the dungeon.</param>
        public DungeonStairDown(Guid uniqueStructureID, Point3D connection)
            : base(CoreSettingsHandler.PartConfig.Settings.DungeonStairDownDurability, true, Visual, PartID, uniqueStructureID)
        {
            PortalComponent dungeonConnection = new PortalComponent(new List<Point3D> { connection });

            this.AddComponent(dungeonConnection);
        }

        protected DungeonStairDown()
        {
        }
    }
}
