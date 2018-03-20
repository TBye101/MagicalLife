using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Universal;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MagicalLifeGUIWindows.Load
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
            this.TexturesToLoad.Add("DirtTile");
            this.TexturesToLoad.Add("EndTurnButtonState1");
            this.TexturesToLoad.Add("EndTurnButtonState2");
            this.TexturesToLoad.Add("MenuBackground");
            this.TexturesToLoad.Add("MenuButton");
            this.TexturesToLoad.Add("TestTile");
            this.TexturesToLoad.Add("InputBox100x50");

            return this.TexturesToLoad.Count;
        }

        public void InitialStartup(ref int progress)
        {
            foreach (string item in this.TexturesToLoad)
            {
                Texture2D texture = Game1.AssetManager.Load<Texture2D>(item);
                AssetManager.RegisterTexture(texture);
                progress++;
            }
        }
    }
}