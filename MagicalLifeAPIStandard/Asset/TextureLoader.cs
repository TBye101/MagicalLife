using MagicalLifeAPI.Load;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MagicalLifeAPI.Asset
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

        public static readonly string GUIListBoxItemBackground = "GUI/ListBoxItemBackground";
        public static readonly string GUIPickaxeButtonGold = "GUI/PickaxeButton_Gold";
        public static readonly string GUIPickaxeButtonGrey = "GUI/PickaxeButton_Grey";
        public static readonly string GUIAxeButtonGray = "GUI/AxeButton_Grey";
        public static readonly string GUIAxeButtonGold = "GUI/AxeButton_Gold";
        public static readonly string GUICursorCarrot = "GUI/CursorCarrot";
        public static readonly string GUIInputBox100x50 = "GUI/InputBox100x50";
        public static readonly string GUIMenuBackground = "GUI/MenuBackground";
        public static readonly string GUIMenuButton = "GUI/MenuButton";
        public static readonly string GUIHoeButtonGrey = "GUI/HoeButton_Grey";
        public static readonly string GUIHoeButtonGold = "GUI/HoeButton_Gold";
        public static readonly string GUIX = "GUI/X";

        public static readonly string GUIPickaxeMapIcon = "GUI/PickaxeMapIcon";
        public static readonly string GUIAxeMapIcon = "GUI/AxeMapIcon";
        public static readonly string GUIHoeMapIcon = "GUI/HoeMapIcon";

        #endregion GUI

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

        #endregion Items

        #region Fonts

        public static readonly string FontMainMenuFont12x = "Fonts/MainMenuFont12x";
        public static readonly string FontMainMenuFont24x = "Fonts/MainMenuFont24x";

        #endregion Fonts

        #region Logos

        public static readonly string LogoFMOD = "Logo/FMODLogo";
        public static readonly string LogoMonoGame = "Logo/MonoGameLogo";

        #endregion Logos

        #region Animations

        public static readonly string AnimationBaseCharacter = "Character/Base Character/BaseCharacterSprite";

        #endregion Animations

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
            this.TexturesToLoad.Add(GUIListBoxItemBackground);
            this.TexturesToLoad.Add(GUIPickaxeButtonGold);
            this.TexturesToLoad.Add(GUIPickaxeButtonGrey);
            this.TexturesToLoad.Add(GUIAxeButtonGold);
            this.TexturesToLoad.Add(GUIAxeButtonGray);
            this.TexturesToLoad.Add(GUICursorCarrot);
            this.TexturesToLoad.Add(GUIInputBox100x50);
            this.TexturesToLoad.Add(GUIMenuBackground);
            this.TexturesToLoad.Add(GUIMenuButton);
            this.TexturesToLoad.Add(GUIHoeButtonGrey);
            this.TexturesToLoad.Add(GUIHoeButtonGold);
            this.TexturesToLoad.Add(GUIX);

            this.TexturesToLoad.Add(GUIPickaxeMapIcon);
            this.TexturesToLoad.Add(GUIAxeMapIcon);
            this.TexturesToLoad.Add(GUIHoeMapIcon);

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

            this.TexturesToLoad.Add(LogoFMOD);
            this.TexturesToLoad.Add(LogoMonoGame);

            this.TexturesToLoad.Add(AnimationBaseCharacter);
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