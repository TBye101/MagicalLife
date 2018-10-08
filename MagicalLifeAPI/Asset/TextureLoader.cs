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

        public static readonly string GUIListBoxItemBackground = "GUI/ListBoxItemBackground";
        public static readonly string GUIPickaxeButtonGold = "GUI/PickaxeButton_Gold";
        public static readonly string GUIPickaxeButtonGrey = "GUI/PickaxeButton_Grey";
        public static readonly string GUICursorCarrot = "GUI/PickaxeButton_Grey";
        public static readonly string GUIInputBox100x50 = "GUI/InputBox100x50";
        public static readonly string GUIMenuBackground = "GUI/MenuBackground";
        public static readonly string GUIMenuButton = "GUI/MenuButton";
        public static readonly string GUIPickaxeMapIcon = "GUI/PickaxeMapIcon";

        public static readonly string TextureDirt1 = "Textures/Tile/Dirt_01";
        public static readonly string TextureDirt2 = "Textures/Tile/Dirt_02";
        public static readonly string TextureGrass1 = "Textures/Tile/Grass_01";
        public static readonly string TextureGrass2 = "Textures/Tile/Grass_02";
        public static readonly string TextureGrass3 = "Textures/Tile/Grass_03";
        public static readonly string TextureGrass4 = "Textures/Tile/Grass_04";
        public static readonly string TextureStone1 = "Textures/Resource/Stone_01";
        public static readonly string TextureStone2 = "Textures/Resource/Stone_02";
        public static readonly string TextureStoneRubble1 = "Textures/Items/StoneRubble_01";
        public static readonly string TextureStoneRubble2 = "Textures/Items/StoneRubble_02";
        public static readonly string TextureTestTile = "Textures/Tile/TestTile";

        public static readonly string FontMainMenuFont12x = "Fonts/MainMenuFont12x";
        public static readonly string FontMainMenuFont24x = "Fonts/MainMenuFont24x";

        public static readonly string LogoFMOD = "Logo/FMODLogo";
        public static readonly string LogoMonoGame = "Logo/MonoGameLogo";

        public static readonly string AnimationBaseCharacter = "Character/Base Character/BaseCharacterSprite";

        public TextureLoader(ContentManager manager)
        {
            this.Manager = manager;
        }

        public TextureLoader()
        {
            this.Prepare();
        }

        private void Prepare()
        {
            this.TexturesToLoad.Add(GUIListBoxItemBackground);
            this.TexturesToLoad.Add(GUIPickaxeButtonGold);
            this.TexturesToLoad.Add(GUIPickaxeButtonGrey);
            this.TexturesToLoad.Add(GUICursorCarrot);
            this.TexturesToLoad.Add(GUIInputBox100x50);
            this.TexturesToLoad.Add(GUIMenuBackground);
            this.TexturesToLoad.Add(GUIMenuButton);
            this.TexturesToLoad.Add(GUIPickaxeMapIcon);

            this.TexturesToLoad.Add(TextureDirt1);
            this.TexturesToLoad.Add(TextureDirt2);
            this.TexturesToLoad.Add(TextureGrass1);
            this.TexturesToLoad.Add(TextureGrass2);
            this.TexturesToLoad.Add(TextureGrass3);
            this.TexturesToLoad.Add(TextureGrass4);
            this.TexturesToLoad.Add(TextureStone1);
            this.TexturesToLoad.Add(TextureStone2);
            this.TexturesToLoad.Add(TextureStoneRubble1);
            this.TexturesToLoad.Add(TextureStoneRubble2);
            this.TexturesToLoad.Add(TextureTestTile);

            this.TexturesToLoad.Add(FontMainMenuFont12x);
            this.TexturesToLoad.Add(FontMainMenuFont24x);

            this.TexturesToLoad.Add(LogoFMOD);
            this.TexturesToLoad.Add(LogoMonoGame);

            this.TexturesToLoad.Add(AnimationBaseCharacter);
        }

        public void InitialStartup()
        {
            if (this.Manager != null)
            {
                foreach (KeyValuePair<string, int> item in AssetManager.NameToIndex)
                {
                    Texture2D texture = this.Manager.Load<Texture2D>(item.Key);
                    AssetManager.Textures.Add(texture);
                }
            }
            else
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
}