using MagicalLifeAPI.Universal;
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
        private int TotalJobs = -1;

        private readonly List<string> TexturesToLoad = new List<string>();

        private readonly ContentManager Manager;

        public TextureLoader(ContentManager manager)
        {
            this.Manager = manager;
        }

        public TextureLoader()
        {
        }

        public int GetTotalOperations()
        {
            if (this.TotalJobs == -1)
            {
                this.TotalJobs = this.CalculateTotalJobs();
            }

            return this.TotalJobs;
        }

        private int CalculateTotalJobs()
        {
            this.TexturesToLoad.Add("Basic Human");
            this.TexturesToLoad.Add("CursorCarrot");
            this.TexturesToLoad.Add("DirtFloor");
            this.TexturesToLoad.Add("EndTurnButtonState1");
            this.TexturesToLoad.Add("EndTurnButtonState2");
            this.TexturesToLoad.Add("MenuBackground");
            this.TexturesToLoad.Add("MenuButton");
            this.TexturesToLoad.Add("TestTile");
            this.TexturesToLoad.Add("InputBox100x50");

            this.TexturesToLoad.Add("MarbleFloor");
            this.TexturesToLoad.Add("MarbleResourceUnconnected");
            this.TexturesToLoad.Add("MarbleResourceConnected1");
            this.TexturesToLoad.Add("MarbleResourceConnected2");
            this.TexturesToLoad.Add("MarbleResourceConnected3");
            this.TexturesToLoad.Add("MarbleResourceConnected4");

            return this.TexturesToLoad.Count;
        }

        public void InitialStartup(ref int progress)
        {
            if (this.Manager != null)
            {
                //foreach (string item in this.TexturesToLoad)
                //{
                //    Texture2D texture = this.Manager.Load<Texture2D>(item);
                //    AssetManager.RegisterTexture(texture);
                //    progress++;
                //}

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
                        progress++;
                    }
                }
            }
        }
    }
}