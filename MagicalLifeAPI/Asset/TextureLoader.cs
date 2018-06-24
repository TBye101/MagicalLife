using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Universal;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MagicalLifeAPI.Asset
{
    /// <summary>
    /// Loads all internal textures.
    /// </summary>
    public class TextureLoader : IGameLoader
    {
        private int TotalJobs = -1;

        private List<string> TexturesToLoad = new List<string>();

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
            this.TexturesToLoad.Add("MarbleResourceConnected4");//use these strings to get texture IDs to assign in the asset manager or something
                                                                //Give each renderable object an int ID, then store in a list somewhere the ID of the corrosponding asset.
                                                                //Server can set these, and the client can later load the assets

            return this.TexturesToLoad.Count;
        }

        public void InitialStartup(ref int progress)
        {
            if (!AssetManager.isServerOnly)
            {
                Game a = new Game();
                foreach (string item in this.TexturesToLoad)
                {
                    Texture2D texture = a.Content.Load<Texture2D>(item);
                    AssetManager.RegisterTexture(texture);
                    progress++;
                }
            }
            else
            {
                foreach (string item in this.TexturesToLoad)
                {
                    AssetManager.NameToIndex.Add(item, AssetManager.NameToIndex.Count);
                }
            }
        }
    }
}