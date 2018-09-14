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
            this.TexturesToLoad.Add("Basic Human");
            this.TexturesToLoad.Add("CursorCarrot");

            this.TexturesToLoad.Add("MenuBackground");
            this.TexturesToLoad.Add("MenuButton");
            this.TexturesToLoad.Add("InputBox100x50");
            this.TexturesToLoad.Add("GUI/ListBoxItemBackground");

            this.TexturesToLoad.Add("Stone");
            this.TexturesToLoad.Add("StoneRubble_01");
            this.TexturesToLoad.Add("StoneRubble_02");

            this.TexturesToLoad.Add("TestTile");
            this.TexturesToLoad.Add("Dirt");

            this.TexturesToLoad.Add("DirtGrassTrans1");
            this.TexturesToLoad.Add("DirtGrassTrans2");
            this.TexturesToLoad.Add("DirtGrassTrans3");
            this.TexturesToLoad.Add("DirtGrassTrans4");
            this.TexturesToLoad.Add("DirtGrassTrans5");
            this.TexturesToLoad.Add("DirtGrassTrans6");
            this.TexturesToLoad.Add("DirtGrassTrans7");
            this.TexturesToLoad.Add("DirtGrassTrans8");
            this.TexturesToLoad.Add("DirtGrassTrans9");
            this.TexturesToLoad.Add("DirtGrassTrans10");
            this.TexturesToLoad.Add("DirtGrassTrans11");
            this.TexturesToLoad.Add("DirtGrassTrans12");

            this.TexturesToLoad.Add("Grass");

            this.TexturesToLoad.Add("GUI/PickaxeButton_Grey");
            this.TexturesToLoad.Add("GUI/PickaxeButton_Gold");
            this.TexturesToLoad.Add("PickaxeMapIcon");
            
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