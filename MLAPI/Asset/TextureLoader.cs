using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MLAPI.Load;

namespace MLAPI.Asset
{
    /// <summary>
    /// Loads all internal textures.
    /// </summary>
    /// <summary>
    /// Loads all internal textures.
    /// </summary>
    public class TextureLoader : IGameLoader
    {
        private readonly List<string> TexturesToLoad = new List<string>();

        private readonly ContentManager Manager;

        #region GUI

        public static readonly string GuiListBoxItemBackground = "GUI/ListBoxItemBackground";
        public static readonly string GuiPickaxeButtonGold = "GUI/PickaxeButton_Gold";
        public static readonly string GuiPickaxeButtonGrey = "GUI/PickaxeButton_Grey";
        public static readonly string GuiAxeButtonGray = "GUI/AxeButton_Grey";
        public static readonly string GuiAxeButtonGold = "GUI/AxeButton_Gold";
        public static readonly string GuiCursorCarrot = "GUI/CursorCarrot";
        public static readonly string GuiInputBox100X50 = "GUI/InputBox100x50";
        public static readonly string GuiMenuBackground = "GUI/MenuBackground";
        public static readonly string GuiMenuButton = "GUI/MenuButton";
        public static readonly string GuiHoeButtonGrey = "GUI/HoeButton_Grey";
        public static readonly string GuiHoeButtonGold = "GUI/HoeButton_Gold";
        public static readonly string Guix = "GUI/X";

        public static readonly string GuiPickaxeMapIcon = "GUI/PickaxeMapIcon";
        public static readonly string GuiAxeMapIcon = "GUI/AxeMapIcon";
        public static readonly string GuiHoeMapIcon = "GUI/HoeMapIcon";

        #endregion GUI

        #region Crops

        public static readonly string CornSeedling = "Textures/Resource/Plants/Crops/CornSeedling";
        public static readonly string CornGrowth1 = "Textures/Resource/Plants/Crops/CornGrowth1";
        public static readonly string CornGrowth2 = "Textures/Resource/Plants/Crops/CornGrowth2";
        public static readonly string CornGrowth3 = "Textures/Resource/Plants/Crops/CornFullGrowth";

        #endregion Crops

        #region TileTextures

        public static readonly string TextureDirt1 = "Textures/Tile/Dirt_01";
        public static readonly string TextureDirt2 = "Textures/Tile/Dirt_02";
        public static readonly string TextureGrass1 = "Textures/Tile/Grass_01";
        public static readonly string TextureGrass2 = "Textures/Tile/Grass_02";
        public static readonly string TextureGrass3 = "Textures/Tile/Grass_03";
        public static readonly string TextureGrass4 = "Textures/Tile/Grass_04";
        public static readonly string TextureStone1 = "Textures/Resource/Stone_01";
        public static readonly string TextureStone2 = "Textures/Resource/Stone_02";
        public static readonly string TextureTestTile = "Textures/Tile/TestTile";
        public static readonly string TextureTilledDirt = "Textures/Tile/TilledDirt";

        #endregion TileTextures

        #region TreeTextures

        public static readonly string OakStump = "Textures/Resource/Plants/Trees/Stumps/Oak_Stump";
        public static readonly string MapleStump = "Textures/Resource/Plants/Trees/Stumps/Maple_Stump";
        public static readonly string PineStump = "Textures/Resource/Plants/Trees/Stumps/Pine_Stump";

        public static readonly string OakTrunk = "Textures/Resource/Plants/Trees/Trunks/Oak_Trunk";
        public static readonly string MapleTrunk = "Textures/Resource/Plants/Trees/Trunks/Maple_Trunk";
        public static readonly string PineTrunk = "Textures/Resource/Plants/Trees/Trunks/Pine_Trunk";

        public static readonly string OakLeaves1 = "Textures/Resource/Plants/Trees/Leaves/Oak_Leaves_01";
        public static readonly string OakLeaves2 = "Textures/Resource/Plants/Trees/Leaves/Oak_Leaves_02";
        public static readonly string MapleLeaves1 = "Textures/Resource/Plants/Trees/Leaves/Maple_Leaves_01";
        public static readonly string MapleLeaves2 = "Textures/Resource/Plants/Trees/Leaves/Maple_Leaves_02";
        public static readonly string PineLeaves1 = "Textures/Resource/Plants/Trees/Leaves/Pine_Leaves_01";
        public static readonly string PineLeaves2 = "Textures/Resource/Plants/Trees/Leaves/Pine_Leaves_02";

        #endregion TreeTextures

        #region Items

        public static readonly string TextureStoneRubble1 = "Textures/Items/StoneRubble_01";
        public static readonly string TextureStoneRubble2 = "Textures/Items/StoneRubble_02";

        public static readonly string LogTexture1 = "Textures/Items/Log_1";

        public static readonly string TextureWoodPlank = "Textures/Items/WoodPlank";

        public static readonly string CornEar = "Textures/Items/Food/CornEar";

        #endregion Items

        #region Fonts

        public static readonly string FontMainMenuFont12X = "Fonts/MainMenuFont12x";
        public static readonly string FontMainMenuFont24X = "Fonts/MainMenuFont24x";

        #endregion Fonts

        #region Logos

        public static readonly string LogoFmod = "Logo/FMODLogo";
        public static readonly string LogoMonoGame = "Logo/MonoGameLogo";

        #endregion Logos

        #region Animations

        public static readonly string AnimationBaseCharacter = "Character/Base Character/BaseCharacterSprite";

        #endregion Animations

        #region Structure

        public static readonly string StairDown1 = "Structure/StairsDown1";
        public static readonly string StairUp1 = "Structure/StairsUp1";

        #endregion Structure

        public static readonly string Missing = "Missing";

        public TextureLoader(ContentManager manager)
        {
            this.Manager = manager;
            this.Prepare();
        }

        public TextureLoader()
        {
            this.Prepare();
        }

        private void Prepare()
        {
            this.TexturesToLoad.Add("Character/Character");
            this.TexturesToLoad.Add(GuiListBoxItemBackground);
            this.TexturesToLoad.Add(GuiPickaxeButtonGold);
            this.TexturesToLoad.Add(GuiPickaxeButtonGrey);
            this.TexturesToLoad.Add(GuiAxeButtonGold);
            this.TexturesToLoad.Add(GuiAxeButtonGray);
            this.TexturesToLoad.Add(GuiCursorCarrot);
            this.TexturesToLoad.Add(GuiInputBox100X50);
            this.TexturesToLoad.Add(GuiMenuBackground);
            this.TexturesToLoad.Add(GuiMenuButton);
            this.TexturesToLoad.Add(GuiHoeButtonGrey);
            this.TexturesToLoad.Add(GuiHoeButtonGold);
            this.TexturesToLoad.Add(Guix);

            this.TexturesToLoad.Add(GuiPickaxeMapIcon);
            this.TexturesToLoad.Add(GuiAxeMapIcon);
            this.TexturesToLoad.Add(GuiHoeMapIcon);

            this.TexturesToLoad.Add(TextureDirt1);
            this.TexturesToLoad.Add(TextureDirt2);
            this.TexturesToLoad.Add(TextureGrass1);
            this.TexturesToLoad.Add(TextureGrass2);
            this.TexturesToLoad.Add(TextureGrass3);
            this.TexturesToLoad.Add(TextureGrass4);
            this.TexturesToLoad.Add(TextureStone1);
            this.TexturesToLoad.Add(TextureStone2);
            this.TexturesToLoad.Add(TextureTestTile);
            this.TexturesToLoad.Add(TextureTilledDirt);

            this.TexturesToLoad.Add(TextureStoneRubble1);
            this.TexturesToLoad.Add(TextureStoneRubble2);
            this.TexturesToLoad.Add(LogTexture1);
            this.TexturesToLoad.Add(TextureWoodPlank);

            this.TexturesToLoad.Add(OakStump);
            this.TexturesToLoad.Add(MapleStump);
            this.TexturesToLoad.Add(PineStump);

            this.TexturesToLoad.Add(OakTrunk);
            this.TexturesToLoad.Add(MapleTrunk);
            this.TexturesToLoad.Add(PineTrunk);

            this.TexturesToLoad.Add(OakLeaves1);
            this.TexturesToLoad.Add(OakLeaves2);
            this.TexturesToLoad.Add(MapleLeaves1);
            this.TexturesToLoad.Add(MapleLeaves2);
            this.TexturesToLoad.Add(PineLeaves1);
            this.TexturesToLoad.Add(PineLeaves2);

            this.TexturesToLoad.Add(LogoFmod);
            this.TexturesToLoad.Add(LogoMonoGame);

            this.TexturesToLoad.Add(AnimationBaseCharacter);

            this.TexturesToLoad.Add(Missing);

            this.TexturesToLoad.Add(StairDown1);
            this.TexturesToLoad.Add(StairUp1);
        }

        public void InitialStartup()
        {
            if (World.Data.World.Mode == Networking.EngineMode.ClientOnly || World.Data.World.Mode == Networking.EngineMode.ServerAndClient)
            {
                this.LoadNameIndex();
                this.LoadTextures();
            }

            if (World.Data.World.Mode == Networking.EngineMode.ServerOnly)
            {
                this.LoadNameIndex();
            }
        }

        private void LoadTextures()
        {
            if (this.Manager != null)
            {
                foreach (KeyValuePair<string, int> item in AssetManager.NameToIndex)
                {
                    Texture2D texture = this.Manager.Load<Texture2D>(item.Key);
                    AssetManager.Textures.Add(texture);
                }
            }
        }

        private void LoadNameIndex()
        {
            if (AssetManager.NameToIndex.Count == 0)
            {
                foreach (string item in this.TexturesToLoad)
                {
                    AssetManager.NameToIndex.Add(item, AssetManager.NameToIndex.Count);
                }
            }
        }
    }
}